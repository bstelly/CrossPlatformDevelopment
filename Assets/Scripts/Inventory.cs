﻿using System;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory")]
[Serializable]
public class Inventory : ScriptableObject
{
    [SerializeField] public List<Item> items;


    [TextArea]
    [SerializeField]
    //string json;

    InventoryTemp temp = new InventoryTemp();

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
        string json = JsonUtility.ToJson(this, true);
        string directory = Application.persistentDataPath;
        File.WriteAllText(directory + @"\save.json", json);
        Debug.Log(directory);
    }

    public void Deserialize(string json)
    {
        Debug.Log("Beginning Deserialization");
        //var newInventory = CreateInstance<Inventory>();
        JsonUtility.FromJsonOverwrite(json, temp);
        Debug.Log("Deserialized save into temporary variable");
        Debug.Log("Capacity" + temp.items.Capacity);
        Debug.Log(temp.itemTemps[0].instanceID);
        //items = newInventory.items;
    }
}