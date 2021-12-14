using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float health;
    public float CurrentHealth;
    public bool dead = false;
    //
    public float HealthPercentage;
    //ScreenShake Camera;
    GameObject Camera;
    public float Duration, Strength;

    void Start()
    {
        CurrentHealth = health;
        HealthPercentage = CurrentHealth / health;
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    private void Damage(float amount)
    {
        CurrentHealth -= amount*5;
        HealthPercentage = CurrentHealth / health;
        if (CurrentHealth <= 0 && !dead)
        {
            ShakeScreen(Duration, Strength);
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            ShootProjectile bullet = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootProjectile>();
            Damage(bullet.Bullet_DMG);
        }
    }
    void Die()
    {
        dead = true;
        Destroy(gameObject);
    }
    //screen shake function
    void ShakeScreen(float d, float s)
    {
        Vector3 orignalPostion = Camera.transform.position;
        float timePassed = 0f;

        while (timePassed < d)
        {
            float x = Random.Range(-1, 1) * s;
            float y = Random.Range(-1, 1) * s;

            Camera.transform.position = new Vector3(orignalPostion.x + x, orignalPostion.y + y, orignalPostion.z);
            //timePassed++;
            timePassed = Time.time;
            //Debug.Log(timePassed);
        }
        transform.position = orignalPostion;
    }
}
