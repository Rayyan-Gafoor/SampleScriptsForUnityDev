using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    //Enemy Attack
    public float DistanceToTarget;
    public float AttackRange;
    GameObject Player;
    //Enemy Gun type
    public float EnemyDMG;
    public float fireRate;
    float nextFire;

    // Use this for initialization
    void Start()
    {
       // fireRate = 1f;
        nextFire = Time.time;
        Player = GameObject.FindGameObjectWithTag("Player");
        //Transform PlayerPosition = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        DistanceToTarget = Vector3.Distance(transform.position, Player.transform.position);
        // Debug.Log(DistanceToTarget);
        if (DistanceToTarget < AttackRange)
        {
            CheckIfTimeToFire();
        }

    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }

    }
}
