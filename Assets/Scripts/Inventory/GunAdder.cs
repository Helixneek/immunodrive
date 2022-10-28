using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAdder : MonoBehaviour
{
    
    [SerializeField] GameObject upperGun;
    [SerializeField] GameObject lowerGun;
    [SerializeField] GameObject upperUpperGun;
    [SerializeField] GameObject lowerLowerGun;
    

    private Inventory inventory;
    public int gunAmount = 0;

    void Start() {
        inventory = new Inventory();
    }

    void Update() {
        SetExtraGuns();
        ActivateGuns();
    }

    void SetExtraGuns() {
        gunAmount = inventory.GetGuns();

        if(gunAmount > 4) {
            gunAmount = 4;
        }
    }

    void ActivateGuns() {
        for (int i = 1; i < gunAmount + 1; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        /*
        if(gunAmount == 1) {
            upperGun.SetActive(true);
        } else if(gunAmount == 2) {
            upperGun.SetActive(true);
            lowerGun.SetActive(true);
        } else if(gunAmount == 3) {
            upperGun.SetActive(true);
            lowerGun.SetActive(true);
            upperUpperGun.SetActive(true);
        } else if(gunAmount > 4) {
            upperGun.SetActive(true);
            lowerGun.SetActive(true);
            upperUpperGun.SetActive(true);
            lowerLowerGun.SetActive(true);
        }
        */
    }
}
