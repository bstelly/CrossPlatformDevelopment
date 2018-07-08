using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[Serializable]
public class PlayerSave
{
    public List<InventoryItem> items = new List<InventoryItem>();
}

[Serializable]
public class InventoryItem
{
    public string itemName;
    public string spriteName;

    public InventoryItem(string n, string name)
    {
        itemName = n;
        spriteName = name;
    }
}

//Create an inventory for world and check if world inventory contains item.
//if so remove item from world and put in player inventory
