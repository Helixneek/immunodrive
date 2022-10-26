using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
     public Animator animator;

     private int levelToLoad;
     
    [SerializeField] float gameOverLoadDelay = 2f;

   public void LoadGame() {
          Debug.Log("Load game");
          //SceneManager.LoadScene(1);
          FadeToLevel(1);
   }

   public void LoadOptions() {
          Debug.Log("Load options");
          // SceneManager.LoadScene("Game");
   }

   public void LoadMainMenu() {
        SceneManager.LoadScene("Main Menu");
   }

   public void LoadGameOver() {
        StartCoroutine(WaitAndLoad(0, gameOverLoadDelay));
   }

   public void QuitGame() {
        Debug.Log("Game quitting...");
        Application.Quit();
   }

   IEnumerator WaitAndLoad(int sceneIndex, float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
   }

   public void FadeToLevel (int levelIndex) {
          if(animator.gameObject.activeSelf) {
               levelToLoad = levelIndex;
               animator.SetTrigger("FadeOut");
          }
   }

   public void OnFadeComplete() {
          SceneManager.LoadScene(levelToLoad);
   }
}
