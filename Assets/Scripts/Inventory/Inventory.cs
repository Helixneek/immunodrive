using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnListChange;
    public List<Items> itemList;

    float tempDamage;

    public Inventory() {
        itemList = new List<Items>();
        
        AddItem(new Items { itemType = Items.ItemType.damageUp, 
                            upgradeName = "Membrane Melter",
                            dmgUp = 5f,
                            spdUp = 0f,
                            hpUp = 0f,
                            rofUp = 0f,
                            shotModID = 0});

        AddItem(new Items { itemType = Items.ItemType.speedUp, 
                            upgradeName = "ATP Efficiency",
                            dmgUp = 0f,
                            spdUp = 5f,
                            hpUp = 0f,
                            rofUp = 0f,
                            shotModID = 0});
        
        AddItem(new Items { itemType = Items.ItemType.moreGuns, 
                            upgradeName = "Flexible Fibres",
                            dmgUp = 0f,
                            spdUp = 3f,
                            hpUp = 0f,
                            rofUp = 0f,
                            shotModID = 0});
        
        AddItem(new Items { itemType = Items.ItemType.healthUp, 
                            upgradeName = "Flexible Fibres",
                            dmgUp = 0f,
                            spdUp = 3f,
                            hpUp = 0f,
                            rofUp = 0f,
                            shotModID = 0});

        AddItem(new Items { itemType = Items.ItemType.firerateUp, 
                            upgradeName = "Flexible Fibres",
                            dmgUp = 0f,
                            spdUp = 3f,
                            hpUp = 0f,
                            rofUp = 0f,
                            shotModID = 0});
        
        AddItem(new Items { itemType = Items.ItemType.shotMod, 
                            upgradeName = "Flexible Fibres",
                            dmgUp = 0f,
                            spdUp = 3f,
                            hpUp = 0f,
                            rofUp = 0f,
                            shotModID = 0});

        Debug.Log(itemList.Count);
    }

    public void AddItem(Items item) {
        itemList.Add(item);
        OnListChange?.Invoke(this, EventArgs.Empty);
    }

    public List<Items> GetItemList() {
        return itemList;
    }

    public float GetDamage() {
        foreach(Items item in itemList) {
            tempDamage += item.dmgUp;
        }

        return tempDamage;
    }
}
