using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageTracker : MonoBehaviour
{
    [SerializeField] int levelIndex;
    void Awake() {
        int numStageTracker = FindObjectsOfType<StageTracker>().Length;
        if(numStageTracker > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void NextStage() {
        levelIndex++;
    }

    public int GetStageIndex() {
        return levelIndex;
    }

    public void ProcessFinalStage() {
        if(levelIndex > 6) {
            
        } else {
            ResetGameSession();
        }
    }

    void ResetGameSession() {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
