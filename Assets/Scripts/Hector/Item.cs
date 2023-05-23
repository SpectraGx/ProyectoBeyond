using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Armor_1
    }
    public static int GetCost (ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Armor_1:  return 30; 
        }
    }

    public static Sprite GetSprite(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Armor_1:      return gameAssets.i.s_Armor_1;
        }
    }
}
