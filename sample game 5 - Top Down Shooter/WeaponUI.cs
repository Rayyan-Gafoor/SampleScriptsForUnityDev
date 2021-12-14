using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    [SerializeField]
    private Image WeaponAmmoScroll;
    [SerializeField]
    private Text WeaponAmmoCount;
    [SerializeField]
    private Text ManaNumCount;
    [SerializeField]
    private Text WeaponType;

    private float UpdateSpeed = 0.5f;

    //private GameObject WeaponManager;
    private float AmmoPer;
    private float AmmoNumber;
    private float ManaCount;
    private string WeaponName;



    private void Awake()
    {

        AmmoPer = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootProjectile>().AmmoPercentage;
        AmmoNumber = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootProjectile>().CurrentAmmo;
        ManaCount = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootProjectile>().currentMana;
        WeaponName = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootProjectile>().W_Name;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AmmoPer = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootProjectile>().AmmoPercentage;
        AmmoNumber = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootProjectile>().CurrentAmmo;
        ManaCount = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootProjectile>().currentMana;
        WeaponName = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootProjectile>().W_Name;
        HandleAmmoChange(AmmoPer);
        WeaponAmmoCount.text = "Mana: "+ AmmoNumber;
        ManaNumCount.text = "Mana Shots: " + ManaCount;
        WeaponType.text = "Magic: " + WeaponName;
    }
    void HandleAmmoChange(float Percent)
    {
        //Percent = HealthBarPer;
        StartCoroutine(BarToPer(Percent));
    }
    private IEnumerator BarToPer(float PCT)
    {
        float preChangePct = WeaponAmmoScroll.fillAmount;
        float Elapsed = 0f;
        while (Elapsed < UpdateSpeed)
        {
            Elapsed += Time.deltaTime;
            WeaponAmmoScroll.fillAmount = Mathf.Lerp(preChangePct, PCT, Elapsed / UpdateSpeed);
            yield return null;

        }
        WeaponAmmoScroll.fillAmount = PCT;
        
    }
}
