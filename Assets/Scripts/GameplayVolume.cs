using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayVolume : MonoBehaviour
{
    public GameObject audioSource;

    void Start() {
        audioSource = GameObject.Find("Audio Player");

        if(PlayerPrefs.HasKey("musicVolume")) {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        } else {
            Load();
        }
    }

    private void Load() {
        audioSource.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("musicVolume");
    }
}
