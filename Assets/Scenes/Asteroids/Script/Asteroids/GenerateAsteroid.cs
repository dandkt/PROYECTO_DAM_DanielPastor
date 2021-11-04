using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateAsteroid : MonoBehaviour
{
    public GameObject mediumAsteroid;
    private GameObject playerObject;

    private GameObject asteroidFind;
    private float lessTime = 3.5f;
    
    private void Start() {
        
        //InvokeRepeating("CreateBigAsteroid",2f,10f);
        InvokeRepeating("CreateMediumAsteroid",1f,lessTime);
        InvokeRepeating("lessTimer",5f,lessTime);
        asteroidFind = GameObject.FindGameObjectWithTag("AsteroidManager");
    }

    private void lessTimer(){
           lessTime = lessTime - 0.75f;
    }
    
    private void CreateMediumAsteroid(){
       if(asteroidFind.activeInHierarchy){
            var xPosition = Random.Range(-19.1f,41.5f);
            var YPosition = Random.Range(27.9f,12.6f);
            Instantiate(mediumAsteroid,new Vector3(xPosition,YPosition,3.7f),Quaternion.identity);
            
       }
    }
    
}
