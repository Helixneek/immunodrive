using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 1f;

    [Header("Button")]
    [SerializeField] AudioClip buttonClip;
    [SerializeField] [Range(0f, 1f)] float buttonVolume = 1f;

    static AudioPlayer instance;

    public AudioPlayer GetInstance() {
        return instance;
    }

    public void Awake() {
        ManageSingleton();
    }

    void ManageSingleton() {
        if(instance != null) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip() {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayDamageClip() {
        PlayClip(damageClip, damageVolume);
    }

    public void PlayButtonClip() {
        PlayClip(buttonClip, buttonVolume);
    }

    void PlayClip(AudioClip clip, float volume) {
        if(clip != null) {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
