using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Player Upgrade")]
public class Upgrade : ScriptableObject
{
    public string upgradeName;
    public string itemType;

    public Sprite artwork;

    public float dmgUp;
    public float spdUp;
    public float hpUp;
    public float rofUp;
    public int shotModID;
}
