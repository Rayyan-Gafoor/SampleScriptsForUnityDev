using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : ShootProjectile
{
    
    // Start is called before the first frame update

    ShootProjectile projType;
    WeaponDrops BulletpickUweaponPickUp1;
    //Projectile BulletType;
    GameObject[] particleType;
    //new bullet stats
    public string WeaponName;
    public float Firerate;
    public float Speed;
    public float BulletDMG;
    public float BulletLIFE;
    public int EffectType;
    public int WeaponMag;
    public float ReloadTIME;
    public int BulletNum;
    public int BulletSpread;

    protected override void Start()
    {
        projType = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootProjectile>();
        
        //BulletType = GameObject.FindGameObjectWithTag("Bullet").GetComponent<Projectile>();
        BulletpickUweaponPickUp1 = GameObject.FindGameObjectWithTag("WeaponSpawner").GetComponent<WeaponDrops>();

    }
    // Update is called once per frame
    void Update()
    {
        //BulletType = GameObject.FindGameObjectWithTag("Bullet").GetComponent<Projectile>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            //bullet stats 
            projType.W_Name = WeaponName;
            projType.BulletSpeed = Speed;
            projType.msBetweenShots = Firerate;
            projType.Bullet_DMG = BulletDMG;
            projType.Bullet_LIFE = BulletLIFE;
            projType.BulletEffectType = EffectType;
            projType.MaxAmmo = WeaponMag;
            projType.CurrentAmmo = WeaponMag;
            projType.ReloadTime = ReloadTIME;
            projType.BulletNumber = BulletNum;
            projType.spreadAngle = BulletSpread;

            //BulletType.BulletDamaage = BulletDMG;
            //BulletType.BulletLifeTime = BulletLIFE;
            //BulletpickUweaponPickUp1.SpawnWP();
            Destroy(gameObject);

        }

    }
}
