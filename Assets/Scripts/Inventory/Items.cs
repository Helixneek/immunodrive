using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items
{
    public enum ItemType {
        damageUp,
        speedUp,
        healthUp,
        firerateUp,
        shotMod,
        moreGuns
    }

    public ItemType itemType;
    public string upgradeName;
    public float dmgUp;
    public float spdUp;
    public float hpUp;
    public float rofUp;
    public int shotModID;

    public Sprite GetSprite() {
        switch(itemType) {
           default:
                case ItemType.damageUp:     return ItemAssets.Instance.DamageUpSprite;
                case ItemType.speedUp:      return ItemAssets.Instance.SpeedUpSprite;
                case ItemType.healthUp:     return ItemAssets.Instance.HealthUpSprite;
                case ItemType.firerateUp:   return ItemAssets.Instance.FireRateUpSprite;
                case ItemType.shotMod:      return ItemAssets.Instance.ShotModSprite;
                case ItemType.moreGuns:     return ItemAssets.Instance.MoreGunSprite;
        }
        
    }
}
