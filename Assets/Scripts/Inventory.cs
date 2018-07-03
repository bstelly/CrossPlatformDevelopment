using System;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory")]
[Serializable]
public class Inventory : ScriptableObject
{
    [SerializeField]
    public List<Item> items;

    public PlayerSave save = new PlayerSave();

    [TextArea]
    [SerializeField]
    string json;

    public void Add(Item item)
    {
        items.Add(item);
    }


    public void Remove(Item item)
    {
        items.Remove(item);
    }


    public void Serialize()
    {
        //Debug.Log(items[0].image.ToString());
        //Debug.Log(items[0].name);
        if (save.items.Count > 0)
        {
            save.items.Clear();
        }
        //Add all inventory variables to player save variables, then serialize player save
        foreach (var x in items)
        {
            save.items.Add(new InventoryItem(x.name, x.imagePath));
        }
        string json = JsonUtility.ToJson(save, true);
        string directory = Application.persistentDataPath;
        File.WriteAllText(directory + @"\save.json", json);
        Debug.Log(directory);
    }

    public void Deserialize(string json)
    {
        //Deserialize player save and then replace inventory data with playersave data
        Debug.Log("Beginning Deserialization");
        var newInventory = CreateInstance<Inventory>();
        JsonUtility.FromJsonOverwrite(json, newInventory);
        items = newInventory.items;
    }
}