using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastShooting : MonoBehaviour
{
    public enum GunType
    {
        Pixelator,
        Normal,
        GoatGun,
        Chicken,
        Shrink,
        Enlarge,
        Screaming

    }
    public int Damage = 1;
    public float FireRate = 0.25f;
    public float Range = 50f;
    public float hitForce = 100f;
    public Transform BulletSpawnPoint;
    public Camera FpsCamera;
    public GunType myGunType;

    WaitForSeconds shotduration = new WaitForSeconds(0.07f);
    LineRenderer laserline;
    float nextFire;
    

    private void Start()
    {
        laserline = GetComponent<LineRenderer>();
        myGunType = GunType.Chicken;

    }
    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && Time.time> nextFire)
        {
            nextFire = Time.time + FireRate;

            StartCoroutine(GunEffects());

            Vector3 rayOrigin = FpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));
            RaycastHit Hit;
            laserline.SetPosition(0, BulletSpawnPoint.position);

            if(Physics.Raycast(rayOrigin, FpsCamera.transform.forward, out Hit, Range))
            {
               
                laserline.SetPosition(1, Hit.point);
                // reference enemy or object to shoot at 

                if(Hit.collider.GetComponent<ShootableObject>()!= null)
                {
                    ShootableObject objectToShoot = Hit.collider.GetComponent<ShootableObject>();

                    if (myGunType == GunType.Normal)
                    {
                        if (Hit.rigidbody != null)
                        {
                            Hit.rigidbody.AddForce(-Hit.normal * hitForce);
                        }
                        objectToShoot.DestroyGameObject();
                    }
                    if (myGunType == GunType.Shrink)
                    {
                        objectToShoot.Shrink();
                    }
                    if (myGunType == GunType.Enlarge)
                    {
                        objectToShoot.Enlarge();
                    }
                    if (myGunType == GunType.GoatGun)
                    {
                        objectToShoot.GoatGun();
                    }
                    if (myGunType == GunType.Screaming)
                    {
                        objectToShoot.ScreamGun();
                        
                    }
                    if (myGunType == GunType.Chicken)
                    {
                        objectToShoot.ChickenGun();
                       
                    }
                    if (myGunType == GunType.Pixelator)
                    {
                        objectToShoot.Pixalator();
                    }
                }
                 


            }
            else
            {
                
                laserline.SetPosition(1, rayOrigin + (FpsCamera.transform.forward * Range));
            }
            
        }
        
    }

    IEnumerator GunEffects()
    {
        laserline.enabled = true;
        yield return shotduration;
        laserline.enabled = false;
    }

    void LaserSight()
    {
        Vector3 line = FpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(line, FpsCamera.transform.forward * Range, Color.green);
    }
}
