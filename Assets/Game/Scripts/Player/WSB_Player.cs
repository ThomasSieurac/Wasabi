using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using Nowhere;

//[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(BoxCollider2D))]
public class WSB_Player : LG_Movable
{
    //#region debug

    //[SerializeField] SpriteRenderer spriteRend = null;

    //#endregion

    //protected Rigidbody2D Physic = null;
    //protected BoxCollider2D Collider = null;

    //protected bool isRight = true;

    //#region Unity
    //protected virtual void Awake()
    //{
    //    // Gets needed components if not set.
    //    // Throw errors if not found them destroy itself

    //    if (!Physic) Physic = GetComponent<Rigidbody2D>();
    //    if (!Physic)
    //    {
    //        Debug.LogError($"Erreur, component Rigidbody2D manquant sur {transform.name}");
    //        Destroy(this);
    //    }
    //    if (!Collider) Collider = GetComponent<BoxCollider2D>();
    //    if (!Collider)
    //    {
    //        Debug.LogError($"Erreur, component Collider2D manquant sur {transform.name}");
    //        Destroy(this);
    //    }

    //    // Set debug nose position
    //    spriteRend.flipX = !isRight;
    //}

    //protected virtual void Update()
    //{
    //    // Adds input's horizontal movement
    //    if(canMove)
    //        AddHorizontalMovement(xMovement);

    //    // Check if user wants to climb
    //    if ((Mathf.Abs(yMovement) > 0 || jumpInput) && canClimb && canMove)
    //    {
    //        force.y = 0;
    //        isClimbing = true;
    //        AddVerticalMovement(yMovement * controllerValues.ClimbSpeed);
    //    }
    //    // Unset climb bool if can't climb anymore
    //    else if (!canClimb)
    //        isClimbing = false;

    //    // Makes character jump while input is pressed & grounded or climbing
    //    if (jumpInput && canMove)
    //    {
    //        if (isGrounded || isClimbing || (Time.time - coyoteVar < controllerValues.JumpDelay))
    //            Jump();
    //        else
    //            jumpBufferVar = Time.time;
    //    }

    //    // Calculate jump height value
    //    if (isJumping)
    //    {
    //        // Stop the jump if input is released & peak of jump icn't reached yet
    //        if (!jumpInput && jumpVar < .3f)
    //        {
    //            jumpOriginHeight -= (controllerValues.JumpCurve.Evaluate(.3f) - controllerValues.JumpCurve.Evaluate(jumpVar)) / (halfSpeed ? 2 : 1);
    //            jumpVar = .3f;
    //        }
    //        // Get the value corresponding to the curve set
    //        else
    //        {
    //            jumpVar += Time.deltaTime;

    //            // Stop jump if peak reached
    //            if (jumpVar > controllerValues.JumpCurve[controllerValues.JumpCurve.length - 1].time)
    //            {
    //                jumpVar = controllerValues.JumpCurve[controllerValues.JumpCurve.length - 1].time;
    //                StopJump();
    //            }

    //            AddVerticalMovement((jumpOriginHeight + (controllerValues.JumpCurve.Evaluate(jumpVar) / (halfSpeed ? 2 : 1)) - Physic.position.y) / Time.deltaTime);
    //        }
    //    }
    //    else if (!isClimbing && !IsOnMovingPlateform)
    //        ApplyGravity();


    //    if ((force + instantForce + movement) != Vector2.zero)
    //    {
    //        Vector2 _pos = Physic.position;

    //        // Push/pull grabbed object if there is any
    //        if (grabbedObject && grabbedObject.GetComponent<WSB_Movable>())
    //            grabbedObject.GetComponent<WSB_Movable>().AddInstantForce(GetVeloctity());

    //        ComputeVelocity();
    //        CalculCollision();
    //        RefreshPosition();

    //        OnAppliedVelocity(Physic.position - _pos);

    //        instantForce = movement = Vector2.zero;

    //    }
    //    else
    //        OnAppliedVelocity(Vector2.zero);

    //    // Drop grabbedObject if distance is too big
    //    if (grabbedObject)
    //    {
    //        if (!isGrounded || Vector2.Distance(grabbedObject.transform.position, transform.position) > 2)
    //            grabbedObject = null;
    //    }
    //}

