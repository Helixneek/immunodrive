using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
    AudioPlayer audioPlayer;

    public void PlayButtonSFX() {
        audioPlayer.PlayButtonClip();
    }
}
