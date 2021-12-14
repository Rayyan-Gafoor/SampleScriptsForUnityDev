using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    ShootProjectile projType;
  
    // Start is called before the first frame update
    void Start()
    {
        
        projType = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootProjectile>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        GameObject.Destroy(gameObject, projType.Bullet_LIFE);

    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject.Destroy(gameObject);
        //Debug.Log(gameObject.tag);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Enemy" || other.tag == "Wall" || other.tag== "Boss")
        {
            GameObject.Destroy(gameObject);
        } 
        
        //Debug.Log("trigger destroy");
    }

}
