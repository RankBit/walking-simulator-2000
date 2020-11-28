using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equip,
    Default,
    Puzzle,

}

public abstract class itemObject : ScriptableObject
{
    public int Id;
    public Sprite uidisplay;
    public ItemType type;
    [TextArea(15,20)]
    public string description;

}
[System.Serializable]
public class Item
{
    public string Name;
    public int Id;
    public Item(itemObject item)
    {
        Name = item.name;
        Id = item.Id;
    }
}
