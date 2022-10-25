using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public List<Items> itemList;

    public Inventory() {
        itemList = new List<Items>();

        AddItem(new Items { itemType = Items.ItemType.DamageUp, 
                            upgradeName = "Manmelter",
                            dmgUp = 5f,
                            spdUp = 0f,
                            hpUp = 0f,
                            rofUp = 0f});
        Debug.Log(itemList.Count);
    }

    public void AddItem(Items item) {
        itemList.Add(item);
    }

    public List<Items> GetItemList() {
        return itemList;
    }
}
