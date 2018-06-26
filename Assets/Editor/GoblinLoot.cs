using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LootTable")]
public class GoblinLoot : ScriptableObject
{
    [SerializeField]
    private List<Item> items;
}
