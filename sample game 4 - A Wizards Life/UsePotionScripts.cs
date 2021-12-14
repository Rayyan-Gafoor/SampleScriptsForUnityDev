using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePotionScripts : MonoBehaviour
{
    public GameObject Player;
    IventoryHandler inventory;
    PlayerController controller;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Player.GetComponent<IventoryHandler>();
        controller = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpeedPotion()
    {
        controller.SpeedPotion_Used= true;
    }
}
