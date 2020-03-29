using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    
    public Transform target; // camera try to follow this target
    [Range(0.05f,1)]
    public float smothSpeed;
    
    public Vector3 offset;
    private Vector3 velocity;
    private Vector3 nextPosition => target.position + offset;

    private Vector3 currentPosition;
    public bool showGizmos = false;
    private void Reset()
    {
        
    }



    private void FixedUpdate()
    {
        currentPosition = transform.position;
       // transform.position = Vector3.Lerp(currentPosition, nextPosition, smothSpeed);
        transform.position =  Vector3.SmoothDamp(currentPosition, nextPosition, ref velocity, smothSpeed);

    }

    //For editor
}
