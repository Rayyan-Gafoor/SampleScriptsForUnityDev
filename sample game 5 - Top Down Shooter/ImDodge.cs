using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImDodge : MonoBehaviour
{
    Player player;
    public float DashSpeed;
    public float dashTime;
    public float DashCoolDown=0;
    public float DashRate;
    public bool dash;

    float originalSpeed;

    private void Start()
    {
        player = GetComponent<Player>();
        originalSpeed = player.moveSpeed;
    }
    private void Update()
    {
        //Debug.Log(DashCoolDown);
        //Debug.Log("time= " + Time.time);
        if (Input.GetMouseButtonDown(1) && Time.time>DashCoolDown)
        {
            
            StartCoroutine(Dash());
            DashCoolDown = DashRate + Time.time;
           
        }
        else
        {
            player.moveSpeed = originalSpeed;
            dash = false;
        }
    }
    

IEnumerator Dash()
    {
        float StartTime = Time.time;
        
        while (Time.time< StartTime + dashTime)
        {
            //player.controller.Move(player.moveVelocity * DashSpeed * Time.deltaTime);
            // player.moveVelocity = player.moveVelocity * DashSpeed * Time.deltaTime;
            dash = true;
            player.moveSpeed = DashSpeed;
            
            yield return null;
        }

        
    }
}
