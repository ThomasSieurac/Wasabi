using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Collider2D))]
public class WSB_Player : MonoBehaviour
{
    #region debug

    [SerializeField] GameObject nose = null;

    #endregion


    protected Rigidbody2D Physic = null;
    protected Collider2D Collider = null;

    protected bool isRight = true;

    #region Unity
    private void Awake()
    {
        if (!Physic) Physic = GetComponent<Rigidbody2D>();
        if (!Physic)
        {
            Debug.LogError($"Erreur, component Rigidbody2D manquant sur {transform.name}");
            Destroy(this);
        }
        if (!Collider) Collider = GetComponent<Collider2D>();
        if (!Collider)
        {
            Debug.LogError($"Erreur, component Collider2D manquant sur {transform.name}");
            Destroy(this);
        }
    }

    protected virtual void Update()
    {
        AddHorizontalMovement(xMovement);
        if (Mathf.Abs(yMovement) > 0 && canClimb)
        {
            force.y = 0;
            isClimbing = true;
            AddVerticalMovement(yMovement * controllerValues.ClimbSpeed);
        }
        else if (!canClimb)
            isClimbing = false;

        if (jumpInput)
        {
            if (isGrounded || isClimbing || (Time.time - coyoteVar < controllerValues.JumpDelay))
                Jump();
            else
                jumpBufferVar = Time.time;
        }

        if (isJumping)
        {
            if (!jumpInput && jumpVar < .3f)
            {
                jumpOriginHeight -= controllerValues.JumpCurve.Evaluate(.3f) - controllerValues.JumpCurve.Evaluate(jumpVar);
                jumpVar = .3f;
            }
            else
            {
                jumpVar += Time.deltaTime;
                if (jumpVar > controllerValues.JumpCurve[controllerValues.JumpCurve.length - 1].time)
                {
                    jumpVar = controllerValues.JumpCurve[controllerValues.JumpCurve.length - 1].time;
                    StopJump();
                }

                AddVerticalMovement((jumpOriginHeight + controllerValues.JumpCurve.Evaluate(jumpVar) - Physic.position.y) / Time.deltaTime);
            }
        }
        else if(!isClimbing)
            ApplyGravity();

        if ((force + instantForce + movement) != Vector2.zero)
        {
            Vector2 _pos = Physic.position;

            ComputeVelocity();
            CalculCollision();
            RefreshPosition();

            OnAppliedVelocity(Physic.position - _pos);

            instantForce = movement = Vector2.zero;
        }
        else
            OnAppliedVelocity(Vector2.zero);
    }

    #endregion

    #region Input Reading

    float xMovement = 0;
    float yMovement = 0;

    public void Move(InputAction.CallbackContext _context)
    {
        if (WSB_PlayTestManager.Paused)
            return;
        if (_context.valueType != typeof(Vector2)) return;
        xMovement = _context.ReadValue<Vector2>().x;
        if (xMovement < 0)
            isRight = false;
        if (xMovement > 0)
            isRight = true;
        nose.transform.localPosition = new Vector3((isRight ? .5f : -.5f), .5f);
        yMovement = _context.ReadValue<Vector2>().y;
    }

    public void Jump(InputAction.CallbackContext _context)
    {
        if (WSB_PlayTestManager.Paused)
            return;
        if (_context.valueType == typeof(float))
            jumpInput = _context.ReadValue<float>() == 1;
    }

    public virtual void UseSpell(string _s)
    {

    }
    public virtual void StopSpell()
    {

    }

    public void CanClimb(bool _s) => canClimb = _s;

    #endregion

    #region Controller

    [SerializeField] SO_ControllerValues controllerValues = null;

    [SerializeField] Vector2 force = Vector2.zero;
    [SerializeField] Vector2 instantForce = Vector2.zero;
    [SerializeField] Vector2 movement = Vector2.zero;

    [SerializeField] float speed = 5;
    [SerializeField] Vector2 groundNormal = new Vector2();

    [SerializeField] bool isGrounded = false;
    [SerializeField] bool isJumping = false;
    [SerializeField] bool isClimbing = false;
    [SerializeField] bool canClimb = false;



    void OnAppliedVelocity(Vector2 _velocity)
    {
        if (isJumping)
            jumpOriginHeight += _velocity.y - (movement.y * Time.deltaTime);
    }

    void ComputeVelocity()
    {
        if (force.x != 0)
            force.x = Mathf.MoveTowards(force.x, 0, controllerValues.Deceleration * Time.deltaTime);
    }

