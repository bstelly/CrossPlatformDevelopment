using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory")]
[Serializable]
public class Inventory : ScriptableObject
{
    [SerializeField]
    public List<ItemBehaviour> items;
    public PlayerSave save = new PlayerSave();

    [TextArea]
    [SerializeField]
    string json;

    public void Add(ItemBehaviour item)
    {
        items.Add(item);
    }


    public void Remove(int index)
    {
        items.Remove(items[index]);
    }


    public void Serialize()
    {
        if (save.items.Count > 0)
        {
            save.items.Clear();
        }

        foreach (var x in items)
        {
            save.items.Add(new InventoryItem(x.name, x.image.name));
        }
        string json = JsonUtility.ToJson(save, true);
        string directory = Application.persistentDataPath;
        File.WriteAllText(directory + @"\save.json", json);
        Debug.Log(directory);
    }

    public void Deserialize(string json)
    {
        items.Clear();
        Debug.Log("Beginning Deserialization");
        var newInventory = new PlayerSave();
        JsonUtility.FromJsonOverwrite(json, newInventory);
        foreach (var item in newInventory.items)
        {
            Sprite newSprite = Resources.Load<Sprite>(@"Sprites\" + item.spriteName);
            var temp = new ItemBehaviour();
            temp.image = newSprite;
            temp.name = item.itemName;
            items.Add(temp);
        }

    }
}