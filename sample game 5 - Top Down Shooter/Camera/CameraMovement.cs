using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float MovementSpeed = 0.13f;
    public Vector3 offset;

    private void FixedUpdate()
    {
        
        if (target != null)
        {
            Vector3 Position = target.position + offset;
            Vector3 Smooth = Vector3.Lerp(transform.position, Position, MovementSpeed);
            transform.position = Smooth;
        }
        else
        {
            return;
        }
    }
}
