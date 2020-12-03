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
            while (WSB_PlayTestManager.Paused)
            {
                yield return new WaitForSeconds(.2f);
            }
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

    public void SetInstantCam(Vector3 _pos)
    {
        transform.position = _pos;
    }

    IEnumerator MoveCam(Vector2 _pos, float _zoom)
    {
        while (Vector2.Distance(transform.position, _pos) != 0 || Cam.orthographicSize != _zoom)
        {
            while (WSB_PlayTestManager.Paused)
            {
                yield return new WaitForSeconds(.2f);
            }
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(_pos.x, _pos.y, transform.position.z), Time.time * WSB_CameraManager.I.CamMoveSpeed);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator MoveCam(Vector3 _pos)
    {
        while (Vector3.Distance(transform.position, _pos) != 0)
        {
            while (WSB_PlayTestManager.Paused)
            {
                yield return new WaitForSeconds(.2f);
            }
            transform.position = new Vector3(
                Mathf.MoveTowards(transform.position.x, _pos.x, Time.time * WSB_CameraManager.I.CamMoveSpeed),
                Mathf.MoveTowards(transform.position.y, _pos.y, Time.time * WSB_CameraManager.I.CamMoveSpeed),
                Mathf.MoveTowards(transform.position.z, _pos.z, Time.time * WSB_CameraManager.I.CamZoomSpeed));
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator MoveCam(Vector3 _pos, bool _needCallBack)
    {
        while (Vector2.Distance(transform.position, _pos) != 0)
        {
            while (WSB_PlayTestManager.Paused)
            {
                yield return new WaitForSeconds(.2f);
            }
            transform.position = new Vector3(
                Mathf.MoveTowards(transform.position.x, _pos.x, Time.time * WSB_CameraManager.I.CamMoveSpeed),
                Mathf.MoveTowards(transform.position.y, _pos.y, Time.time * WSB_CameraManager.I.CamMoveSpeed),
                Mathf.MoveTowards(transform.position.z, _pos.z, Time.time * WSB_CameraManager.I.CamZoomSpeed));
            yield return new WaitForEndOfFrame();
        }
        if (_needCallBack) WSB_CameraManager.I.SwitchCamType(CamType.Dynamic, transform.position);
    }

}
