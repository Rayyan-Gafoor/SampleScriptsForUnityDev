using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft : MonoBehaviour
{
    //Will Use to Set variables in InventorySystem
    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;
    public GameObject Item5;
    public GameObject Potion;
    public int RequiredCount1;
    public int RequiredCount2;
    public int RequiredCount3;
    public int RequiredCount4;
    public int RequiredCount5;

    public GameObject Player;
    IventoryHandler PlayerInventory;
    // Start is called before the first frame update
    void Start()
    {
        PlayerInventory = Player.GetComponent<IventoryHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCraftButton()
    {
        PlayerInventory.CraftingItem1 = Item1;
        PlayerInventory.CraftingItem2 = Item2;
        PlayerInventory.CraftingItem3 = Item3;
        PlayerInventory.CraftingItem4 = Item4;
        PlayerInventory.CraftingItem5 = Item5;

        PlayerInventory.Potion = Potion;

        PlayerInventory.RequiredItemCount1 = RequiredCount1;
        PlayerInventory.RequiredItemCount2 = RequiredCount2;
        PlayerInventory.RequiredItemCount3 = RequiredCount3;
        PlayerInventory.RequiredItemCount4 = RequiredCount4;
        PlayerInventory.RequiredItemCount5 = RequiredCount5;



    }
    
}
