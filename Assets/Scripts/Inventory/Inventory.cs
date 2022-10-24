using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public List<Items> itemList;

    public Inventory() {
        itemList = new List<Items>();

        AddItem(new Items { itemType = Items.ItemType.TypeA, amount = 1});
        AddItem(new Items { itemType = Items.ItemType.TypeB, amount = 2});
        AddItem(new Items { itemType = Items.ItemType.TypeC, amount = 3});
        Debug.Log(itemList.Count);
    }

    public void AddItem(Items item) {
        itemList.Add(item);
    }

    public List<Items> GetItemList() {
        return itemList;
    }
}
