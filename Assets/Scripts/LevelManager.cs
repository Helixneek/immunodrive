using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float gameOverLoadDelay = 2f;

   public void LoadGame() {
          Debug.Log("Load game");
          // SceneManager.LoadScene("Game");
   }

   public void LoadOptions() {
          Debug.Log("Load options");
          // SceneManager.LoadScene("Game");
   }

   public void LoadMainMenu() {
        SceneManager.LoadScene("Main Menu");
   }

   public void LoadGameOver() {
        StartCoroutine(WaitAndLoad("Game Over", gameOverLoadDelay));
   }

   public void QuitGame() {
        Debug.Log("Game quitting...");
        Application.Quit();
   }

   IEnumerator WaitAndLoad(string sceneName, float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
   }
}
