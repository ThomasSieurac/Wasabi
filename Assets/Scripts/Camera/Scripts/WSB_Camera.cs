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
        if (!cam) cam = GetComponent<Camera>();
        if (!cam)
        {
            Debug.LogError($"Pas de component Camera trouvé sur {transform.name}");
            Destroy(this);
        }
    }

    public void SetFOV(float _fov)
    {
        if (moveFOV != null) StopCoroutine(moveFOV);
        moveFOV = StartCoroutine(MoveFOV(_fov));
    }

    IEnumerator MoveFOV(float _fov)
    {
        while (Cam.fieldOfView != _fov)
        {
            Cam.fieldOfView = Mathf.MoveTowards(Cam.fieldOfView, _fov, Time.deltaTime * 2);
            yield return new WaitForEndOfFrame();
        }
    }


    public void SetCam(Vector2 _pos, float _zoom) // ortho
    {
        if ((Vector2)transform.position == _pos && Cam.orthographicSize == _zoom) return;
        if (moveCam != null) StopCoroutine(moveCam);
        moveCam = StartCoroutine(MoveCam(_pos, _zoom));
    }

    public void SetCam(Vector3 _pos) // persp
    {
        if (transform.position == _pos) return;
        if (moveCam != null) StopCoroutine(moveCam);
        moveCam = StartCoroutine(MoveCam(_pos));
    }

    public void SetCam(Vector3 _pos, bool _needCallBack)
    {
        if (transform.position == _pos)
        {
            if (_needCallBack) WSB_CameraManager.I.SwitchCamType(CamType.Dynamic, transform.position);
            return;
        }
        if (moveCam != null) StopCoroutine(moveCam);
        moveCam = StartCoroutine(MoveCam(_pos, _needCallBack));
    }

    IEnumerator MoveCam(Vector2 _pos, float _zoom)
    {
        while (Vector2.Distance(transform.position, _pos) != 0 || Cam.orthographicSize != _zoom)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(_pos.x, _pos.y, transform.position.z), Time.deltaTime * WSB_CameraManager.I.CamMoveSpeed);
            Cam.orthographicSize = Mathf.MoveTowards(Cam.orthographicSize, _zoom, Time.deltaTime * WSB_CameraManager.I.CamZoomSpeed);
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator MoveCam(Vector3 _pos)
    {
        while (Vector3.Distance(transform.position, _pos) != 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pos, Time.deltaTime * (WSB_CameraManager.I.CamMoveSpeed));
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator MoveCam(Vector3 _pos, bool _needCallBack)
    {
        while (Vector2.Distance(transform.position, _pos) != 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pos, Time.deltaTime * (WSB_CameraManager.I.CamMoveSpeed));
            yield return new WaitForFixedUpdate();
        }
        if (_needCallBack) WSB_CameraManager.I.SwitchCamType(CamType.Dynamic, transform.position);
    }

}