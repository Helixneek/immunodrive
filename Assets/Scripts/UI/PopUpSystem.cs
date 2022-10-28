using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpSystem : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator animator;
    public TextMeshProUGUI popUpText;
    public TextMeshProUGUI upgradeTextA;
    public TextMeshProUGUI upgradeTextB;

    public void PopUp(string text) {
        popUpBox.SetActive(true);
        popUpText.text = text;
        animator.SetTrigger("pop");
    }

    public void UpgradePop(string textA, string textB) {
        popUpBox.SetActive(true);
        upgradeTextA.text = textA;
        upgradeTextB.text = textB;
        animator.SetTrigger("pop");
    }
}
