using System.Collections;
using UnityEngine;

public class WSB_Camera : MonoBehaviour
{
    [SerializeField] Camera cam = null;
    public Camera Cam { get { return cam; } }

    Coroutine moveCam = null;
    float lastTime = 0;

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

    public void SetCam(Vector2 _pos, float _zoom)
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
        while (Vector2.Distance(transform.position, _pos) > .5f || Cam.orthographicSize != _zoom)
        {
            // Hold if the game is paused
            while (WSB_GameManager.Paused)
            {
                yield return new WaitForSeconds(.2f);
            }

            transform.position = Vector3.Lerp(transform.position, new Vector3(_pos.x, _pos.y, transform.position.z), (Time.deltaTime * WSB_CameraManager.I.CamMoveSpeed) /*/ 500*/);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, _zoom, (Time.deltaTime * WSB_CameraManager.I.CamMoveSpeed) /*/ 500*/);

            yield return new WaitForEndOfFrame();

        }
    }

    IEnumerator MoveCam(Vector3 _pos, bool _needCallBack)
    {
        // Loop until the position of the camera correspond to the required position
        while (Vector2.Distance(transform.position, _pos) > .5f)
        {
            // Hold if the game is paused
            while (WSB_GameManager.Paused)
            {
                yield return new WaitForSeconds(.2f);
            }

            transform.position = new Vector3(
                Mathf.Lerp(transform.position.x, _pos.x, Time.deltaTime * WSB_CameraManager.I.CamMoveSpeed),
                Mathf.Lerp(transform.position.y, _pos.y, Time.deltaTime * WSB_CameraManager.I.CamMoveSpeed),
                transform.position.z);
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, -_pos.z, Time.deltaTime * WSB_CameraManager.I.CamMoveSpeed);

            yield return new WaitForEndOfFrame();
        }

        // Callback if needed
        if (_needCallBack)
            WSB_CameraManager.I.SwitchCamType(CamType.Dynamic, transform.position);
    }
}