    //#endregion

    //#region Input Reading

    //[SerializeField] float xMovement = 0;
    //[SerializeField] float yMovement = 0;
    //[SerializeField] GameObject grabbedObject = null;
    //[SerializeField] ContactFilter2D grabContactFilter = new ContactFilter2D();

    //// Reads x & y movement and sets it in xMovement & yMovement
    //public void Move(InputAction.CallbackContext _context)
    //{
    //    if (WSB_GameManager.Paused)
    //        return;
    //    if (_context.valueType != typeof(Vector2)) return;
    //    xMovement = _context.ReadValue<Vector2>().x;
    //    if (xMovement < 0)
    //        isRight = false;
    //    if (xMovement > 0)
    //        isRight = true;
    //    spriteRend.flipX = !isRight;
    //    yMovement = _context.ReadValue<Vector2>().y;
    //}

    //// Reads jump input and sets it in jumpInput
    //public void Jump(InputAction.CallbackContext _context)
    //{
    //    if (WSB_GameManager.Paused/* || IsDialogue*/)
    //        return;
    //    if (_context.valueType == typeof(float))
    //        jumpInput = _context.ReadValue<float>() == 1;
    //}

    //// Reads grab input and try to grab object
    //public void GrabObject(InputAction.CallbackContext _context)
    //{
    //    // Drop object if input canceled
    //    if (_context.canceled && grabbedObject)
    //        grabbedObject = null;

    //    else if (_context.started && !grabbedObject)
    //    {
    //        RaycastHit2D[] _hit = new RaycastHit2D[1];

    //        // Cast on facing direction to check if there is an object
    //        if (Collider.Cast(isRight ? Vector2.right : Vector2.left, grabContactFilter, _hit, .8f) > 0)
    //        {
    //            if (_hit[0].transform.GetComponent<WSB_Movable>() && !_hit[0].transform.GetComponent<WSB_Movable>().CanMove)
    //                return;
    //            // Search for WSB_Pot component
    //            if (_hit[0].transform.GetComponent<WSB_Pot>())
    //                // Breaks seed if pot found & not Carnivore or Trampoline seed
    //                if(_hit[0].transform.childCount > 0 && _hit[0].transform.GetChild(0).tag != "Carnivore" && _hit[0].transform.GetChild(0).tag != "Trampoline")
    //                    _hit[0].transform.GetComponent<WSB_Pot>().BreakSeed();

    //            // Sets grabbedObject var
    //            grabbedObject = _hit[0].transform.gameObject;
    //        }
    //    }
    //}

    //// Virtual method
    //public virtual void UseSpell(string _s)
    //{
    //    // Stops if grabbedObject
    //    if (grabbedObject)
    //        return;
    //}

    //// Virtual method
    //public virtual void StopSpell()
    //{
    //    // Stops if grabbedObject
    //    if (grabbedObject)
    //        return;
    //}

    //// Set canClimb bool
    //public void CanClimb(bool _s) => canClimb = _s;

    //#endregion

    //#region Controller

    //[SerializeField] SO_ControllerValues controllerValues = null;

    //[SerializeField] Vector2 force = Vector2.zero;
    //[SerializeField] Vector2 instantForce = Vector2.zero;
    //[SerializeField] Vector2 movement = Vector2.zero;

    //[SerializeField] float speed = 5;
    //[SerializeField] Vector2 groundNormal = new Vector2();

    //[SerializeField] protected bool isGrounded = false;
    //[SerializeField] bool isJumping = false;
    //[SerializeField] bool isClimbing = false;
    //[SerializeField] bool canClimb = false;
    //public bool IsOnMovingPlateform = false;
    //[SerializeField] protected bool canMove = true;

    //void OnAppliedVelocity(Vector2 _velocity)
    //{
    //    if (isJumping)
    //        jumpOriginHeight += _velocity.y - (movement.y * Time.deltaTime);
    //}

    //// Reduce x force based on Deceleration
    //void ComputeVelocity()
    //{
    //    if (force.x != 0)
    //        force.x = Mathf.MoveTowards(force.x, 0, controllerValues.Deceleration * Time.deltaTime);
    //}

