using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    private Inventory playerInv;
    [SerializeField] int damageValue = 10;

    int tempDamage;

    void Start() {
        playerInv = new Inventory();
    } 

    void Update() {
        //tempDamage = playerInv.GetDamage();
        //Debug.Log(tempDamage + " damage");
    }

    public int GetDamage() {
        return damageValue;
    }

    public int GetPlayerDamage() {
        Debug.Log(tempDamage + damageValue + " damage dealt.");
        return tempDamage + damageValue;
    }

    public void GetHit() {
        Destroy(gameObject);
    }
}
