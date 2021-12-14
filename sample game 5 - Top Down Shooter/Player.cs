using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (PlayerController))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 5;
    public PlayerController controller;
    Camera viewCamera;
    public float dodge;
    public Vector3 MoveInput;
    public Vector3 moveVelocity;
      
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();
        viewCamera = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        MoveInput= new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveVelocity = MoveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);
        // Dash
       
        //Camera Input
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if(groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            Debug.DrawLine(ray.origin, point, Color.blue);
            controller.LookAt(point);
        }
       
        /*if(Input.GetMouseButton(1))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + dodge);
            //Vector3 endMarker= transform.position + Vector3.up * dodge;
            //transform.position = Vector3.Lerp(transform.position, endMarker, 1);
        }
        if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + dodge);
            
        }
        if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - dodge);
        }
        if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x +dodge,0, 0);
        }
        if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - dodge,0,0);
        }*/
    }
}
