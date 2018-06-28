using System;
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
        json = JsonUtility.ToJson(this, true);
        string directory = Application.persistentDataPath;
        File.WriteAllText(directory + @"\save.json", json);
        Debug.Log(directory);
    }

    public void Deserialize(string json)
    {
        Inventory newInventory = JsonUtility.FromJson<Inventory>(json);
        items = newInventory.items;
    }
}