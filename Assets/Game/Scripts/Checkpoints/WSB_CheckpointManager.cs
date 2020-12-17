using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WSB_CheckpointManager : MonoBehaviour
{
    public static WSB_CheckpointManager I { get; private set; }

    [SerializeField] WSB_Checkpoint currentCheckpoint = null;


    private void Awake()
    {
        I = this;
    }

    public void SetNewCheckpoint(WSB_Checkpoint _cp)
    {
        currentCheckpoint = _cp;
    }

    public void RespawnBan(InputAction.CallbackContext _ctx)
    {
        // Only goes through when player has hold the button enough
        if (!_ctx.performed)
            return;

        Respawn(WSB_Ban.I);
    }

    public void RespawnLux(InputAction.CallbackContext _ctx)
    {
        // Only goes through when player has hold the button enough
        if (!_ctx.performed)
            return;

        Respawn(WSB_Lux.I);
    }

    public void Respawn(WSB_Player _p)
    {
        _p.transform.position = currentCheckpoint.transform.position;
    }
}
