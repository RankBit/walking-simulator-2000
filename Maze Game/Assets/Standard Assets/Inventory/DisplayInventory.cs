using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public GameObject inventoryprefab;
    public InventoryObject inventory;
    public int Xstart;
    public int Ystart;
    public int X_space;
    public int Y_space;
    public int numberofc;
    Dictionary<InventorySlot, GameObject> itemdisplayed = new Dictionary<InventorySlot, GameObject>();
   
    void Start()
    {
        CreateDisplay();
    }

    public void CreateDisplay()
    {
        for( int i = 0; i< inventory.Container.Items.Count; i++)
        {
            InventorySlot slot = inventory.Container.Items[i];
            var obj = Instantiate(inventoryprefab, Vector3.zero, Quaternion.identity, transform);
            obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[slot.item.Id].uidisplay;
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
            itemdisplayed.Add(slot, obj); 
        }
    }
    public Vector3 GetPosition(int i)
    {
        return new Vector3(Xstart + (X_space*(i % numberofc)), Ystart + ((-Y_space * (i/numberofc))));
    }

    void Update()
    {
        UpdateDisplay();
    }
     public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Items.Count; i++)
        {
            InventorySlot slot = inventory.Container.Items[i];
            if (itemdisplayed.ContainsKey(slot)) 
            {
                itemdisplayed[slot].GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventoryprefab, Vector3.zero, Quaternion.identity, transform);
                obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[slot.item.Id].uidisplay;
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
                itemdisplayed.Add(slot, obj);
            }
        }

    }
}


