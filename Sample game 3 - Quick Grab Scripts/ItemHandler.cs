using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public float ItemRespawnTime;
    public enum guntype { Goat ,Chicken, Screaming, Pixelator, Enlarge, Shrink, Normal };
    public int setGun;
    public int Damage;
    public float FireRate;
    public float Range;
    public float hitForce;
    public guntype itemGuntype;

    public GameObject Player;
    public RayCastShooting GunType;

    private void Start()
    {
        GunType = Player.GetComponent<RayCastShooting>();
    }
    public IEnumerator ItemControl()
    {

        SetEnumGunType();
        GunType.Damage = Damage;
        GunType.FireRate = FireRate;
        GunType.Range = Range;
        GunType.hitForce = hitForce;

        gameObject.SetActive(false);
        yield return new WaitForSeconds(ItemRespawnTime);
        gameObject.SetActive(true);
    }
    void SetEnumGunType()
    {
        if(itemGuntype== guntype.Goat)
        {
            GunType.myGunType = RayCastShooting.GunType.GoatGun;
        }
        if (itemGuntype == guntype.Chicken)
        {
            GunType.myGunType = RayCastShooting.GunType.Chicken;
        }
        if (itemGuntype == guntype.Shrink)
        {
            GunType.myGunType = RayCastShooting.GunType.Shrink;
        }
        if (itemGuntype == guntype.Enlarge)
        {
            GunType.myGunType = RayCastShooting.GunType.Enlarge;
        }
        if (itemGuntype == guntype.Normal)
        {
            GunType.myGunType = RayCastShooting.GunType.Normal;
        }
        if (itemGuntype == guntype.Pixelator)
        {
            GunType.myGunType = RayCastShooting.GunType.Pixelator;
        }
        if (itemGuntype == guntype.Screaming)
        {
            GunType.myGunType = RayCastShooting.GunType.Screaming;
        }
    }

}

