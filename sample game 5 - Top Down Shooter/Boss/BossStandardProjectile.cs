using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStandardProjectile : MonoBehaviour
{
    void Start()
    { 
        Destroy(gameObject, 10f);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Player") || col.gameObject.tag.Equals("Wall"))
        {
            //Debug.Log("Hit!");
            Destroy(gameObject);
        }
    }
}
