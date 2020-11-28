using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equip Object", menuName = "Inventory System/Items/Equipment")]
public class EquipItem : itemObject
{
    public void Awake()
    {
        type = ItemType.Equip;
    }
    
}
