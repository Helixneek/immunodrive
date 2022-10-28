using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIUpgrade : MonoBehaviour
{
    PopUpSystem pop;
    PlayerMove playerMove;
    Shooter shooter;
    [SerializeField] private UI_Inventory uiInventory;
    private Inventory inventory;
    float delay = 2f;

    public Text txt;
    string upgradeChosenA;
    string upgradeChosenB;
    [SerializeField] public List<string> upgradeName = new List<string>();

    void Awake() {
        playerMove = FindObjectOfType<PlayerMove>();
        shooter = FindObjectOfType<Shooter>();
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
        upgradeChosenA = upgradeName[Random.Range(0, upgradeName.Count - 1)];
        upgradeChosenB = upgradeName[Random.Range(0, upgradeName.Count - 1)];
        // Random.Range(0, upgradeName.Count)

        pop.UpgradePop(upgradeChosenA, upgradeChosenB);
    }

    public void LevelIncreaseA() {
        Time.timeScale = 0;

        switch(upgradeChosenA) {
            case "Upgrade Speed":
                inventory.SpeedLevelUp();
                uiInventory.SetInventory(inventory);
                Time.timeScale = 1;
                break;
            
            case "Upgrade Health":
                inventory.HealthLevelUp();
                uiInventory.SetInventory(inventory);
                Time.timeScale = 1;
                break;

            case "Upgrade Fire Rate":
                inventory.FireRateLevelUp();
                uiInventory.SetInventory(inventory);
                Time.timeScale = 1;
                break;

            case "Add More Guns":
                inventory.GunsLevelUp();
                uiInventory.SetInventory(inventory);
                Time.timeScale = 1;
                break;
        }
    }

    public void LevelIncreaseB() {
        switch(upgradeChosenA) {
            case "Upgrade Speed":
                inventory.SpeedLevelUp();
                uiInventory.SetInventory(inventory);
                break;
            
            case "Upgrade Health":
                inventory.HealthLevelUp();
                uiInventory.SetInventory(inventory);
                break;

            case "Upgrade Fire Rate":
                inventory.FireRateLevelUp();
                uiInventory.SetInventory(inventory);
                break;

            case "Add More Guns":
                inventory.GunsLevelUp();
                uiInventory.SetInventory(inventory);
                break;
        }
    }
}
