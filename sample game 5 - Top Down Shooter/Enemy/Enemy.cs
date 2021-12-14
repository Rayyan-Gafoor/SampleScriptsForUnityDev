using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    NavMeshAgent PathFinder;
    Transform target;
    public Vector3 offset;
    public float DisToTarget;
    public float InRange;
    public float refreshRate = 1;
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
        if (target == null)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator UpdatePath()
    {
        
        while (target!= null)
        {
            DisToTarget = Vector3.Distance(target.position, transform.position);
            if(DisToTarget > InRange)
            {
                Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
                // CheckXvalue();
                PathFinder.SetDestination(targetPosition + offset);
                //Debug.Log(DisToTarget);
                yield return new WaitForSeconds(refreshRate);
            }
            else
            {
                yield return new WaitForSeconds(refreshRate);
            }
           
        }
    }

}