    //// Refresh Physic position
    //void RefreshPosition()
    //{
    //    // Cast collider around itself
    //    int _amount = Collider.OverlapCollider(controllerValues.Contact, overlapBuffer);

    //    // Loop through colliders found
    //    for (int i = 0; i < _amount; i++)
    //    {
    //        // Skips this collider if tagged as ignored
    //        if (overlapBuffer[i] == ignoredCollider)
    //            continue;

    //        StopJump();

    //        // Push out Physic position from the collider
    //        ColliderDistance2D _distance = Collider.Distance(overlapBuffer[i]);
    //        if (_distance.isValid && _distance.isOverlapped && ((castBuffer.Length > i && castBuffer[i].transform && castBuffer[i].transform.gameObject && castBuffer[i].transform.gameObject.layer != 13) || _distance.normal.y == -1))
    //        {
    //            Physic.position += _distance.normal * _distance.distance;
    //        }
    //    }
    //}


    //#region Jump

    //[SerializeField] bool jumpInput = false;
    //[SerializeField] ContactFilter2D semiSolidFilter = new ContactFilter2D();

    //float jumpVar = 0;
    //float jumpOriginHeight = 0;
    //float coyoteVar = -999;
    //float jumpBufferVar = -999;

    //// Makes the character jump
    //void Jump()
    //{
    //    // Checks if input was in direction of the ground
    //    if(yMovement < 0)
    //    {
    //        // Cast below character to found if there is any SemiSolid plateform
    //        RaycastHit2D[] _hits = new RaycastHit2D[1];
    //        if (Collider.Cast(Vector3.down, semiSolidFilter, _hits) > 0)
    //        {
    //            // If found set collider in ignoredCollider and don't do the jump
    //            ignoredCollider = _hits[0].collider;
    //            Physic.position -= Vector2.up * .1f;
    //            return;
    //        }
    //    }

    //    isJumping = true;

    //    jumpVar = force.y = 0;

    //    // Set originHeight for jump curve calculs
    //    jumpOriginHeight = transform.position.y;

    //    // Reset coyoteVar to unobtainable number
    //    coyoteVar = -999;
    //}

    //protected void StopJump() => isJumping = false;

    //public void TrampolineJump(Vector2 _f)
    //{
    //    force.y = 0;
    //    AddForce(_f);
    //}
    //#endregion


    //#region Collision

    //private static int bufferAmount = 0;
    //private static readonly RaycastHit2D[] buffer = new RaycastHit2D[4];
    //private static readonly RaycastHit2D[] castBuffer = new RaycastHit2D[4];
    //private static readonly Collider2D[] overlapBuffer = new Collider2D[4];

    //// Main collision method
    //void CalculCollision()
    //{
    //    Vector2 _velocity = GetVeloctity();

    //    if (isGrounded)
    //    {
    //        // Rotates _velocity such as it behaves on the normal flat surface
    //        Vector2 _x = Vector2.Perpendicular(groundNormal);
    //        if (_x.x < 0)
    //            _x *= -1;

    //        _x *= _velocity.x;
    //        Vector2 _y = (_velocity.y < 0 ? groundNormal : Vector2.up) * _velocity.y;

    //        _velocity = _x + _y;
    //    }

    //    bufferAmount = 0;

    //    CalculCollisionRecursively(_velocity, groundNormal);

    //    bool _isGrounded = false;

    //    for (int i = 0; i < bufferAmount; i++)
    //    {
    //        if (force != Vector2.zero)
    //            force -= castBuffer[i].normal * Vector2.Dot(force, castBuffer[i].normal);

    //        if (isJumping && castBuffer[i].normal.y == -1)
    //        {
    //            StopJump();
    //            groundNormal = castBuffer[i].normal;
    //        }

    //        if (!_isGrounded && (castBuffer[i].normal.y > controllerValues.GroundMin))
    //        {
    //            _isGrounded = true;
    //            groundNormal = castBuffer[i].normal;
    //        }
    //    }

    //    if (!_isGrounded)
    //    {
    //        _isGrounded = (CastCollider(Vector2.down * Physics2D.defaultContactOffset * 2, out RaycastHit2D _hit) && (_hit.normal.y > controllerValues.GroundMin) && _hit.collider != ignoredCollider) || IsOnMovingPlateform;
    //        groundNormal = _isGrounded ? _hit.normal : Vector2.up;
    //    }

