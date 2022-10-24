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
        ShotMod,
        MoreGuns
    }

    public ItemType itemType;
    public float amount;

    public Sprite GetSprite() {
        switch(itemType) {
            default:
                case ItemType.DamageUp: return ItemAssets.Instance.DamageUpSprite;
                case ItemType.SpeedUp: return ItemAssets.Instance.SpeedUpSprite;
                case ItemType.HealthUp: return ItemAssets.Instance.HealthUpSprite;
                case ItemType.ShotMod: return ItemAssets.Instance.ShotModSprite;
                case ItemType.MoreGuns: return ItemAssets.Instance.MoreGunsSprite;
        }
    }
}
