using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float moveSpeed = 7f;

    Rigidbody rb;

    GameObject target;
    Vector3 moveDirection;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector3(moveDirection.x, transform.position.y, moveDirection.z);
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            //Debug.Log("Hit!");
            Destroy(gameObject);
        }
        if (col.gameObject.tag.Equals("Wall"))
        {
            //Debug.Log("Hit!");
            Destroy(gameObject);
        }
    }
}
