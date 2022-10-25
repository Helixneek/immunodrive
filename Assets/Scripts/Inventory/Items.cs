using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items
{
    public enum ItemType {
        DamageUp,
        SpeedUp,
        HealthUp,
        FireRateUp,
        ShotMod,
        MoreGuns
    }

    public ItemType itemType;
    public string upgradeName;
    public float dmgUp;
    public float spdUp;
    public float hpUp;
    public float rofUp;

    public Sprite GetSprite() {
        switch(itemType) {
            default:
                case ItemType.DamageUp:     return ItemAssets.Instance.DamageUpSprite;
                case ItemType.SpeedUp:      return ItemAssets.Instance.SpeedUpSprite;
                case ItemType.HealthUp:     return ItemAssets.Instance.HealthUpSprite;
                case ItemType.FireRateUp:   return ItemAssets.Instance.FireRateUpSprite;
                case ItemType.ShotMod:      return ItemAssets.Instance.ShotModSprite;
                case ItemType.MoreGuns:     return ItemAssets.Instance.MoreGunsSprite;
        }
    }
}
