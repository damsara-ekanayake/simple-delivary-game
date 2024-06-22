using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingTOFollow;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = thingTOFollow.transform.position + new Vector3(0 ,0 , -10);
        transform.rotation = thingTOFollow.transform.rotation;  
    }
}
