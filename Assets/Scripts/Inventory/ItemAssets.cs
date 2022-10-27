using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance {get; private set;}

    void Awake() {
        Instance = this;
    }

    public Sprite DamageUpSprite;
    public Sprite SpeedUpSprite;
    public Sprite HealthUpSprite;
    public Sprite FireRateUpSprite;
    public Sprite MoreGunSprite;

}
