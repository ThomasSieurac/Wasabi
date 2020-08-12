﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam : MonoBehaviour
{
    [SerializeField] CamType currentCamType = CamType.Dynamic;

    [SerializeField] Camera cam = null;

    [SerializeField] Transform ban = null;
    [SerializeField] Transform lux = null;

    [SerializeField] GameObject camBan = null;

    [SerializeField] float camMoveSpeed = 2;
    [SerializeField] float camZoomSpeed = 2;

    [SerializeField] float minCamZoom = 5;
    [SerializeField] float maxCamZoom = 10;

    [SerializeField] GameObject split = null;
    [SerializeField] GameObject bigSplit = null;

    [SerializeField] float splitAngle = 0;


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
                split.transform.eulerAngles = new Vector3(0, 0, splitAngle - 90);
                camBan.transform.position = new Vector3(ban.position.x, ban.position.y, transform.position.z);
                transform.position = new Vector3(lux.position.x, lux.position.y, transform.position.z);
                break;
            case CamType.SplitDynamic:
                Split();
                break;
        }
    }



    public void SwitchCamType(CamType _t) // Dynamic && SplitDynamic
    {
        StopAllCoroutines();
        currentCamType = _t;
        if (_t == CamType.SplitDynamic)
        {
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
        while(Vector3.Distance(transform.position, _position) != 0 || cam.orthographicSize != _size)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(_position.x, _position.y, transform.position.z), Time.deltaTime * camMoveSpeed);
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
        if (_dist < minCamZoom) cam.orthographicSize = minCamZoom;
        else if (_dist > maxCamZoom) SwitchCamType(CamType.SplitDynamic);
        else cam.orthographicSize = _dist;
    }

    void Split()
    {
        if (!ban || !lux) return;
        float _dist = Vector2.Distance(ban.position, lux.position);
        Vector3 _dir = lux.position - ban.position; // ban --> lux
        Vector3 _luxOffset = new Vector3(lux.position.x - (_dir.normalized.x * 10), lux.position.y - (_dir.normalized.y * 5), transform.position.z);
        Vector3 _banOffset = new Vector3(ban.position.x + (_dir.normalized.x * 10), ban.position.y + (_dir.normalized.y * 5), camBan.transform.position.z);
        if (_dist <= maxCamZoom * 1.5f)
        {
            float _normalizedDist = _dist / (maxCamZoom * 1.5f);
            Vector3 a = _luxOffset - transform.position;
            float magnitude = a.magnitude;
            transform.position = transform.position + a / magnitude * _normalizedDist;
        }
        else
        {
            camBan.transform.position = _banOffset;
            transform.position = _luxOffset;
        }
        if (Vector2.Distance(ban.position, lux.position) < maxCamZoom) SwitchCamType(CamType.Dynamic);
        float _angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
        split.transform.eulerAngles = new Vector3(0, 0, _angle - 90);
    }



    /*
     * 
     * offset des deux joueurs      DONE
     * 
     * smooth split avec movetowards    
     * 
     * résolutions
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
