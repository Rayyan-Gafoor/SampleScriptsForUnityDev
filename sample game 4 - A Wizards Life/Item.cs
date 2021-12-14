using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float RespawnTime;
    public GameObject Player;
    IventoryHandler inventory;

    private void Awake()
    {
        inventory = Player.GetComponent<IventoryHandler>();
    }
    public void Disable()
    {
        inventory.PickUpText.SetActive(false);
        gameObject.SetActive(false);
    }
}
