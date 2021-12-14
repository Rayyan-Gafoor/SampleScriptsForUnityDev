using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TeleEnemy : MonoBehaviour
{
    NavMeshAgent PathFinder;
    Transform target;
    public Vector3 offset;
    public float DisToTarget;
    public float InRange;
    public float outrange;
    public float refreshRate = 5;
    // Start is called before the first frame update
    void Start()
    {
        PathFinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(UpdatePath());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator UpdatePath()
    {

        while (target != null)
        {
            DisToTarget = Vector3.Distance(target.position, transform.position);
            if (DisToTarget < InRange)
            {
                //telepoty enemy to new position
                Teleport();
                yield return new WaitForSeconds(refreshRate);
            }
            else
            {
                yield return new WaitForSeconds(refreshRate);
            }

        }
    }
   
    void Teleport()
    {
        offset = new Vector3(Random.Range(-outrange+ target.position.x, outrange+target.position.x), 0, Random.Range(-outrange+target.position.z, outrange+ target.position.z));
        transform.position = offset;
            //Player.transform.position = target.transform.position;
            //sound.PlayOneShot(drop, 2f);
        

    }
}
