using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public int pelletCount;
    public float spreadAngle;
    public GameObject pellet;
    public Transform BarrelExit;
    public float pelletFireVelocity=1f;
    List<Quaternion> pellets;

    private void Awake()
    {
        pellets = new List<Quaternion>(pelletCount);
        for (int i = 0; i < pelletCount; i++)
        {
            pellets.Add(Quaternion.Euler(Vector3.zero));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    void Fire()
    {
        int i = 0;
        foreach (Quaternion quat in pellets.ToArray())
        {
            pellets[i] = Random.rotation;
            GameObject p = Instantiate(pellet, BarrelExit.position, BarrelExit.rotation);
            p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, pellets[i], spreadAngle);
            p.GetComponent<Rigidbody>().AddForce(p.transform.forward * pelletFireVelocity);
        }
    }
}