    //    if (_isGrounded)
    //        force.y = 0;

    //    if (_isGrounded != isGrounded)
    //        OnSetGrounded(_isGrounded);
    //}

    //void CalculCollisionRecursively(Vector2 _velocity, Vector2 _normal, int _iteration = 0)
    //{
    //    int _amount = CastCollider(_velocity, out float _distance);

    //    if (_distance == 0)
    //        return;

    //    if (_amount == 0)
    //    {
    //        Physic.position += _velocity;
    //        GroundSnap(_velocity, _normal);
    //        return;
    //    }

    //    if ((_distance -= Physics2D.defaultContactOffset) > 0)
    //    {
    //        Vector2 _normalizedVelocity = _velocity.normalized;

    //        Physic.position += _normalizedVelocity * _distance;
    //        _velocity = _normalizedVelocity * (_velocity.magnitude - _distance);
    //    }

    //    InsertCastBuffer(_amount);

    //    if (_iteration > 3)
    //    {
    //        GroundSnap(_velocity, _normal);
    //        return;
    //    }


    //    if (_normal.y != 1)
    //        _velocity = Quaternion.FromToRotation(_normal, Vector3.up) * _velocity;

    //    ClimbStep(ref _velocity, buffer[0]);

    //    Vector2 _hitNormal = castBuffer[0].normal;
    //    _velocity -= _hitNormal * Vector2.Dot(_velocity, _hitNormal);

    //    if (_velocity != Vector2.zero)
    //        CalculCollisionRecursively(_velocity, Vector2.zero, _iteration + 1);


    //}
    //void InsertCastBuffer(int _amount)
    //{
    //    if (bufferAmount < buffer.Length)
    //    {
    //        for (int i = 0; i < _amount; i++)
    //        {
    //            buffer[bufferAmount + i] = castBuffer[i];
    //            bufferAmount++;

    //            if (bufferAmount == buffer.Length)
    //                return;
    //        }
    //    }
    //    else
    //        buffer[bufferAmount - 1] = castBuffer[0];
    //}

    //bool CastCollider(Vector2 _velocity, out RaycastHit2D _hit)
    //{
    //    bool _return = (Collider.Cast(_velocity, controllerValues.Contact, castBuffer, _velocity.magnitude) > 0) /*&& (castBuffer[0].transform.gameObject.layer != 13 && castBuffer[0].normal.y != -1)*/;
    //    _hit = castBuffer[0];
    //    if(_return) 
    //        _return = _hit.collider != ignoredCollider;
    //    return _return;
    //}

    //[SerializeField] Collider2D ignoredCollider = null;

    //int CastCollider(Vector2 _velocity, out float _distance)
    //{
    //    _distance = _velocity.magnitude;
    //    int _amount = Collider.Cast(_velocity, controllerValues.Contact, castBuffer, _distance);

    //    if (_amount == 0)
    //        ignoredCollider = null;

    //    for (int i = 0; i < _amount; i++)
    //    {
    //        if ((castBuffer[i].transform.gameObject.layer == 13) && castBuffer[i].normal.y == -1 ||
    //            (castBuffer[i].transform.gameObject.layer == 13) && castBuffer[i] == ignoredCollider ||
    //            IsOnMovingPlateform && transform.position.y > castBuffer[i].collider.transform.position.y)
    //        {
    //            ignoredCollider = castBuffer[i].collider;
    //            _amount = i;
    //            break;
    //        }
    //        if (castBuffer[i].transform.gameObject.layer != 13)
    //            ignoredCollider = null;
    //    }

    //    if (_amount > 0)
    //    {
    //        _distance = Mathf.Max(0, castBuffer[0].distance - Physics2D.defaultContactOffset);
    //        for (int i = 1; i < _amount; i++)
    //        {
    //            if ((castBuffer[i].distance + .001f) > castBuffer[0].distance)
    //                return i;
    //        }
    //    }
    //    return _amount;
    //}

    //#endregion


    //#region Physic

    //void ApplyGravity() => AddForce((Physics2D.gravity * 2) * Time.deltaTime);

