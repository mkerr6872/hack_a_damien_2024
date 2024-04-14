using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LogicScript : MonoBehaviour
{
  
  public GameObject welcomeScreen;
  public GameObject asteroidSpawn;
  public GameObject enemySpawn;

  public void startGame()
  {
   //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   welcomeScreen.SetActive(false);
   asteroidSpawn.SetActive(true);
   enemySpawn.SetActive(true);
  }

}
