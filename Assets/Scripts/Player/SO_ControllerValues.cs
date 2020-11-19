using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ControllerValues", menuName = "ScriptableObjects/CreateControllerValues", order = 1)]
public class SO_ControllerValues : ScriptableObject
{
    public ContactFilter2D Contact = new ContactFilter2D();
    public float GroundMin = .5f;
    public float MaxHeightClimb = .5f;
    public float SpeedCoef = 1;
    public float Deceleration = 10;
    public float JumpDelay = .2f;
    public float JumpBufferDelay = .2f;
    public AnimationCurve JumpCurve = new AnimationCurve();
    public AnimationCurve SpeedCurve = new AnimationCurve();

}
