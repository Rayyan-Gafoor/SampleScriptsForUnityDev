using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDrops : MonoBehaviour
{
    public Vector3 centre;
    public Vector3 size;
    public GameObject[] WeaponPickup;
    public int DropNum;

    public float DropRate;
    public float NextDrop;
    private void Start()
    {
        SpawnWP();
        NextDrop = Time.time;
        //Debug.Log(WeaponPickup.Length);
        
    }
    private void Update()
    {
        CheckWeaponDrop();
    }
    public void SpawnWP()
    {
        DropNum = Random.Range(0, WeaponPickup.Length);
        Vector3 pos = centre + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, Random.Range(-size.z / 2, size.z / 2));
        Instantiate(WeaponPickup[DropNum], pos, Quaternion.identity);
    }
    public void CheckWeaponDrop()
    {

        if (Time.time > NextDrop)
        {
            if (GameObject.FindGameObjectWithTag("WeaponPickUp") == null)
            {
                SpawnWP();
                NextDrop = Time.time + DropRate;
            }
            else
            {
                Destroy(GameObject.FindGameObjectWithTag("WeaponPickUp"));
                NextDrop = Time.time + DropRate ;
            }

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(centre, size);
    }
}
/*
 [SerializeField]
    GameObject weaponPickUp;
    GameObject tmp;
    public float nextDrop;
    public float RateOfDrop;

    WeaponPickup _weaponPickup;

    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        _weaponPickup = GetComponent<WeaponPickup>();
        SpawnWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnWeapon()
    {
        bool WeaponSpawned = false;
        while (!WeaponSpawned)
        {
            tmp = weaponPickUp;
            Vector3 WeaponPosition = new Vector3(Random.Range(-7f, 7f), 1f, Random.Range(-7, 7));
            if ((WeaponPosition - target.position).magnitude < 3)
            {
                continue;
            }
            else
            {
                Instantiate(tmp, WeaponPosition, Quaternion.identity);
                WeaponSpawned = true;
            }
        }
    }
    */
