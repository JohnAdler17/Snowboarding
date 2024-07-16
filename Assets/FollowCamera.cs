using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //this thing's position (camera) should be the same as the car's position

    [SerializeField] GameObject thingToFollow;
    // Update is called once per frame
    //late update forces the code to run after update is called each frame
    void LateUpdate()
    {
        transform.position =  thingToFollow.transform.position + new Vector3 (0, 0, -10);
    }
}
