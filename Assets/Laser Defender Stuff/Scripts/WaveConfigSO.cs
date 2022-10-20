using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{   
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float enemyMoveSpeed = 2f;
    [SerializeField] float timeBetweenSpawn = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 2f;
    
    //int enemyIndex = 0;

    public float GetMoveSpeed() {

        return enemyMoveSpeed;
    }

    public Transform GetStartingWaypoint() {

        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints() {

        List<Transform> waypoints = new List<Transform>();
        foreach(Transform child in pathPrefab) {
            waypoints.Add(child);
        }

        return waypoints;
    }

    public int GetEnemyCount() {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefabs(int index) {
        return enemyPrefabs[index];
    }

    public float GetRandomSpawnTime() {
        float spawnTime = Random.Range(timeBetweenSpawn - spawnTimeVariance,
                                        timeBetweenSpawn + spawnTimeVariance);

        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