    //void OnSetGrounded(bool _isGrounded)
    //{
    //    isGrounded = _isGrounded;

    //    if (_isGrounded)
    //    {
    //        if (ignoredCollider)
    //            ignoredCollider = null;
    //        if (Time.time - jumpBufferVar < controllerValues.JumpBufferDelay)
    //            Jump();
    //    }
    //    else
    //        coyoteVar = Time.time;
    //}

    //void ClimbStep(ref Vector2 _velocity, RaycastHit2D _hit)
    //{
    //    if (_velocity.x == 0 || _hit.normal.y > controllerValues.GroundMin)
    //        return;
    //    Physic.position += new Vector2(0, controllerValues.MaxHeightClimb);
    //    _velocity.y -= controllerValues.MaxHeightClimb;

    //    int _amount = CastCollider(_velocity, out float _distance);

    //    if (_amount == 0)
    //    {
    //        Physic.position += _velocity;
    //        _velocity.Set(0, 0);
    //    }
    //    else if (_distance != 0 && ((_hit.collider != castBuffer[0].collider) || (_hit.normal != castBuffer[0].normal)))
    //    {
    //        Vector2 _normalized = _velocity.normalized;
    //        Physic.position += _normalized * _distance;
    //        _velocity = _normalized * (_velocity.magnitude - _distance);

    //        InsertCastBuffer(_amount);
    //    }
    //    else
    //    {
    //        Physic.position -= new Vector2(0, controllerValues.MaxHeightClimb);
    //        _velocity.y += controllerValues.MaxHeightClimb;
    //        _velocity.x = 0;
    //    }
    //}

    //void GroundSnap(Vector2 _velocity, Vector2 _normal)
    //{
    //    if (_normal.y != 1)
    //        _velocity = Quaternion.FromToRotation(_normal, Vector3.up) * _velocity;

    //    if (isGrounded && (_velocity.y < 0) && CastCollider(_normal * -1, out RaycastHit2D _snapHit))
    //    {
    //        Physic.position += _normal * -_snapHit.distance;
    //        InsertCastBuffer(1);
    //    }
    //}

    //#endregion


    //#region AddForces

    //float 所有 = 0;
    //protected bool halfSpeed = false;

    //public void AddForce(Vector2 _force) => force += _force;

    //void AddVerticalMovement(float _velocity) => movement.y += _velocity;

    //void AddHorizontalMovement(float _velocity)
    //{
    //    if (_velocity == 0)
    //    {
    //        所有 = speed = 0;
    //        return;
    //    }

    //    所有 = Mathf.Min(所有 + Time.deltaTime, controllerValues.SpeedCurve[controllerValues.SpeedCurve.length - 1].time);
    //    speed = controllerValues.SpeedCurve.Evaluate(所有);

    //    movement.x += (_velocity * speed) / (halfSpeed ? 2 : 1);
    //}

    //public void AddInstantForce(Vector2 _velocity) => instantForce += _velocity;

    //#endregion

    //Vector2 GetVeloctity() => ((force + movement) * Time.deltaTime) + instantForce * controllerValues.SpeedCoef;

    //#endregion

    float jumpOriginHeight = 0;
    [SerializeField] protected bool canMove = true;

    public override void Update()
    {
        MoveHorizontally(xMovement);

        playerAnimator.SetFloat("Run", speed / movableValues.SpeedCurve.Evaluate(movableValues.SpeedCurve[movableValues.SpeedCurve.length - 1].time));

        if (IsGrounded)
        {
            jumpVar = force.y = 0;
            jumpOriginHeight = transform.position.y;
            if (jumpInput && canMove)
                if(IsGrounded || (Time.time - coyoteVar < controllerValues.JumpDelay))
                    Jump();
        }
        if (isJumping)
        {
            // Stop the jump if input is released & peak of jump icn't reached yet
            if (!jumpInput && jumpVar < .3f)
            {
                jumpOriginHeight -= (controllerValues.JumpCurve.Evaluate(.3f) - controllerValues.JumpCurve.Evaluate(jumpVar));
                jumpVar = .3f;
            }
            // Get the value corresponding to the curve set
            else
            {
                jumpVar += Time.deltaTime;

                // Stop jump if peak reached
                if (jumpVar > controllerValues.JumpCurve[controllerValues.JumpCurve.length - 1].time)
                {
                    jumpVar = controllerValues.JumpCurve[controllerValues.JumpCurve.length - 1].time;
                    isJumping = false;
                }

                MoveVertically((jumpOriginHeight + (controllerValues.JumpCurve.Evaluate(jumpVar)) - rigidbody.position.y) / Time.deltaTime);
            }
        }

        base.Update();
    }

