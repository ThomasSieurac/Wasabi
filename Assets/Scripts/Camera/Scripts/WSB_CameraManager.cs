using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WSB_CameraManager : MonoBehaviour
{
    public static WSB_CameraManager I { get; private set; }


    [SerializeField] CamType currentCamType = CamType.Dynamic;
        public CamType CurrentCamType { get { return currentCamType; } }

    [SerializeField] Transform lux = null;
    [SerializeField] Transform ban = null;

    #region Cameras
    [SerializeField] bool isOrtho = false;
        public bool IsOrtho { get { return isOrtho; } }

    [SerializeField] WSB_Camera camLux = null;
    [SerializeField] WSB_Camera camBan = null;

    [SerializeField] float camMoveSpeed = 20;
    public float CamMoveSpeed { get { return camMoveSpeed; } }
    [SerializeField] float camZoomSpeed = 20;
    public float CamZoomSpeed { get { return camZoomSpeed; } }

    [SerializeField] float minCamZoom = 5;
    public float MinCamZoom { get { return minCamZoom; } }
    [SerializeField] float maxCamZoom = 10;
    public float MaxCamZoom { get { return maxCamZoom; } }
    #endregion

    #region Split
    [SerializeField] RenderTexture cam2RenderTexture = null;
    [SerializeField] Material readMaterial = null;
    [SerializeField] RawImage render = null;
    [SerializeField] GameObject split = null;
    [SerializeField] GameObject bigSplit = null;
    public float SplitAngle { get; private set; } = 0;
    #endregion

    WSB_TriggerCam lastTriggered = null;
    [SerializeField] Vector3 targetPositionCamBan = Vector3.zero;
    [SerializeField] Vector3 targetPositionCamLux = Vector3.zero;

    public bool IsReady => ban && lux && camBan && camLux && cam2RenderTexture && readMaterial && render && split && bigSplit;



    private void Awake()
    {
        I = this;
        if(FindObjectsOfType<WSB_CameraManager>().Length > 1)
        {
            Debug.LogError("Plusieurs component WSB_CameraManager sont présents dans la scène. Il ne doit y en avoir qu'un.");
            Destroy(this);
        }
    }

    private void Start()
    {
        if(!IsReady)
        {
            Debug.LogError("Erreur, paramètres manquant sur WSB_CameraManager");
            Destroy(this);
        }
        targetPositionCamBan = new Vector3(camBan.transform.position.x, camBan.transform.position.y, (isOrtho ? camBan.Cam.orthographicSize : camBan.transform.position.z));
        targetPositionCamLux = new Vector3(camLux.transform.position.x, camLux.transform.position.y, (isOrtho ? camLux.Cam.orthographicSize : camLux.transform.position.z));
        SetResolution();
    }

    public void LateUpdate()
    {
        if (!IsReady)
        {
            Debug.LogError("Erreur, paramètres manquant sur WSB_CameraManager");
            return;
        }
        switch (currentCamType)
        {
            case CamType.Dynamic:
                Dynamic();
                break;
            case CamType.SplitFixe:
                SplitFixe();
                break;
            case CamType.SplitDynamic:
                SplitDynamic();
                break;
        }
    }
    

    public void SetResolution()
    {
        int _width = Screen.width;
        int _height = Screen.height;

        camBan.Cam.orthographic = camLux.Cam.orthographic = IsOrtho;

        if (cam2RenderTexture.width != _width || cam2RenderTexture.height != _height)
        {
            cam2RenderTexture.Release();
            cam2RenderTexture.Create();
            cam2RenderTexture = new RenderTexture(_width, _height, 24);
            camBan.Cam.targetTexture = cam2RenderTexture;
            readMaterial.SetTexture("TexBanCam", cam2RenderTexture);
            render.texture = cam2RenderTexture;
            render.material = readMaterial;
        }
        ToggleSplit(!bigSplit.activeSelf);
        ToggleSplit(!bigSplit.activeSelf);
    }

    public void TriggerEntered(WSB_TriggerCam _trigger)
    {
        if (lastTriggered != _trigger)
        {
            if(lastTriggered) lastTriggered.gameObject.SetActive(true);
            _trigger.gameObject.SetActive(false);
            lastTriggered = _trigger;
        }
        if (!IsOrtho && camBan.Cam.fieldOfView != _trigger.FOV) camBan.SetFOV(_trigger.FOV);
        if (!IsOrtho && camLux.Cam.fieldOfView != _trigger.FOV) camLux.SetFOV(_trigger.FOV);
        switch (_trigger.Type)
        {
            case CamType.Fixe:
                SwitchCamType(CamType.Fixe, _trigger.Position, _trigger.Zoom);
                break;
            case CamType.Dynamic:
                SwitchCamType(CamType.Dynamic, _trigger.Position);
                break;
            case CamType.SplitFixe:
                SwitchCamType(CamType.SplitFixe, _trigger.Angle, IsOrtho ? _trigger.Zoom : _trigger.Position.z);
                break;
            case CamType.SplitDynamic:
                SwitchCamType(CamType.SplitDynamic, _trigger.Position);
                break;
        }
    }

    public void SwitchCamType(CamType _t, Vector3 _position)
    {
        if (_t != CamType.Dynamic && _t != CamType.SplitDynamic) return;
        targetPositionCamBan = new Vector3(targetPositionCamBan.x, targetPositionCamBan.y, _position.z);
        targetPositionCamLux = new Vector3(targetPositionCamLux.x, targetPositionCamLux.y, _position.z);
        currentCamType = _t;
        if(currentCamType == CamType.SplitDynamic) ToggleSplit(true);
        else if(currentCamType == CamType.Dynamic) ToggleSplit(false);
    } // Dynamic && SplitDynamic
    public void SwitchCamType(CamType _t, float _angle, float _zoom)
    {
        if (_t != CamType.SplitFixe) return;
        targetPositionCamBan = new Vector3(targetPositionCamBan.x, targetPositionCamBan.y, _zoom);
        targetPositionCamLux = new Vector3(targetPositionCamLux.x, targetPositionCamLux.y, _zoom);
        currentCamType = _t;
        SplitAngle = _angle;
        ToggleSplit(true);
    } // SplitFixe
    public void SwitchCamType(CamType _t, Vector3 _position, float _zoom)
    {
        if (_t != CamType.Fixe) return;
        currentCamType = _t;
        targetPositionCamBan = new Vector3(targetPositionCamBan.x, targetPositionCamBan.y, _position.z);
        targetPositionCamLux = new Vector3(targetPositionCamLux.x, targetPositionCamLux.y, _position.z);
        if (IsOrtho) camLux.SetCam((Vector2)_position, _zoom);
        else camLux.SetCam(_position);
        ToggleSplit(false);
    } // Fixe


    void Dynamic()
    {
        Vector3 _dir = ban.position - lux.position;
        float _dist = Vector2.Distance(ban.position, lux.position);
        float _zoom = 0;
        if(IsOrtho)
        {
            if (_dist < MinCamZoom) _zoom = MinCamZoom;
            else if (_dist > MaxCamZoom) SwitchCamType(CamType.SplitDynamic, new Vector3(camLux.transform.position.x, camLux.transform.position.y, camLux.Cam.orthographicSize));
            else _zoom = _dist;
            camLux.SetCam(new Vector2(lux.position.x, lux.position.y) + (Vector2)_dir / 2, _zoom);
            camBan.SetCam(camLux.transform.position, _zoom);
        }
        else
        {
            if (_dist < MinCamZoom) _zoom = -MinCamZoom;
            else if (_dist > MaxCamZoom) SwitchCamType(CamType.SplitDynamic, camLux.transform.position);
            else _zoom = -_dist * 2;
            camLux.SetCam(new Vector3(lux.position.x + _dir.x / 2, lux.position.y + _dir.y / 2, _zoom));
            camBan.SetCam(camLux.transform.position);
        }
    }
    void SplitFixe()
    {
        split.transform.eulerAngles = new Vector3(0, 0, SplitAngle - 90);
        Vector3 _dir = lux.position - ban.position;
        Vector3 _luxOffset = new Vector3(lux.position.x - (_dir.normalized.x * MaxCamZoom), lux.position.y - (_dir.normalized.y * MinCamZoom), camLux.transform.position.z);
        Vector3 _banOffset = new Vector3(ban.position.x + (_dir.normalized.x * MaxCamZoom), ban.position.y + (_dir.normalized.y * MinCamZoom), camBan.transform.position.z);
        if (IsOrtho)
        {
            camBan.SetCam((Vector2)_banOffset, targetPositionCamBan.z);
            camLux.SetCam((Vector2)_luxOffset, targetPositionCamLux.z);
        }
        else
        {
            camBan.SetCam(new Vector3(_banOffset.x, _banOffset.y, targetPositionCamBan.z));
            camLux.SetCam(new Vector3(_luxOffset.x, _luxOffset.y, targetPositionCamLux.z));
        }
    }
    void SplitDynamic()
    {
        float _dist = Vector2.Distance(ban.position, lux.position);
        Vector3 _dir = lux.position - ban.position;
        Vector3 _luxOffset = new Vector3(lux.position.x - (_dir.normalized.x * MaxCamZoom), lux.position.y - (_dir.normalized.y * MinCamZoom), camLux.transform.position.z);
        Vector3 _banOffset = new Vector3(ban.position.x + (_dir.normalized.x * MaxCamZoom), ban.position.y + (_dir.normalized.y * MinCamZoom), camBan.transform.position.z);
        if(_dist <= MaxCamZoom * 1.5f)
        {
            if (_dist < MaxCamZoom)
            {
                camBan.SetCam(camLux.transform.position, true);
                camLux.SetCam(camBan.transform.position, false);
                return;
            }

            Vector3 _dirOffset = _luxOffset - _banOffset;
            targetPositionCamBan = new Vector3(_luxOffset.x - (_dirOffset.x * (_dist / (maxCamZoom * 1.5f))), _luxOffset.y - (_dirOffset.y * (_dist /(maxCamZoom * 1.5f))), targetPositionCamBan.z);
            if(IsOrtho) camBan.SetCam(targetPositionCamBan, targetPositionCamBan.z);
            else camBan.SetCam(targetPositionCamBan);

            targetPositionCamLux = new Vector3(_banOffset.x + (_dirOffset.x * (_dist / (maxCamZoom * 1.5f))), _banOffset.y + (_dirOffset.y * (_dist /(maxCamZoom * 1.5f))), targetPositionCamLux.z);
            if(IsOrtho) camLux.SetCam(targetPositionCamLux, targetPositionCamLux.z);
            else camLux.SetCam(targetPositionCamLux);

        }
        else
        {
            if(isOrtho)
            {
                camBan.SetCam((Vector2)_banOffset, MaxCamZoom);
                camLux.SetCam((Vector2)_luxOffset, MaxCamZoom);
            }
            else
            {
                camBan.SetCam(new Vector3(_banOffset.x, _banOffset.y, targetPositionCamBan.z));
                camLux.SetCam(new Vector3(_luxOffset.x, _luxOffset.y, targetPositionCamLux.z));
            }
        }
        float _angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
        split.transform.eulerAngles = new Vector3(0, 0, _angle - 90);
    }

    void ToggleSplit(bool _status) => bigSplit.SetActive(_status);
}

public enum CamType
{
    Fixe,
    Dynamic,
    SplitFixe,
    SplitDynamic,
    None
}

