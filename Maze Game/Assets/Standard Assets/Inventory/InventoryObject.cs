using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject 
{
    public string savepath;
    public ItemDatabase database;
    public Inventory Container;
    

    public void additem(Item _item, int _amount)
    {
        
        for(int i = 0; i<Container.Items.Count; i++)
        {
            if(Container.Items[i].item.Id == _item.Id)
            {
                Container.Items[i].addamount(_amount);
                return;
            }
        }
        
            Container.Items.Add(new InventorySlot(_item.Id,_item, _amount));
       
    }
    
    public void save()
    {
        /*string savedata = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savepath));
        bf.Serialize(file, savedata);
        file.Close();*/
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savepath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, Container);
        stream.Close();

    }
    
    public void load()
    {
        if(File.Exists(string.Concat(Application.persistentDataPath, savepath)))
        {
            /*BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savepath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();*/

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savepath), FileMode.Open, FileAccess.Read);
            Inventory newContainer = (Inventory)formatter.Deserialize(stream);
            stream.Close();
        }
    }

   
    public void Clear()
    {
        Container = new Inventory();
    }
}
[System.Serializable]
public class Inventory
{
    public List<InventorySlot> Items = new List<InventorySlot>();
}

[System.Serializable]
public class InventorySlot
{
    public Item item;
    public int ID;

    public int amount;
    public InventorySlot(int _id, Item _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }
    public void addamount(int value)
    {
        amount += value; 
    }
}
