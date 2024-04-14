using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate = 10;
    public float timer = 0;
    
    public Vector3 startPos = new Vector3(0f,0f,0f);
    // spawn X range
    public float lowerPosX = -14f;
    public float upperPosX = 14f;

    //spawn Y range
    public float lowerPosY = -7f;
    public float upperPosY = 7f;

    //spawn strict Y
    //using strict will move it vertically out of camera
    public float strictUpperY = 5.5f;
    public float strictLowerY = -5.5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if (timer < spawnRate){
        timer += Time.deltaTime;
      }
      else
      {
        SpawnEnemy();
      }
    }

    //spawn asteroid
    void SpawnEnemy()
    {
      GetStartingPos();
      Instantiate(enemy, startPos, transform.rotation); 
      timer=0;
    }
    
    void GetStartingPos()
    {
      startPos.x = Random.Range(lowerPosX,upperPosX);
      //check if inside camera
      if (( 0 < startPos.x && startPos.x < 9f) || ( startPos.x < 0 && startPos.x > -9f)){
        if (Random.Range(0,1) < 0.5f){
          startPos.y = Random.Range(strictLowerY,lowerPosY);
        } else
        {
          startPos.y = Random.Range(strictUpperY,upperPosY);
        }
      }else
      {
        startPos.y = Random.Range(lowerPosY,upperPosY);
      }
      
    }


}
