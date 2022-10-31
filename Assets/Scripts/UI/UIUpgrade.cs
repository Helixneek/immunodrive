using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIUpgrade : MonoBehaviour
{
    PopUpSystem pop;
    PlayerMove playerMove;
    Health health;
    Shooter shooter;
    [SerializeField] private UI_Inventory uiInventory;
    private Inventory inventory;
    float delay = 1f;

    public Text txt;
    string upgradeChosenA;
    string upgradeChosenB;
    [SerializeField] public List<string> upgradeName = new List<string>();

    void Awake() {
        playerMove = FindObjectOfType<PlayerMove>();
        shooter = FindObjectOfType<Shooter>();
        health = FindObjectOfType<Health>();
    }

    void Start() {
        inventory = new Inventory();
    }    

    public void UpgradeMenuAppear() {
        StartCoroutine(WaitForAppear());
    }

    IEnumerator WaitForAppear() {
        yield return new WaitForSeconds(delay);

        pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpSystem>();
        upgradeChosenA = upgradeName[Random.Range(0, upgradeName.Count)];
        upgradeChosenB = upgradeName[Random.Range(0, upgradeName.Count)];
        // Random.Range(0, upgradeName.Count)

        pop.UpgradePop(upgradeChosenA, upgradeChosenB);
    }

    public void LevelIncreaseA() {
        switch(upgradeChosenA) {
            case "Upgrade Speed":
                inventory.SpeedLevelUp();
                uiInventory.SetInventory(inventory);
                playerMove.SetSpeed();
                break;
            
            case "Upgrade Health":
                inventory.HealthLevelUp();
                uiInventory.SetInventory(inventory);
                health.SetHealth();
                break;

            case "Upgrade Fire Rate":
                inventory.FireRateLevelUp();
                uiInventory.SetInventory(inventory);
                shooter.SetFireRate();
                break;

            case "Add More Guns":
                inventory.GunsLevelUp();
                uiInventory.SetInventory(inventory);
                break;
        }
    }

    public void LevelIncreaseB() {
        switch(upgradeChosenB) {
            case "Upgrade Speed":
                inventory.SpeedLevelUp();
                uiInventory.SetInventory(inventory);
                playerMove.SetSpeed();
                break;
            
            case "Upgrade Health":
                inventory.HealthLevelUp();
                uiInventory.SetInventory(inventory);
                health.SetHealth();
                break;

            case "Upgrade Fire Rate":
                inventory.FireRateLevelUp();
                uiInventory.SetInventory(inventory);
                shooter.SetFireRate();
                break;

            case "Add More Guns":
                inventory.GunsLevelUp();
                uiInventory.SetInventory(inventory);
                break;
        }
    }
}
