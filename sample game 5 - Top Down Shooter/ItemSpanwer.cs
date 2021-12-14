using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpanwer : MonoBehaviour
{
    public Vector3 centre;
    public Vector3 size;
    public GameObject[] ItemPickUp;
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
        DropNum = Random.Range(0, ItemPickUp.Length);
        Vector3 pos = centre + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, Random.Range(-size.z / 2, size.z / 2));
        Instantiate(ItemPickUp[DropNum], pos, Quaternion.identity);
    }
    public void CheckWeaponDrop()
    {

        if (Time.time > NextDrop)
        {
            if (GameObject.FindGameObjectWithTag("ItemPickUp") == null)
            {
                SpawnWP();
                NextDrop = Time.time + DropRate;
            }
            else
            {
                Destroy(GameObject.FindGameObjectWithTag("ItemPickUp"));
                NextDrop = Time.time + DropRate;
            }

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(centre, size);
    }
}
