using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public Transform SpawnPoint;
    public string W_Name;
    public GameObject[] Bullet;
    public float BulletSpeed;
    public float msBetweenShots;
    public float Bullet_DMG;
    public float Bullet_LIFE;
    float nextShootTime;
    public int BulletEffectType=0;

    
    //ShotGun
    List<Quaternion> pellets;
    public float spreadAngle;
    public int BulletNumber;

    //reload
    public float MaxAmmo;
    public float CurrentAmmo;
    public float AmmoPercentage;
    public float ReloadTime;
    public bool reloading;
    //mana Control
    public float MaxMana;
    public float currentMana;


    Projectile projectile;

    //public Vector3 offset;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        projectile = GetComponent<Projectile>();
        CurrentAmmo = MaxAmmo;
        currentMana = MaxMana;
        AmmoPercentage = CurrentAmmo / MaxAmmo;
       
    }
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AmmoPercentage = CurrentAmmo / MaxAmmo;
        if (Input.GetMouseButton(0) && !reloading)
        {
            //StartPoint = SpawnPoint.position;
            Shoot();


        }
        if (Input.GetKey(KeyCode.R) && currentMana > 0)
        {
            // ChangeMana();
            StartCoroutine(Reload());
            //CurrentAmmo = MaxAmmo;
            //if(!reloading && reloaded)
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentMana <= 0)
            {
                currentMana = 0;
            }
            else
            {
                currentMana = currentMana - 1;
            }

            if (CurrentAmmo == MaxAmmo)
            {

                reloading = false;
            }
            //ChangeMana();
        }
    }
    /*IEnumerator ChangeMana()
    {
        yield return new WaitForSeconds(2);
       
            currentMana = currentMana - 1;
            Debug.Log("Called");
        
        yield return new WaitForSeconds(2);

    }*/

    void Shoot()
    {
        if (Time.time > nextShootTime && CurrentAmmo>0)
        {
            nextShootTime = Time.time + msBetweenShots / 1000;
            
            if (BulletNumber != 1)
            {
                pellets = new List<Quaternion>(BulletNumber);
                for (int k = 0; k < BulletNumber; k++)
                {
                    pellets.Add(Quaternion.Euler(Vector3.zero));
                }
                int i = 0;
                foreach (Quaternion quat in pellets.ToArray())
                {
                    pellets[i] = Random.rotation;
                    GameObject p = Instantiate(Bullet[BulletEffectType], SpawnPoint.position, SpawnPoint.rotation);
                    p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, pellets[i], spreadAngle);
                    p.GetComponent<Rigidbody>().AddForce(p.transform.forward * BulletSpeed, ForceMode.Impulse);
                    CurrentAmmo--;
                }

            }
            else
            {
                GameObject bullet = Instantiate(Bullet[BulletEffectType], SpawnPoint.position, SpawnPoint.rotation);
                CurrentAmmo--;
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                rb.AddForce(SpawnPoint.forward * BulletSpeed, ForceMode.Impulse);
            }
            
        }

    }
    IEnumerator Reload()
    {
        float StartTime = Time.time;
       
        if (!reloading)
        {
           while (Time.time < StartTime + ReloadTime)
            {
                float timeKeeper = StartTime + ReloadTime;
                CurrentAmmo= Mathf.Lerp(0, MaxAmmo, Time.time / timeKeeper);
                reloading = true;
                //Debug.Log("time = " + Time.time + " Reload Time = " + timeKeeper);
                yield return null;
            }
            reloading = false;
        }
       
        //if(!reloading && )
        CurrentAmmo = MaxAmmo;
    }
     
}
