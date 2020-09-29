using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSB_Camera : MonoBehaviour
{
    [SerializeField] Camera cam = null;
        public Camera Cam { get { return cam; } }


    private void Awake()
    {
        if (!cam) cam = GetComponent<Camera>();
        if (!cam)
        {
            Debug.LogError($"Pas de component Camera trouvé sur {transform.name}");
            Destroy(this);
        }
    }

    public void SetCam(Vector2 _pos, float _zoom) // ortho
    {
        StopAllCoroutines();
        StartCoroutine(MoveCam(_pos, _zoom));
    }

    public void SetCam(Vector3 _pos) // persp
    {
        StopAllCoroutines();
        StartCoroutine(MoveCam(_pos));
    }

    IEnumerator MoveCam(Vector2 _pos, float _zoom)
    {
        while(true)
        {
            transform.position = Vector2.MoveTowards(transform.position, _pos, Time.deltaTime * WSB_CameraManager.I.CamMoveSpeed);
            Cam.orthographicSize = Mathf.MoveTowards(Cam.orthographicSize, _zoom, Time.deltaTime * WSB_CameraManager.I.CamZoomSpeed);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator MoveCam(Vector3 _pos)
    {
        while(true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pos, Time.deltaTime * WSB_CameraManager.I.CamMoveSpeed);
            yield return new WaitForEndOfFrame();
        }
    }

}