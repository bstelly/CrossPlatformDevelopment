using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerSave
{
    public List<InventoryItem> items = new List<InventoryItem>();
}

[Serializable]
public class InventoryItem
{
    public string name;
    public string imagePath;

    public InventoryItem(string n, string path)
    {
        name = n;
        imagePath = path;
    }
}

