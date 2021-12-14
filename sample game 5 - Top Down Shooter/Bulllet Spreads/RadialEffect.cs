using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialEffect : MonoBehaviour
{
   
    public int numberOfProjectiles;
    public float projectileSpeed;
    public GameObject ProjectilePrefab;
    public float RateofSpawn;
    public float radius = 5f;
    public float angle = 0;
    public float AngleMultiplier = 0f;


    private Vector3 StartPoint;
    
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // when the effect should be triggered.
        if (Time.time > nextFire)
        {
            StartPoint = transform.position;
            SpawnProjectile(numberOfProjectiles);
            nextFire = Time.time + RateofSpawn;
        }
        /*if (Input.GetMouseButton(0))
        {
            StartPoint = transform.position;
            SpawnProjectile(numberOfProjectiles);
        }*/
    }
    void SpawnProjectile(int _number)
    {
        float angleStep = 360 / _number;
        
        for(int i=0; i< _number; i++)
        {
            float projectileDirXPos = StartPoint.x + Mathf.Sin((angle *AngleMultiplier* Mathf.PI) / 100) * radius;
            float projectileDirYPos = StartPoint.y + Mathf.Cos((angle *AngleMultiplier* Mathf.PI) / 100) * radius;

            Vector3 ProjectileVec = new Vector3(projectileDirXPos, projectileDirYPos, 0);
            Vector3 projectileMoveDir = (ProjectileVec - StartPoint).normalized * projectileSpeed;

            GameObject tmpObj = Instantiate(ProjectilePrefab, StartPoint, Quaternion.identity);
            tmpObj.GetComponent < Rigidbody>().velocity= new Vector3(projectileMoveDir.x,0, projectileMoveDir.y);
            //Instantiate(ProjectilePrefab, StartPoint, Quaternion.identity);
            angle += angleStep;
        }
    }
}
