using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    public GameObject astroid;
    public float spawnRate = 2;
    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
      Instantiate(astroid, transform.position, transform.rotation);   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if (timer < spawnRate){
        timer += Time.deltaTime;
      }
      else
      {
        Instantiate(astroid, transform.position, transform.rotation); 
        timer=0;
      }
    }
}
