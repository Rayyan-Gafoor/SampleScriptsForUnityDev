using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    PlayerHealth PlayerHP;
    ShootProjectile PlayerMP;
    //new Player stats
    public float Health;
    public float Mana;
   
    protected  void Start()
    {
        PlayerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        PlayerMP = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootProjectile>();

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
            // Update Player Stats
            // health update
            if(PlayerHP.currentHealth + Health >69)
            {
                PlayerHP.currentHealth = 69;
            }
            else
            {
                PlayerHP.currentHealth = PlayerHP.currentHealth + Health;
            }

            //mana Update
            if (PlayerMP.currentMana + Mana > 10)
            {
                PlayerMP.currentMana = 10;
            }
            else
            {
                PlayerMP.currentMana += Mana;
            }

            //PlayerMP.currentMana += Mana;

            Destroy(gameObject);

        }

    }
}
