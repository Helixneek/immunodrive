using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
     public Animator animator;

     int levelToLoad;
     public string popUp;
     
    [SerializeField] float gameOverLoadDelay = 2f;

   public void LoadGame() {
          Debug.Log("Load game");
          //levelToLoad = Random.Range(1, 5);
          levelToLoad = 2;
          SceneManager.LoadScene(levelToLoad);
          //FadeToLevel(1);
   }

   public void LoadOptions() {
          Debug.Log("Load options");

          PopUpSystem pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpSystem>();
          pop.PopUp("Volume");
   }

   public void LoadNewStage() {
          levelToLoad = Random.Range(1, 5);
          SceneManager.LoadScene(levelToLoad);
   }

   public void LoadMainMenu() {
        SceneManager.LoadScene(0);
   }

   public void QuitToMainMenu() {
          SceneManager.LoadScene(0);
          Time.timeScale = 1;
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

}
