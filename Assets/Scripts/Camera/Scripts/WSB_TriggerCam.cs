using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSB_TriggerCam : MonoBehaviour
{
    [SerializeField] BoxCollider2D trigger = null;


    #region Trigger values
    [SerializeField, Min(.1f)] Vector2 triggerSize = Vector2.one;

    [Header("Camera mode"), SerializeField] CamType changeTypeTo = CamType.None;
        public CamType Type { get { return changeTypeTo; } }
    [Header("Camera position"), SerializeField] Vector3 changePositionTo = Vector3.zero;
        public Vector3 Position { get { return changePositionTo; } }
    [Header("Camera Zoom ORTHOGRAPHIC ONLY"), SerializeField] float changeZoomTo = 0;
        public float Zoom { get { return changeZoomTo; } }
    [Header("Camera FOV PERSPECTIVE ONLY"), SerializeField] float changeFOVTo = 0;
        public float FOV { get { return changeFOVTo; } }
    #endregion

    private void OnDrawGizmos()
    {
        switch (Type)
        {
            case CamType.Fixe:
                Gizmos.color = new Color(1, 0, 0, .4f);
                break;
            case CamType.Dynamic:
                Gizmos.color = new Color(0, 1, 0, .4f);
                break;
            case CamType.SplitFixe:
                Gizmos.color = new Color(1, 1, 0, .4f);
                break;
            case CamType.SplitDynamic:
                Gizmos.color = new Color(0, 1, 1, .4f);
                break;
            case CamType.None:
                Gizmos.color = new Color(.01f, .01f, .01f, .4f);
                break;
        }
        Gizmos.DrawCube(transform.position, new Vector3(triggerSize.x, triggerSize.y, 1));
    }

    private void Awake()
    {
        if (!trigger) trigger = GetComponent<BoxCollider2D>();
        if(!trigger)
        {
            Debug.LogError($"BoxCollider introuvable sur {transform.name}");
            Destroy(this);
        }
    }

    private void Start()
    {
        trigger.isTrigger = true;
        trigger.size = triggerSize;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //if(col.tag != "Player") // check tag ? check component ? check layer ? check other ?
    }



    /*
     * 
     * désactiver le trigger une fois activé
     * réactiver le trigger off sur le camManager
     * set le trigger sur le trigger off sur le camManager
     * 
     * 
     * changer le camtype (en debug faire la zone trigger d'une couleur en fonction de la camtype)
     * changer différents paramètres (fov, zoom, position, etc...)
     * 
     */


}
