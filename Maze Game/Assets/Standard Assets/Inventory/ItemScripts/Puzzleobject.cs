using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Puzzle Object", menuName = "Inventory System/Items/Puzzle")]
public class Puzzleobject : itemObject
{
    public void Awake()
    {
        type = ItemType.Puzzle;
    }
}
