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
    int tempGuns;

    public Inventory() {
        itemList = new List<Items>();
        
        AddItem(new Items { itemType = Items.ItemType.damageUp, 
                            level = 0,
                            dmgUp = 5,
                            spdUp = 0f,
                            hpUp = 0,
                            rofUp = 0f,
                            moreguns = 0});

        AddItem(new Items { itemType = Items.ItemType.speedUp,
                            level = 0, 
                            dmgUp = 0,
                            spdUp = 2f,
                            hpUp = 0,
                            rofUp = 0f,
                            moreguns = 0});
        
        AddItem(new Items { itemType = Items.ItemType.healthUp, 
                            level = 0,
                            dmgUp = 0,
                            spdUp = 0f,
                            hpUp = 50,
                            rofUp = 0f,
                            moreguns = 0});

        AddItem(new Items { itemType = Items.ItemType.firerateUp, 
                            level = 0,
                            dmgUp = 0,
                            spdUp = 0f,
                            hpUp = 0,
                            rofUp = 0.1f,
                            moreguns = 0});
        
        AddItem(new Items { itemType = Items.ItemType.moreGuns, 
                            level = 0,
                            dmgUp = 0,
                            spdUp = 0f,
                            hpUp = 0,
                            rofUp = 0f,
                            moreguns = 1});

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
            tempDamage += item.dmgUp * item.level;
        }

        return tempDamage;
    }

    public float GetSpeed() {
        foreach(Items item in itemList) {
            tempSpeed += item.spdUp * item.level;
        }
        
        return tempSpeed;
    }

    public int GetHealth() {
        foreach(Items item in itemList) {
            tempHP += item.hpUp * item.level;
        }

        return tempHP;
    }

    public float GetROF() {
        foreach(Items item in itemList) {
            tempROF += item.rofUp * item.level;
        }

        return tempROF;
    }

    public int GetGuns() {
        foreach(Items item in itemList) {
            tempGuns = item.moreguns * item.level;
        }

        return tempGuns;
    }

    public void SpeedLevelUp() {
        foreach(Items item in itemList) {
            if(item.itemType == Items.ItemType.speedUp) {
                item.level++;
                break;
            }
        }
    }

    public void HealthLevelUp() {
        foreach(Items item in itemList) {
            if(item.itemType == Items.ItemType.healthUp) {
                item.level++;
                break;
            }
        }
    }

    public void FireRateLevelUp() {
        foreach(Items item in itemList) {
            if(item.itemType == Items.ItemType.firerateUp) {
                item.level++;
                break;
            }
        }
    }

    public void GunsLevelUp() {
        foreach(Items item in itemList) {
            if(item.itemType == Items.ItemType.moreGuns) {
                item.level++;
                break;
            }
        }
    }
}
