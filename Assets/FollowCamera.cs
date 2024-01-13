using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject car;
    //This cameras position should be the same as the car.  
    void LateUpdate()
    {
        transform.position = car.transform.position + new Vector3 (0,0,-10); 
    }
}
