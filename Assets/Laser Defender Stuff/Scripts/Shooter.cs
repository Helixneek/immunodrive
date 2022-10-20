using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;

    [Header("AI")]
    [SerializeField] float firingRate = 2f;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;
    [SerializeField] bool useAI;

    [HideInInspector] public bool isFiring;

    AudioPlayer audioPlayer;

    Coroutine firingCoroutine;

    void Awake() {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if(useAI) {
            
            isFiring = true;
        }    
    }

    void Update()
    {
        Fire();
    }

    void Fire() {
        
        if(isFiring && firingCoroutine == null) {

            firingCoroutine = StartCoroutine(FireContinous());

        } else if(!isFiring && firingCoroutine != null) {

            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
        
    }

    IEnumerator FireContinous() {

        while(true) {
            GameObject instance = Instantiate(projectilePrefab, 
                                                transform.position, 
                                                Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb != null) {
                
                rb.velocity = transform.up * projectileSpeed;
            }

            float bulletSpawnTime = Random.Range(firingRate - firingRateVariance, firingRate + firingRateVariance);

            audioPlayer.PlayShootingClip();

            Destroy(instance, projectileLifetime);
            yield return new WaitForSeconds(Mathf.Clamp(bulletSpawnTime, minimumFiringRate, float.MaxValue));
        }
    }
}