    void RefreshPosition()
    {
        int _amount = Collider.OverlapCollider(controllerValues.Contact, overlapBuffer);
        for (int i = 0; i < _amount; i++)
        {
            if (overlapBuffer[i] == ignoredCollider)
                continue;
            ColliderDistance2D _distance = Collider.Distance(overlapBuffer[i]);
            if (_distance.isOverlapped && (!overlapBuffer[i].transform.GetComponent<PlatformEffector2D>() || _distance.normal.y == -1))
                Physic.position += _distance.normal * _distance.distance;
        }
    }


    #region Jump

    [SerializeField] bool jumpInput = false;

    float jumpVar = 0;
    float jumpOriginHeight = 0;
    float coyoteVar = -999;
    float jumpBufferVar = -999;

    void Jump()
    {
        isJumping = true;
        jumpVar = force.y = 0;
        jumpOriginHeight = transform.position.y;
        coyoteVar = -999;
    }

    void StopJump() => isJumping = false;

    #endregion


    #region Collision

    private static int bufferAmount = 0;
    private static readonly RaycastHit2D[] buffer = new RaycastHit2D[4];
    private static readonly RaycastHit2D[] castBuffer = new RaycastHit2D[4];
    private static readonly Collider2D[] overlapBuffer = new Collider2D[4];

    void CalculCollision()
    {
        Vector2 _velocity = GetVeloctity();
        if(isGrounded)
        {
            Vector2 _x = Vector2.Perpendicular(groundNormal);
            if (_x.x < 0)
                _x *= -1;

            _x *= _velocity.x;
            Vector2 _y = (_velocity.y < 0 ? groundNormal : Vector2.up) * _velocity.y;

            _velocity = _x + _y;
        }

        bufferAmount = 0;
        CalculCollisionRecursively(_velocity, groundNormal);

        bool _isGrounded = false;
        for (int i = 0; i < bufferAmount; i++)
        {
            if (force != Vector2.zero)
                force -= castBuffer[i].normal * Vector2.Dot(force, castBuffer[i].normal);

            if (isJumping && castBuffer[i].normal.y == -1)
            {
                isJumping = true;
                groundNormal = castBuffer[i].normal;
            }

            if (!_isGrounded && (castBuffer[i].normal.y > controllerValues.GroundMin))
            {
                _isGrounded = true;
                groundNormal = castBuffer[i].normal;
            }
        }

        if(!_isGrounded)
        {
            _isGrounded = CastCollider(Vector2.down * Physics2D.defaultContactOffset * 2, out RaycastHit2D _hit) && (_hit.normal.y > controllerValues.GroundMin) && _hit.collider != ignoredCollider;
            groundNormal = _isGrounded ? _hit.normal : Vector2.up;
        }

        if (_isGrounded)
            force.y = 0;

        if (_isGrounded != isGrounded)
            OnSetGrounded(_isGrounded);
    }

    void CalculCollisionRecursively(Vector2 _velocity, Vector2 _normal, int _iteration = 0)
    {
        int _amount = CastCollider(_velocity, out float _distance);

        if (_distance == 0)
            return;

        if(_amount == 0)
        {
            Physic.position += _velocity;
            GroundSnap(_velocity, _normal);
            return;
        }

        if ((_distance -= Physics2D.defaultContactOffset) > 0)
        {
            Vector2 _normalizedVelocity = _velocity.normalized;

            Physic.position += _normalizedVelocity * _distance;
            _velocity = _normalizedVelocity * (_velocity.magnitude - _distance);
        }

        InsertCastBuffer(_amount);

        if(_iteration > 3)
        {
            GroundSnap(_velocity, _normal);
            return;
        }


        if (_normal.y != 1)
            _velocity = Quaternion.FromToRotation(_normal, Vector3.up) * _velocity;

        ClimbStep(ref _velocity, buffer[0]);

        Vector2 _hitNormal = castBuffer[0].normal;
        _velocity -= _hitNormal * Vector2.Dot(_velocity, _hitNormal);

        if (_velocity != Vector2.zero)
            CalculCollisionRecursively(_velocity, Vector2.zero, _iteration + 1);


    }
    void InsertCastBuffer(int _amount)
    {
        if (bufferAmount < buffer.Length)
        {
            for (int i = 0; i < _amount; i++)
            {
                buffer[bufferAmount + i] = castBuffer[i];
                bufferAmount++;

                if (bufferAmount == buffer.Length)
                    return;
            }
        }
        else
            buffer[bufferAmount - 1] = castBuffer[0];
    }

