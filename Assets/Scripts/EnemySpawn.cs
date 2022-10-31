using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] WaveConfigSO finalBossConfig;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] float BossTime = 0f;
    [SerializeField] float timeBeforeStart = 0f;
    [SerializeField] bool isLooping;
    public int waveNum = 0;
    int stageIndex;
    WaveConfigSO currentWave;

    void Start()
    {
        stageIndex = FindObjectOfType<StageTracker>().GetStageIndex();
       StartCoroutine(SpawnEnemyWaves());
       Debug.Log("Stage " + stageIndex);
    }

    public WaveConfigSO GetCurrentWave() {
        return currentWave;
    }

    public int GetWaveNumber() {
        return waveNum;
    }

    IEnumerator SpawnEnemyWaves() {

        yield return new WaitForSeconds(timeBeforeStart);

        do {
            foreach(WaveConfigSO waves in waveConfigs) {
                waveNum++;
                if(stageIndex > 4 && waveNum == 5) {
                    currentWave = finalBossConfig;
                } else {
                    currentWave = waves;
                }
                
                for(int i = 0; i < currentWave.GetEnemyCount(); i++) {
                    Instantiate(currentWave.GetEnemyPrefabs(i), 
                            currentWave.GetStartingWaypoint().position,
                            Quaternion.identity,
                            transform);

                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                
                if(waveNum == 3 || waveNum == 5) {
                    yield return new WaitForSeconds(BossTime);
                } else {
                    yield return new WaitForSeconds(timeBetweenWaves);
                }
                
            }
        } while(isLooping);
    }
}
