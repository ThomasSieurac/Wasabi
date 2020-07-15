using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCam : MonoBehaviour
{
    [SerializeField] Transform character = null;


    public void FollowCharacter()
    {
        transform.position = new Vector3(character.position.x, character.position.y, transform.position.z);
    }

}
