using System.Collections;
using UnityEngine;

public class WSB_Camera : MonoBehaviour
{
    [SerializeField] Camera cam = null;
    public Camera Cam { get { return cam; } }

    Coroutine moveCam = null;
    Coroutine moveFOV = null;


    private void Awake()
    {
        // Check if all the needed components are here, throw error and destroy itself if not
        if (!cam) cam = GetComponent<Camera>();
        if (!cam)
        {
            Debug.LogError($"Pas de component Camera trouvé sur {transform.name}");
            Destroy(this);
        }
    }

    public void SetFOV(float _fov)
    {
        // Stop the moveFOV coroutine if it is already playing
        if (moveFOV != null)
            StopCoroutine(moveFOV);

        // Start and stock the moveFOV coroutine
        moveFOV = StartCoroutine(MoveFOV(_fov));
    }

    IEnumerator MoveFOV(float _fov)
    {
        // Loop until the fov of the camera correspond to the required fov
        while (Cam.fieldOfView != _fov)
        {
            // Hold if the game is paused
            while (WSB_GameManager.Paused)
            {
                yield return new WaitForSeconds(.2f);
            }

            Cam.fieldOfView = Mathf.MoveTowards(Cam.fieldOfView, _fov, Time.deltaTime * 2);

            yield return new WaitForEndOfFrame();
        }
    }


    public void SetCam(Vector2 _pos, float _zoom) // ortho
    {
        // Exit if the position and zoom are already set to the given position and zoom
        if ((Vector2)transform.position == _pos && Cam.orthographicSize == _zoom)
            return;

        // Stop the moveCam coroutine if it is already playing
        if (moveCam != null)
            StopCoroutine(moveCam);

        // Start and stock the correct moveCam coroutine
        moveCam = StartCoroutine(MoveCam(_pos, _zoom));
    }

    public void SetCam(Vector3 _pos, bool _needCallBack = false)
    {
        // Call the callback if the position is already set to the given position
        if (transform.position == _pos)
        {
            if (_needCallBack)
                WSB_CameraManager.I.SwitchCamType(CamType.Dynamic, transform.position);
            return;
        }

        // Stop the moveCam coroutine if it is already playing
        if (moveCam != null) 
            StopCoroutine(moveCam);

        // Start and stock the correct moveFOV coroutine
        moveCam = StartCoroutine(MoveCam(_pos, _needCallBack));
    }

    public void SetInstantCam(Vector3 _pos) => transform.position = _pos;

    IEnumerator MoveCam(Vector2 _pos, float _zoom)
    {
        // Loop until the position and fov of the camera correspond to the required position and fov
        while (Vector2.Distance(transform.position, _pos) != 0 || Cam.orthographicSize != _zoom)
        {
            // Hold if the game is paused
            while (WSB_GameManager.Paused)
            {
                yield return new WaitForSeconds(.2f);
            }

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(_pos.x, _pos.y, transform.position.z), Time.time * WSB_CameraManager.I.CamMoveSpeed);
            cam.orthographicSize = Mathf.MoveTowards(cam.orthographicSize, _zoom, Time.time * WSB_CameraManager.I.CamMoveSpeed);

            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator MoveCam(Vector3 _pos, bool _needCallBack)
    {
        // Loop until the position of the camera correspond to the required position
        while (Vector2.Distance(transform.position, _pos) != 0)
        {
            // Hold if the game is paused
            while (WSB_GameManager.Paused)
            {
                yield return new WaitForSeconds(.2f);
            }

            transform.position = new Vector3(
                Mathf.MoveTowards(transform.position.x, _pos.x, Time.time * WSB_CameraManager.I.CamMoveSpeed),
                Mathf.MoveTowards(transform.position.y, _pos.y, Time.time * WSB_CameraManager.I.CamMoveSpeed),
                Mathf.MoveTowards(transform.position.z, _pos.z, Time.time * WSB_CameraManager.I.CamZoomSpeed));

            yield return new WaitForEndOfFrame();
        }

        // Callback if needed
        if (_needCallBack)
            WSB_CameraManager.I.SwitchCamType(CamType.Dynamic, transform.position);
    }
}
