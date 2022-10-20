using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
   int currentScore = 0;

   static ScoreKeeper instance;

    public ScoreKeeper GetInstance() {
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

   public int GetScore() {
        return currentScore;
   }

   public void ModifyScore(int value) {
        currentScore += value;
        Mathf.Clamp(currentScore, 0, int.MaxValue);
        Debug.Log(currentScore);
   }

   public void ResetScore() {
        currentScore = 0;
   }
}