    bool CastCollider(Vector2 _velocity, out RaycastHit2D _hit)
    {
        bool _return = (Collider.Cast(_velocity, controllerValues.Contact, castBuffer, _velocity.magnitude) > 0) && (!castBuffer[0].transform.GetComponent<PlatformEffector2D>() && castBuffer[0].normal.y != -1);
        _hit = castBuffer[0];
        return _return;
    }

    [SerializeField] Collider2D ignoredCollider = null;

    int CastCollider(Vector2 _velocity, out float _distance)
    {
        _distance = _velocity.magnitude;
        int _amount = Collider.Cast(_velocity, controllerValues.Contact, castBuffer, _distance);

        if (_amount == 0)
            ignoredCollider = null;

        for (int i = 0; i < _amount; i++)
        {
            if (castBuffer[i].transform.GetComponent<PlatformEffector2D>() && castBuffer[i].normal.y == -1 || castBuffer[i].transform.GetComponent<PlatformEffector2D>() && castBuffer[i] == ignoredCollider)
            {
                ignoredCollider = castBuffer[i].collider;
                _amount = i;
                break;
            }
            if (!castBuffer[i].transform.GetComponent<PlatformEffector2D>())
                ignoredCollider = null;
        }

        if(_amount > 0)
        {
            _distance = Mathf.Max(0, castBuffer[0].distance - Physics2D.defaultContactOffset);
            for (int i = 1; i < _amount; i++)
            {
                if ((castBuffer[i].distance + .001f) > castBuffer[0].distance)
                    return i;
            }
        }
        return _amount;
    }

    #endregion


    #region Physic

    void ApplyGravity() => AddForce(Physics2D.gravity * Time.deltaTime);

    void OnSetGrounded(bool _isGrounded)
    {
        isGrounded = _isGrounded;

        if (_isGrounded)
        {
            if (Time.time - jumpBufferVar < controllerValues.JumpBufferDelay)
                Jump();
        }
        else
            coyoteVar = Time.time;
    }

    void ClimbStep(ref Vector2 _velocity, RaycastHit2D _hit)
    {
        if (_velocity.x == 0 || _hit.normal.y > controllerValues.GroundMin)
            return;
        Physic.position += new Vector2(0, controllerValues.MaxHeightClimb);
        _velocity.y -= controllerValues.MaxHeightClimb;

        int _amount = CastCollider(_velocity, out float _distance);

        if (_amount == 0)
        {
            Physic.position += _velocity;
            _velocity.Set(0, 0);
        }
        else if (_distance != 0 && ((_hit.collider != castBuffer[0].collider) || (_hit.normal != castBuffer[0].normal)))
        {
            Vector2 _normalized = _velocity.normalized;
            Physic.position += _normalized * _distance;
            _velocity = _normalized * (_velocity.magnitude - _distance);

            InsertCastBuffer(_amount);
        }
        else
        {
            Physic.position -= new Vector2(0, controllerValues.MaxHeightClimb);
            _velocity.y += controllerValues.MaxHeightClimb;
            _velocity.x = 0;
        }
    }

    void GroundSnap(Vector2 _velocity, Vector2 _normal)
    {
        if (_normal.y != 1)
            _velocity = Quaternion.FromToRotation(_normal, Vector3.up) * _velocity;

        if(isGrounded && (_velocity.y < 0) && CastCollider(_normal * -1, out RaycastHit2D _snapHit))
        {
            Physic.position += _normal * -_snapHit.distance;
            InsertCastBuffer(1);
        }
    }

    #endregion


    #region AddForces

    float 所有 = 0;


    public void AddForce(Vector2 _force) => force += _force;

    void AddVerticalMovement(float _velocity) => movement.y += _velocity;

    void AddHorizontalMovement(float _velocity)
    {
        if(_velocity == 0)
        {
            所有 = speed = 0;
            return;
        }

        所有 = Mathf.Min(所有 + Time.deltaTime, controllerValues.SpeedCurve[controllerValues.SpeedCurve.length - 1].time);
        speed = controllerValues.SpeedCurve.Evaluate(所有);

        movement.x += _velocity * speed;
    }

    public void AddInstantForce(Vector2 _velocity) => instantForce += _velocity;

    #endregion

    Vector2 GetVeloctity() => ((force + movement) * Time.deltaTime) + instantForce * controllerValues.SpeedCoef;

    #endregion
}
