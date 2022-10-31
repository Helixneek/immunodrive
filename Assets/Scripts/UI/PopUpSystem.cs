using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpSystem : MonoBehaviour
{
    public GameObject popUpBox;
    public GameObject controlsBox;
    public Animator popUpAnimator;
    public Animator controlBoxAnimator;
    public TextMeshProUGUI popUpText;
    public TextMeshProUGUI upgradeTextA;
    public TextMeshProUGUI upgradeTextB;

    public void PopUp(string text) {
        popUpBox.SetActive(true);
        popUpText.text = text;
        popUpAnimator.SetTrigger("pop");
    }

    public void UpgradePop(string textA, string textB) {
        popUpBox.SetActive(true);
        upgradeTextA.text = textA;
        upgradeTextB.text = textB;
        popUpAnimator.SetTrigger("pop");
    }

    public void ControlPop() {
        controlsBox.SetActive(true);
        controlBoxAnimator.SetTrigger("pop");
    }
}
