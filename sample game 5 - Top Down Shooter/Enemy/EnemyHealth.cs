using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float CurrentHealth;
    public float health;
    public bool dead = false;

    //ScreenShake Camera;
    GameObject Camera;
    public float Duration, Strength;
    // Damage 
    Renderer sprite;
    GameObject Enemy;
    public float DmgColourTime;
    private Color OriColour;
    // health bar
    public float HealthPercentage;
    //public event OnHealthChange= delegate{};
    void Start()
    {
        CurrentHealth = health;
        HealthPercentage = CurrentHealth / health;
        Enemy = this.gameObject;
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        sprite = Enemy.GetComponent<Renderer>();
    }
    private void Damage(float amount)
    {
       
        CurrentHealth -= amount;
        HealthPercentage = CurrentHealth / health;
        StartCoroutine(Change(DmgColourTime));
        
        if (CurrentHealth <= 0 && !dead)
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            ShootProjectile bullet = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootProjectile>();
            Damage(bullet.Bullet_DMG);
           // Debug.Log(bullet.Bullet_DMG);
        }
    }
    void Die()
    {
        dead = true;
        Destroy(gameObject);
    }
    
    IEnumerator Change(float Timer)
    {
        OriColour = sprite.material.color;
        
        sprite.material.SetColor("_Color", new Color(1, 0, 0, 1f));
        yield return new WaitForSeconds(Timer);

        sprite.material.SetColor("_Color", OriColour);
    }
    /*void ShakeScreen(float d, float s)
    {
        Vector3 orignalPostion = Camera.transform.position;
        float timePassed = Time.time;
        d = d + Time.time;
        while (timePassed < d)
        {
            float x = Random.Range(-1,1) * s;
            float y = Random.Range(-1,1) * s;
            Camera.transform.position = new Vector3(orignalPostion.x+x, orignalPostion.y+y, orignalPostion.z);
            timePassed = Time.time;
        }
        transform.position = orignalPostion;
        
    }*/
    /* void ChangeColour(float ChgTime)
     {
         float timePassed = 0f;

         OriColour = sprite.material.color;
         while (timePassed < ChgTime)
         {
             Debug.Log(timePassed);
             Debug.Log("CHng");

             sprite.material.SetColor("_Color", new Color(1, 0, 0, 1f));
             timePassed += Time.deltaTime;
             Debug.Log(timePassed);
         }
         timePassed = 0f;
         sprite.material.SetColor("_Color", OriColour);
     }*/
}
