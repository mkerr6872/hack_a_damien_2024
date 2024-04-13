using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    public GameObject asteroid;
    public float spawnRate = 2;
    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
      SpawnAsteroid();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if (timer < spawnRate){
        timer += Time.deltaTime;
      }
      else
      {
        SpawnAsteroid();
      }
    }

    //spawn asteroid
    void SpawnAsteroid()
    {

      Instantiate(asteroid, transform.position, transform.rotation); 
      timer=0;
    }
}
