using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LogicScript : MonoBehaviour
{
  
  public GameObject welcomeScreen;
  public GameObject asteroidSpawn;
  public GameObject enemySpawn;

  public GameObject gameOverScreen;
  public void startGame()
  {
   welcomeScreen.SetActive(false);
   asteroidSpawn.SetActive(true);
   enemySpawn.SetActive(true);
  }

  public void restartGame()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);

  }

  public void gameOver()
  {
    gameOverScreen.SetActive(true);
  }

}
