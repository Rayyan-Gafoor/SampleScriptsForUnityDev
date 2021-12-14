using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float currentHealth;
    public float HealthPercentage;
    public bool dead = false;

    //ScreenShake Camera;
    GameObject Camera;
    public float Duration, Strength;

    // ultimate attack
    public float ultimateCountdown = 0;
    public float ultimateCountdownPer;
    public RadialEffect ultimateAttack;
    void Start()
    {
        currentHealth = health;
        HealthPercentage = currentHealth / health;
        ultimateCountdownPer = ultimateCountdown / 10f;
        Camera = GameObject.FindGameObjectWithTag("MainCamera");//.GetComponent<ScreenShake>();
        //health = StartHealth;
        
        //Debug.Log(health + "start with this");
    }
    private void Update()
    {
        Damage(0);
       
    }
    private void Damage(float amount)
    {
        currentHealth -= amount;
        
        HealthPercentage = currentHealth / health;
        ultimateCountdownPer = ultimateCountdown / 10f;
       // Debug.Log(ultimateCountdownPer + " in heal script");
        if (ultimateCountdown == 10)
        {
           StartCoroutine( CheckUltimate());
           // Debug.Log("ready");
        }
       
        //Debug.Log(health);
        if (currentHealth <= 0 && !dead)
        {
            //StartCoroutine(Camera.ShakeScreen(Duration, Strength));
            //ShakeScreen(Duration, Strength);
            Debug.Log("dead");
            Die();
        }
      
    }
    IEnumerator CheckUltimate()
    {
        //yield return new WaitForSeconds(5);
       /// Debug.Log("ready");
        ultimateAttack.enabled = true;
            ultimateCountdown = 0;
            yield return new WaitForSeconds(3);
            ultimateAttack.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBullet")
        {
            //ShootProjectile bullet = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootProjectile>();
            EnemyAttack bullet = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAttack>();
            ultimateCountdown = ultimateCountdown + 1;
            Damage(bullet.EnemyDMG);
        }
        if(other.tag== "BossBullet")
        {
            BossAttack bullet = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossAttack>();
            ultimateCountdown = ultimateCountdown + 1;
            Damage(bullet.EnemyDMG);
        }
    }
    void Die()
    {
        dead = true;
        SceneManager.LoadScene("MainMenu");
        // Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        //Destroy(gameObject);

        //set endgame
    }
}
