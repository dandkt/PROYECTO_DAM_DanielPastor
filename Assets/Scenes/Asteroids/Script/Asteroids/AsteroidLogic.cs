using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidLogic : MonoBehaviour
{
    private float _asteroidSpeed;
    public GameObject asteroid;
    private int limitMinSpeed = 10;
    private int limitMaxSpeed = 20;
    private int asteroidsRemaining;

    private int activeItem;
  
    private bool flag = true;

    public GameObject heartItem;
  
    Rigidbody rb;
   //private int collisioner = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        asteroidsRemaining = 5;
        _asteroidSpeed = Random.Range(limitMinSpeed,limitMaxSpeed);
            InvokeRepeating("changedFlag",3f,3f);
            InvokeRepeating("moreSpeed",10f,5f);
       
    }

   private bool changedFlag(){
        flag =! flag;
        return flag;
   }

    
    private void moreSpeed(){
        limitMinSpeed ++;
        limitMaxSpeed ++;
    }

    
    private void FixedUpdate() {
        transform.position -= new Vector3(0,_asteroidSpeed * Time.deltaTime,0); 
        if(transform.position.y < -50.4f){
            Destroy(gameObject);
            Destroy(asteroid);
        }

    }
    private void OnCollisionEnter(Collision other) {
        activeItem = Random.Range(1,5);
        if(other.gameObject.name == "Bala(Clone)"){
            Destroy(gameObject);
            SpawnAsteroids();
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "ship"){
          Destroy(this.gameObject);
        }
        
    }
    private void SpawnAsteroids(){

        if(flag){
            for (int i = 0; i < asteroidsRemaining; i++) {
                asteroid = Instantiate(Resources.Load("Small"),new Vector3(Random.Range(-19.1f,41.5f),
                Random.Range(27.9f,12.6f), 4.7f),Quaternion.Euler(0,0,Random.Range(-0.0f, 359.0f))) as GameObject;
            }
            activeItem = Random.Range(1,5);
           Instantiate(Resources.Load("heartItem"),new Vector3(asteroid.transform.position.x,asteroid.transform.position.y + 2.0f,asteroid.transform.position.z),Quaternion.Euler(0,0,0));    
           /*activeItem = 3;
           Debug.Log("ActiveItem: "+activeItem);
           if(activeItem == 3){
                Debug.Log("Creando corazon");
                Instantiate(heartItem,new Vector3(asteroid.transform.position.x,asteroid.transform.position.y + 2.0f,asteroid.transform.position.z),Quaternion.identity);
                Debug.Log(heartItem.transform.position);
                Debug.Log("Corazón creado");
           }*/
        }else{
           
           Destroy(asteroid);
           
        }
    }
}
