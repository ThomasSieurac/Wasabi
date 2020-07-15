using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam : MonoBehaviour
{
    [SerializeField] CamType currentCamType = CamType.Dynamic;

    [SerializeField] Camera cam = null;

    [SerializeField] Transform ban = null;
    [SerializeField] Transform lux = null;

    [SerializeField] SecondCam camBan = null;
    [SerializeField] SecondCam camLux = null;

    [SerializeField] float camMoveSpeed = 2;
    [SerializeField] float camZoomSpeed = 2;

    [SerializeField] float minCamZoom = 5;
    [SerializeField] float maxCamZoom = 10;

    [SerializeField] GameObject split = null;


    private void Start()
    {
        if (!cam) cam = Camera.main;
    }

    private void LateUpdate()
    {
        switch (currentCamType)
        {
            case CamType.Dynamic: Dynamic();
                break;
            case CamType.SplitFixe:
                Split();
                camBan.FollowCharacter();
                camLux.FollowCharacter();
                break;
            case CamType.SplitDynamic:
                Split();
                camBan.FollowCharacter();
                camLux.FollowCharacter();
                break;
        }
    }

    public void SwitchCamType(CamType _t) // Dynamic && SplitDynamic
    {
        StopAllCoroutines();
        currentCamType = _t;
        if(_t == CamType.SplitDynamic)
        {
            cam.enabled = false;
            camLux.GetComponent<Camera>().enabled = true;
            camBan.GetComponent<Camera>().enabled = true;
        }
        else if (_t == CamType.Dynamic)
        {
            cam.enabled = true;
            camLux.GetComponent<Camera>().enabled = false;
            camBan.GetComponent<Camera>().enabled = false;
        }
    }
    public void SwitchCamType(CamType _t, float _angle) // SplitFixe
    {
        StopAllCoroutines();
        currentCamType = _t;
        cam.enabled = false;
        camLux.GetComponent<Camera>().enabled = true;
        camBan.GetComponent<Camera>().enabled = true;
    }
    #region Fixe
    public void SwitchCamType(CamType _t, Vector2 _position, float _size)
    {
        StopAllCoroutines();
        currentCamType = _t;
        cam.enabled = true;
        camLux.GetComponent<Camera>().enabled = false;
        camBan.GetComponent<Camera>().enabled = false;
        StartCoroutine(MoveFixeCam(_position, _size));
    }
    IEnumerator MoveFixeCam(Vector2 _position, float _size)
    {
        while(Vector3.Distance(transform.position, _position) != 0 || cam.orthographicSize != _size)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(_position.x, _position.y, transform.position.z), Time.deltaTime * camMoveSpeed);
            cam.orthographicSize = Mathf.MoveTowards(cam.orthographicSize, _size, Time.deltaTime * camZoomSpeed);
            yield return new WaitForSeconds(.01f);
        }
    }
    #endregion

    void Dynamic()
    {
        if (!ban || !lux || !cam) return;
        Vector3 _dir = ban.position - lux.position;
        float _dist = Vector2.Distance(ban.position, lux.position);
        transform.position = new Vector3(ban.position.x, ban.position.y, transform.position.z) - _dir / 2;
        if (_dist < minCamZoom) cam.orthographicSize = minCamZoom;
        else if (_dist > maxCamZoom) SwitchCamType(CamType.SplitDynamic);
        else cam.orthographicSize = _dist;
    }

    void Split()
    {
        if (!ban || !lux) return;
        if (Vector2.Distance(ban.position, lux.position) < maxCamZoom) SwitchCamType(CamType.Dynamic);
        Vector3 _dir = lux.position - ban.position;
        float _angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
        split.transform.eulerAngles = new Vector3(0, 0, _angle - 90);
        camBan.transform.eulerAngles = new Vector3(0, 0, _angle + 90);
    }

}

public enum CamType
{
    Fixe,
    Dynamic,
    SplitFixe,
    SplitDynamic
}