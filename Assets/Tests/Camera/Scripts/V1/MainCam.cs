using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCam : MonoBehaviour
{
    [SerializeField] CamType currentCamType = CamType.Dynamic;

    [SerializeField] RenderTexture cam2RenderTexture = null;
    [SerializeField] Material readMaterial = null;

    [SerializeField] Camera cam = null;

    [SerializeField] Transform ban = null;
    [SerializeField] Transform lux = null;

    [SerializeField] Camera camBan = null;

    [SerializeField] float camMoveSpeed = 2;
    [SerializeField] float camZoomSpeed = 2;

    [SerializeField] float minCamZoom = 5;
    [SerializeField] float maxCamZoom = 10;

    [SerializeField] RawImage render = null;
    [SerializeField] GameObject split = null;
    [SerializeField] GameObject bigSplit = null;

    [SerializeField] float splitAngle = 0;

    public bool IsOrtho { get { return cam.orthographic; } }



    private void Start()
    {
        if (!cam) cam = Camera.main;
        SetResolution();
    }

    private void LateUpdate()
    {
        switch (currentCamType)
        {
            case CamType.Dynamic: Dynamic();
                break;
            case CamType.SplitFixe:
                split.transform.eulerAngles = new Vector3(0, 0, splitAngle - 90);
                camBan.transform.position = new Vector3(ban.position.x, ban.position.y, transform.position.z);
                transform.position = new Vector3(lux.position.x, lux.position.y, transform.position.z);
                break;
            case CamType.SplitDynamic:
                Split();
                break;
        }
    }


    
    void SetResolution()
    {
        int _width = Screen.width;
        int _height = Screen.height;


        if(cam2RenderTexture.width != _width || cam2RenderTexture.height != _height)
        {
            cam2RenderTexture.Release();
            cam2RenderTexture.Create();
            cam2RenderTexture = new RenderTexture(_width, _height, 24);
            camBan.targetTexture = cam2RenderTexture;
            readMaterial.SetTexture("TexBanCam", cam2RenderTexture);
            render.texture = cam2RenderTexture;
            render.material = readMaterial;
        }
    }

    public void SwitchCamType(CamType _t) // Dynamic && SplitDynamic
    {
        StopAllCoroutines();
        currentCamType = _t;
        if (_t == CamType.SplitDynamic)
        {
            // persp
            cam.orthographicSize = maxCamZoom;
            bigSplit.SetActive(true);
        }
        else if (_t == CamType.Dynamic)
        {
            bigSplit.SetActive(false);
        }
    }
    public void SwitchCamType(CamType _t, float _angle) // SplitFixe
    {
        bigSplit.SetActive(true);
        StopAllCoroutines();
        currentCamType = _t;
    }
    public void SwitchCamType(CamType _t, Vector2 _position, float _size)
    {
        bigSplit.SetActive(false);
        StopAllCoroutines();
        currentCamType = _t;
        StartCoroutine(MoveFixeCam(_position, _size));
    }

    IEnumerator MoveFixeCam(Vector2 _position, float _size)
    {
        while(Vector3.Distance(transform.position, _position) != 0 || /* persp */ cam.orthographicSize != _size)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(_position.x, _position.y, transform.position.z), Time.deltaTime * camMoveSpeed);
            // persp
            cam.orthographicSize = Mathf.MoveTowards(cam.orthographicSize, _size, Time.deltaTime * camZoomSpeed);
            yield return new WaitForSeconds(.01f);
        }
    }


    void Dynamic()
    {
        if (!ban || !lux || !cam) return;
        camBan.transform.position = transform.position;
        Vector3 _dir = ban.position - lux.position;
        float _dist = Vector2.Distance(ban.position, lux.position);
        transform.position = new Vector3(ban.position.x, ban.position.y, transform.position.z) - _dir / 2;
        // persp
        if (_dist < minCamZoom) cam.orthographicSize = minCamZoom;
        else if (_dist > maxCamZoom) SwitchCamType(CamType.SplitDynamic);
        else cam.orthographicSize = _dist;
        //
    }

    void Split()
    {
        if (!ban || !lux) return;
        float _dist = Vector2.Distance(ban.position, lux.position);
        Vector3 _dir = lux.position - ban.position;
        Vector3 _luxOffset = new Vector3(lux.position.x - (_dir.normalized.x * 10), lux.position.y - (_dir.normalized.y * 5), transform.position.z);
        Vector3 _banOffset = new Vector3(ban.position.x + (_dir.normalized.x * 10), ban.position.y + (_dir.normalized.y * 5), camBan.transform.position.z);
        // merge à faire
        if (_dist <= maxCamZoom * 1.5f)
        {
            if (_dist < maxCamZoom) SwitchCamType(CamType.Dynamic);

            Vector3 _dirOffset = _luxOffset - _banOffset;

            camBan.transform.position = _luxOffset - (_dirOffset * (_dist / (maxCamZoom * 1.5f)));
            camBan.transform.position = new Vector3(camBan.transform.position.x, camBan.transform.position.y, -10);

            transform.position = _banOffset + (_dirOffset * (_dist / (maxCamZoom * 1.5f)));
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);

        }
        //
        else
        {
            camBan.transform.position = _banOffset;
            transform.position = _luxOffset;
        }
        float _angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
        split.transform.eulerAngles = new Vector3(0, 0, _angle - 90);
    }



    /*
     * 
     * offset des deux joueurs      DONE
     * 
     * smooth split     DONE
     * 
     * résolutions      DONE
     * 
     * Gérer la cam en fonction d'ortho ou persp
     * 
     */
}

public enum CamType
{
    Fixe,
    Dynamic,
    SplitFixe,
    SplitDynamic
}
