using System;
using System.Collections.Generic;

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
