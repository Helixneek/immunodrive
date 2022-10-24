using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public List<Items> itemList;

    public Inventory() {
        itemList = new List<Items>();

        AddItem(new Items { itemType = Items.ItemType.DamageUp, amount = 5});
        AddItem(new Items { itemType = Items.ItemType.SpeedUp, amount = 2});
        AddItem(new Items { itemType = Items.ItemType.HealthUp, amount = 30});
        Debug.Log(itemList.Count);
    }

    public void AddItem(Items item) {
        itemList.Add(item);
    }

    public List<Items> GetItemList() {
        return itemList;
    }
}
