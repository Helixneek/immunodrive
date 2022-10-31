using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] bool isMiniBoss;
    [SerializeField] bool isBoss;
    [SerializeField] bool isFinalBoss;
    [SerializeField] public int healthPoints = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;
    
    [SerializeField] bool applyCameraShake;
    private Inventory inventory;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    UIUpgrade upgradeUI;

    public static Health instance { get; private set; }

    public int GetHealth() {
        return healthPoints;
    }

    void Awake() {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
        upgradeUI = levelManager.GetComponent<UIUpgrade>();

        ManageSingleton();
    }

    void Start() {
        inventory = new Inventory();   

        SetHealth();
    }

    void ManageSingleton() {
        if(instance != null && isPlayer) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else if(isPlayer) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public void SetHealth() {
        if(isPlayer) {
            healthPoints += inventory.GetHealth();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        TakeDamage(damageDealer.GetDamage());
        PlayHitEffect();
        audioPlayer.PlayDamageClip();
        ShakeCamera();
        damageDealer.GetHit(); 
    }

    void TakeDamage(int damage) {
        healthPoints -= damage;

        if(healthPoints <= 0) {

            Die();
        }
    }

    void Die() {
        if(!isPlayer && isFinalBoss) {
            scoreKeeper.ModifyScore(score);
            levelManager.LoadGameOver();
        } else if(!isPlayer && isBoss) {
            scoreKeeper.ModifyScore(score);
            upgradeUI.UpgradeMenuAppear();
            levelManager.LoadNextLevel();
        } else if(!isPlayer && isMiniBoss) {
            scoreKeeper.ModifyScore(score);
            upgradeUI.UpgradeMenuAppear();
        } else if(!isPlayer) {
            scoreKeeper.ModifyScore(score);
        } else {
            levelManager.LoadGameOver();
        }

        Destroy(gameObject);
    }

    void PlayHitEffect() {
        if(hitEffect != null) {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera() {
        if(cameraShake != null && applyCameraShake) {
                cameraShake.Play();
        }
    }
}
