using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance {get; private set;}

    void Awake() {
        Instance = this;
    }

    public Sprite DamageUp;
    public Sprite SpeedUp;
    public Sprite HealthUp;
    public Sprite ShotMod;
    public Sprite MoreGuns;

}