    [SerializeField] float xMovement = 0;
    [SerializeField] float yMovement = 0;
    [SerializeField] bool jumpInput = false;
    [SerializeField] SO_ControllerValues controllerValues = null;
    [SerializeField] GameObject render = null;
    [SerializeField] Animator playerAnimator = null;
    protected bool isRight = true;

    // Reads x & y movement and sets it in xMovement & yMovement
    public void Move(InputAction.CallbackContext _context)
    {
        if (_context.valueType != typeof(Vector2)) return;
        xMovement = _context.ReadValue<Vector2>().x;
        yMovement = _context.ReadValue<Vector2>().y;
        if (xMovement != 0)
            render.transform.eulerAngles = new Vector3(render.transform.eulerAngles.x, xMovement < 0 ? -90 : 90, render.transform.eulerAngles.z);
    }

    // Reads jump input and sets it in jumpInput
    public void Jump(InputAction.CallbackContext _context)
    {
        if (_context.valueType == typeof(float))
            jumpInput = _context.ReadValue<float>() == 1;
    }


    [SerializeField] GameObject grabbedObject = null;
    [SerializeField] ContactFilter2D grabContactFilter = new ContactFilter2D();
    // Reads grab input and try to grab object
    public void GrabObject(InputAction.CallbackContext _context)
    {
        // Drop object if input canceled
        if (_context.canceled && grabbedObject)
            grabbedObject = null;

        else if (_context.started && !grabbedObject)
        {
            RaycastHit2D[] _hit = new RaycastHit2D[1];

            // Cast on facing direction to check if there is an object
            if (collider.Cast(isRight ? Vector2.right : Vector2.left, grabContactFilter, _hit, .8f) > 0)
            {
                if (_hit[0].transform.GetComponent<WSB_Movable>() && !_hit[0].transform.GetComponent<WSB_Movable>().CanMove)
                    return;
                // Search for WSB_Pot component
                if (_hit[0].transform.GetComponent<WSB_Pot>())
                    // Breaks seed if pot found & not Carnivore or Trampoline seed
                    if (_hit[0].transform.childCount > 0 && _hit[0].transform.GetChild(0).tag != "Carnivore" && _hit[0].transform.GetChild(0).tag != "Trampoline")
                        _hit[0].transform.GetComponent<WSB_Pot>().BreakSeed();

                // Sets grabbedObject var
                grabbedObject = _hit[0].transform.gameObject;
            }
        }
    }

    // Virtual method
    public virtual void UseSpell(string _s)
    {
        // Stops if grabbedObject
        if (grabbedObject)
            return;
    }

    // Virtual method
    public virtual void StopSpell()
    {
        // Stops if grabbedObject
        if (grabbedObject)
            return;
    }
    float coyoteVar = -999;
    float jumpBufferVar = -999;

    // Makes the character jump
    void Jump()
    {
        // Checks if input was in direction of the ground
        if (yMovement < 0)
        {
            // Cast below character to found if there is any SemiSolid plateform
            RaycastHit2D[] _hits = new RaycastHit2D[1];
            if (collider.Cast(Vector3.down, movableValues.SemisolidFilter, _hits) > 0)
            {

                // If found set collider in ignoredCollider and don't do the jump
                semiSolidCollider = _hits[0].collider;
                rigidbody.position -= Vector2.up * .1f;
                return;
            }
        }

        isJumping = true;

        jumpVar = force.y = 0;

        // Set originHeight for jump curve calculs
        jumpOriginHeight = transform.position.y;

        // Reset coyoteVar to unobtainable number
        coyoteVar = -999;
    }
    protected void StopJump() => isJumping = false;

    public void TrampolineJump(Vector2 _f)
    {
        force.y = 0;
        AddForce(_f);
    }
}
