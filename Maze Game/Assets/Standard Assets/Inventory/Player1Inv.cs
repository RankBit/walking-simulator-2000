using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Inv : MonoBehaviour
{
    public InventoryObject inventory;
    

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<GroundItem>();
        if(item)
        {
            inventory.additem(new Item(item.item), 1);
            Destroy(other.gameObject);
        }
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Items.Clear(); 
    }
   private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            inventory.save();
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventory.load();
        }
    }
    
}
  
