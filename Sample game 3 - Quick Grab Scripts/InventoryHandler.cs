using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public GameObject item1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            CheckItems();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
           //Debug.Log("This is item");
            AddItemToList(other.gameObject);
        }
    }

    void AddItemToList(GameObject item)
    {
        //Debug.Log("picked up item :" + item.name);
        items.Add(item);
        ItemHandler itemcontroller;
        itemcontroller = item.GetComponent<ItemHandler>();
        StartCoroutine(itemcontroller.ItemControl());
    }
    void RemoveItemFromList(GameObject item)
    {
        items.Remove(item);
    }
    void CheckItems()
    {
        foreach(GameObject x in items)
        {
            string temp;
            temp = x.name;
            
            int tempNumber = 0;
            for(int i=0; i<items.Count; i++)
            {
                if(temp== items[i].name)
                {
                    tempNumber++;
                }
                else
                {
                    continue;
                }
            }
            Debug.Log(temp + " amount :" + tempNumber);
        }
    }
}
