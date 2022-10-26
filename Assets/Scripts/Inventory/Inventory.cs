using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnListChange;
    public List<Items> itemList;

    int tempDamage;
    float tempSpeed;
    int tempHP;
    float tempROF;

    public Inventory() {
        itemList = new List<Items>();
        
        AddItem(new Items { itemType = Items.ItemType.damageUp, 
                            level = 1,
                            dmgUp = 21,
                            spdUp = 0f,
                            hpUp = 0,
                            rofUp = 0f,
                            shotModID = 0});

        AddItem(new Items { itemType = Items.ItemType.speedUp,
                            level = 1, 
                            dmgUp = 0,
                            spdUp = 5f,
                            hpUp = 0,
                            rofUp = 0f,
                            shotModID = 0});
        
        AddItem(new Items { itemType = Items.ItemType.moreGuns, 
                            level = 1,
                            dmgUp = 0,
                            spdUp = 3f,
                            hpUp = 0,
                            rofUp = 0f,
                            shotModID = 0});
        
        AddItem(new Items { itemType = Items.ItemType.healthUp, 
                            level = 1,
                            dmgUp = 0,
                            spdUp = 3f,
                            hpUp = 0,
                            rofUp = 0f,
                            shotModID = 0});

        AddItem(new Items { itemType = Items.ItemType.firerateUp, 
                            level = 1,
                            dmgUp = 0,
                            spdUp = 3f,
                            hpUp = 0,
                            rofUp = 0f,
                            shotModID = 0});
        
        AddItem(new Items { itemType = Items.ItemType.moreGuns, 
                            level = 0,
                            dmgUp = 0,
                            spdUp = 0f,
                            hpUp = 0,
                            rofUp = 0f,
                            shotModID = 0});

        //Debug.Log(itemList.Count + " upgrades");
    }

    public void AddItem(Items item) {
        itemList.Add(item);
        OnListChange?.Invoke(this, EventArgs.Empty);
    }

    public List<Items> GetItemList() {
        return itemList;
    }

    public int GetDamage() {
        foreach(Items item in itemList) {
            tempDamage += item.dmgUp;
        }

        return tempDamage;
    }

    public float GetSpeed() {
        foreach(Items item in itemList) {
            tempSpeed += item.spdUp;
        }

        return tempSpeed;
    }

    public int GetHealth() {
        foreach(Items item in itemList) {
            tempHP += item.hpUp;
        }

        return tempHP;
    }

    public float GetROF() {
        foreach(Items item in itemList) {
            tempROF += item.rofUp;
        }

        return tempROF;
    }
}
