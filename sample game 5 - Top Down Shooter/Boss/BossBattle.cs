using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle : MonoBehaviour
{
    public float phaseNum;
    public RadialEffect radialEffect;
    public ChangeColorRandom colorLerp;
    public float BulletChangeTime;
     
    GameObject BossController;
    float StartTime;
    int bulletNuumber;
    float bulletSpeed;
    float RateOfFire;
    int flag = 1;
    //colour change
    private Color OriColour;
    Renderer sprite;
    GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        BossController = this.gameObject;
        phaseNum = 1;
        boss = this.gameObject;
        sprite = boss.GetComponent<Renderer>();


    }

    // Update is called once per frame
    void Update()
    {

        //StartTime = Time.time;
        UpdatePhase();
        CheckPhase();

        
    }
    void CheckPhase()
    {
         
        if(phaseNum==2)
        {
            //BossController.SetActive()
            radialEffect.enabled= true;
            if (flag == 1)
            {
                StartCoroutine(Change(255, 0, 0));
            }
            
        }
        if (phaseNum == 2.5)
        {
            bulletNuumber = 10;
            bulletSpeed = 7.5f;
            RateOfFire = 8.5f;
            radialEffect.numberOfProjectiles= bulletNuumber;
            radialEffect.projectileSpeed = bulletSpeed; ;
            radialEffect.RateofSpawn = RateOfFire;
            if (flag == 1)
            {
                StartCoroutine(Change(1, 1, 0));
            }
            
        }
        if (phaseNum == 3)
        {
            bulletNuumber = 10;
            bulletSpeed = 10;
            RateOfFire = 5f;
            radialEffect.numberOfProjectiles = bulletNuumber;
            radialEffect.projectileSpeed = bulletSpeed; ;
            radialEffect.RateofSpawn = RateOfFire;
            if (flag == 1)
            {
                StartCoroutine(Change(0, 0, 1));
            }
            
        }
        if (phaseNum == 4)
        {
            bulletNuumber = 10;
            bulletSpeed = 10;
            RateOfFire = 5f;
            radialEffect.numberOfProjectiles = bulletNuumber;
            radialEffect.projectileSpeed = bulletSpeed; ;
            radialEffect.RateofSpawn = RateOfFire;
            radialEffect.AngleMultiplier = 6;
            if (flag == 1)
            {
                StartCoroutine(Change(0, 1, 0));
            }
           
        }
        if (phaseNum == 5)
        {
            bulletNuumber = 10;
            bulletSpeed = 5;
            RateOfFire = 0.5f;
            radialEffect.numberOfProjectiles = bulletNuumber;
            radialEffect.projectileSpeed = bulletSpeed; ;
            radialEffect.RateofSpawn = RateOfFire;
            radialEffect.radius = 20;
            radialEffect.AngleMultiplier = 6;
            if (flag == 1)
            {
                StartCoroutine(Change(0, 1, 0));
            }

        }
        if (phaseNum == 6)
        {
            bulletNuumber = 6;
            bulletSpeed = 5;
            RateOfFire = 1f;
            radialEffect.numberOfProjectiles = bulletNuumber;
            radialEffect.projectileSpeed = bulletSpeed; ;
            radialEffect.RateofSpawn = RateOfFire;
            radialEffect.AngleMultiplier = 6;
            radialEffect.radius = 10;
            if (flag == 1)
            {
                StartCoroutine(Change(0, 1, 0));
            }

        }
        if (phaseNum == 7)
        {
            bulletNuumber = 5;
            bulletSpeed = 2.5f;
            RateOfFire = 0.5f;
            radialEffect.numberOfProjectiles = bulletNuumber;
            radialEffect.projectileSpeed = bulletSpeed; ;
            radialEffect.RateofSpawn = RateOfFire;
            radialEffect.AngleMultiplier = 2;
            radialEffect.radius = 10;
            if (flag == 1)
            {
                StartCoroutine(Change(0, 1, 0));
            }

        }
        if (phaseNum == 8)
        {
            bulletNuumber = 5;
            bulletSpeed = 2.5f;
            RateOfFire = 0.5f;
            radialEffect.numberOfProjectiles = bulletNuumber;
            radialEffect.projectileSpeed = bulletSpeed; ;
            radialEffect.RateofSpawn = RateOfFire;
            radialEffect.radius = 10;
            radialEffect.AngleMultiplier = 5.5f;
            if (flag == 1)
            {
                StartCoroutine(Change(0, 1, 0));
            }

        }
        if (phaseNum == 9)
        {
            bulletNuumber = 5;
            bulletSpeed = 3.5f;
            RateOfFire = 0.5f;
            radialEffect.numberOfProjectiles = bulletNuumber;
            radialEffect.projectileSpeed = bulletSpeed; ;
            radialEffect.RateofSpawn = RateOfFire;
            radialEffect.radius = 10;
            radialEffect.AngleMultiplier = 5.5f;
            if (flag == 1)
            {
                StartCoroutine(Change(0, 1, 0));
            }

        }
        if (phaseNum == 10)
        {
            bulletNuumber = 7;
            bulletSpeed = 10;
            RateOfFire = 5f;
            radialEffect.numberOfProjectiles = bulletNuumber;
            radialEffect.projectileSpeed = bulletSpeed; ;
            radialEffect.RateofSpawn = RateOfFire;
            radialEffect.AngleMultiplier = 6;
            
            if (flag == 1)
            {
                float Health = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossHealth>().health;
                GameObject.FindGameObjectWithTag("Boss").GetComponent<BossHealth>().CurrentHealth = Health*0.75f;
                flag++;
                colorLerp.enabled = true;
            }
        }
    }
    private void UpdatePhase()
    {
        if (BossController.GetComponent<BossHealth>().CurrentHealth< 9500)
        {
            phaseNum = 2;
        }
        if (BossController.GetComponent<BossHealth>().CurrentHealth < 9000)
        {
            phaseNum = 2.5f;
        }
        if (BossController.GetComponent<BossHealth>().CurrentHealth < 8500)
        {
            phaseNum = 3;
        }
        if (BossController.GetComponent<BossHealth>().CurrentHealth < 8000)
        {
            phaseNum = 4;
        }
        if (BossController.GetComponent<BossHealth>().CurrentHealth < 7500)
        {
            phaseNum = 5;
        }
        if (BossController.GetComponent<BossHealth>().CurrentHealth < 7400)
        {
            phaseNum = 6;
        }
        if (BossController.GetComponent<BossHealth>().CurrentHealth < 7450)
        {
            phaseNum = 7;
        }
        if (BossController.GetComponent<BossHealth>().CurrentHealth < 7200)
        {
            phaseNum = 8;
        }
        if (BossController.GetComponent<BossHealth>().CurrentHealth < 6800)
        {
            phaseNum = 9;
        }
        if (BossController.GetComponent<BossHealth>().CurrentHealth < 5000)
        {
            phaseNum = 10;
        }

    }
    IEnumerator Change(float a, float b, float c)
    {

        sprite.material.SetColor("_Color", new Color(a, b, c, 1f));
        //Debug.Log(sprite.material.color);
        yield return null;

    }
   /* IEnumerator ChangeContinous(float a, float b, float c)
    {
        
        sprite.material.SetColor("_Color", new Color(a, b, c, 1f));
       // Debug.Log(sprite.material.color);
        yield return new WaitForSeconds(10);
        sprite.material.SetColor("_Color", new Color(a, b, c, 1f));
    }
    IEnumerator SetColor(int a, int b, int c)
    {
        yield return new WaitForSeconds(10);
        a = Random.Range.(0, 255);
        b = Random.Range(0, 255);
        c = Random.Range(0, 255);
        yield return new WaitForSeconds(10);
        StartCoroutine(ChangeContinous(a, b, c));
    }*/
}
