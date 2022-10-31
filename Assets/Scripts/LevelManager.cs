using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
     public Animator animator;
     int levelToLoad;
     int previousLevel;
     public string popUp;
     
    [SerializeField] float gameOverLoadDelay = 2f;
    [SerializeField] float nextGameDelay = 2f;

   public void LoadGame() {
          Debug.Log("Load game");
          levelToLoad = Random.Range(1, 5);
          previousLevel = SceneManager.GetActiveScene().buildIndex;
          while(levelToLoad == previousLevel) {
               levelToLoad = Random.Range(1, 5);
          }

          FindObjectOfType<StageTracker>().NextStage();
          SceneManager.LoadScene(levelToLoad);
   }

     public void LoadNextLevel() {
          levelToLoad = Random.Range(1, 5);
          previousLevel = SceneManager.GetActiveScene().buildIndex;
          while(levelToLoad == previousLevel) {
               levelToLoad = Random.Range(1, 5);
          }

          FindObjectOfType<StageTracker>().NextStage();
          StartCoroutine(WaitAndLoad(levelToLoad, nextGameDelay));
     }

   public void LoadOptions() {
          Debug.Log("Load options");

          PopUpSystem pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpSystem>();
          pop.PopUp("Volume");
   }

   public void LoadControls() {
          PopUpSystem controlpop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpSystem>();
          controlpop.ControlPop();
   }

   public void LoadMainMenu() {
        SceneManager.LoadScene(0);
   }

   public void QuitToMainMenu() {
          SceneManager.LoadScene(0);
          Time.timeScale = 1;
   }

   public void LoadGameOver() {
        StartCoroutine(WaitAndLoad(6, gameOverLoadDelay));
   }

   public void QuitGame() {
        Debug.Log("Game quitting...");
        Application.Quit();
   }

   IEnumerator WaitAndLoad(int sceneIndex, float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
   }

}
