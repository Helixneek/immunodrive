using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawn enemySpawner;
    [SerializeField] WaveConfigSO waveConfig;
    int waveNum;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Awake() {
        enemySpawner = FindObjectOfType<EnemySpawn>();
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        waveNum = enemySpawner.GetWaveNumber();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath() {
        if(waypointIndex < waypoints.Count) {
            Vector3 targetPos = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            
            transform.position = Vector3.MoveTowards(transform.position, targetPos, delta);

            if(transform.position == targetPos) {
                waypointIndex++;
            }
        } else {
            if(waveNum == 3 || waveNum == 5) {
                waypointIndex = 0;
            } else {
                Destroy(gameObject);
            }
        }
    }
}
