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
    public int level;
    public int dmgUp;
    public float spdUp;
    public int hpUp;
    public float rofUp;
    public int moreguns;

    public Sprite GetSprite() {
        switch(itemType) {
           default:
                case ItemType.damageUp:     return ItemAssets.Instance.DamageUpSprite;
                case ItemType.speedUp:      return ItemAssets.Instance.SpeedUpSprite;
                case ItemType.healthUp:     return ItemAssets.Instance.HealthUpSprite;
                case ItemType.firerateUp:   return ItemAssets.Instance.FireRateUpSprite;
                case ItemType.moreGuns:     return ItemAssets.Instance.MoreGunSprite;
        }
        
    }
}
