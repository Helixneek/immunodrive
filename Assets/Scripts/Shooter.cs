using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;

    [Header("Player")]
    [SerializeField] float playerFiringRate = 1f;

    [Header("AI")]
    [SerializeField] float enemyFiringRate = 2f;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;
    [SerializeField] bool useAI;

    [HideInInspector] public bool isFiring;

    AudioPlayer audioPlayer;

    Coroutine firingCoroutine;

    GameObject instance;
    private Inventory inventory;

    void Awake() {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if(useAI) {
            
            isFiring = true;
        }

        inventory = new Inventory(); 

        SetFireRate();
    }

    void Update()
    {
        Fire();
    }

    void Fire() {
        
        if(isFiring && firingCoroutine == null) {

            firingCoroutine = StartCoroutine(FireContinously());

        } else if(!isFiring && firingCoroutine != null) {

            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
        
    }

    IEnumerator FireContinously() {

        while(true) {
            GameObject instance = Instantiate(projectilePrefab, 
                                            transform.position, 
                                            Quaternion.Euler(0, 0, 270));

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb != null && useAI == false) {
                
                rb.velocity = transform.right * projectileSpeed;

            } else if(rb != null && useAI == true) {

                rb.velocity = -transform.right * projectileSpeed;

            }

            float bulletSpawnTime = Random.Range(enemyFiringRate - firingRateVariance, enemyFiringRate + firingRateVariance);

            audioPlayer.PlayShootingClip();

            Destroy(instance, projectileLifetime);

            if(useAI == true) {
                yield return new WaitForSeconds(Mathf.Clamp(bulletSpawnTime, minimumFiringRate, float.MaxValue));
            } else {
                yield return new WaitForSeconds(playerFiringRate);
            }
            
        }
    }

    public void SetFireRate() {
        playerFiringRate -= inventory.GetROF();
    }

}
