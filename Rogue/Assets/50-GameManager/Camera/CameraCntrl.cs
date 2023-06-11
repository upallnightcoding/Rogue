using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCntrl : MonoBehaviour
{
    [SerializeField] private Transform target;

    private Vector3 cameraVelocity = Vector3.zero;

    private float cameraFollowSpeed = 0.2f;

    private void Awake()
    {
        
    }

    public void FollowTarget()
    {
        Vector3 position = Vector3.SmoothDamp
            (transform.position, target.position, ref cameraVelocity, cameraFollowSpeed);

        transform.position = position;
    }
}
