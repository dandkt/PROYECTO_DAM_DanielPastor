using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLogic : MonoBehaviour
{
    
     public float collision = 4f;
     public bool oneShoot = true;
     public bool twoShoot = false;
     public bool threeShoot = false;
     public bool fourShoot = false;
     public AudioSource destroyBlocks;
    private GameObject[] listBlocks;
    private int counter = 0;
    static public int blocks;
    //añadir habilidades
    public GameObject bigBall;
    public GameObject cloneRaquet;
    public GameObject shortPlatform;
    
    private float tiempo;

    private int randomAbility;
    private GameObject racket;
    private float temporizador;
    private GameObject ball;
    //añadir habilidades

    
   private void Start() {
        listBlocks = GameObject.FindGameObjectsWithTag("block");
        blocks = listBlocks.Length;
        tiempo = 20;
        temporizador = 5;
        racket = GameObject.Find("racket");
        ball = GameObject.Find("ball");
    }
    private void FixedUpdate() {

        if(tiempo <=0){
          randomAbility = Random.Range(0,10);
          var localScaleRacket =  racket.gameObject.transform.localScale;
          var localScaleBall = ball.gameObject.transform.localScale;
          GameObject raquetClone = GameObject.Find("racket(Clone)");
          if(temporizador <= 0.0f){
              racket.gameObject.transform.localScale = new Vector3(1.953189f,1.953189f,1.953189f);
              ball.gameObject.transform.localScale = new Vector3(2.008f,2.008f,2.008f);
              if(raquetClone != null){
                //  Debug.Log("Destroy(raquetClone)");
                Destroy(raquetClone);
              }
              tiempo = 20;
              temporizador = 7.55f;
          }else{
              temporizador -= Time.deltaTime;
              Debug.Log($"Temporizador: {temporizador}");
          }
          /*  
           preparado para cuando se tenga más tiempo hacer la de alargar la raqueta también
           switch(localScaleRacket){
               case Vector3 n when (n == new Vector3(3.5f,3.5f,3.5f)):
                    racket.gameObject.transform.localScale = new Vector3(1.953189f,1.953189f,1.953189f);
                    tiempo = 5;
                    Debug.Log("Large Ability");
                break;*/
                //disminuir la raqueta
                /*case Vector3 n when (n == new Vector3(1.0f,1.0f,1.0f)):
                    racket.gameObject.transform.localScale = new Vector3(1.953189f,1.953189f,1.953189f);
                    tiempo = 5;
                     Debug.Log("Short Ability");
                break;
            }
            if(racket.gameObject.transform.localScale == new Vector3(3.5f,3.5f,3.5f)){
                racket.gameObject.transform.localScale = new Vector3(1.953189f,1.953189f,1.953189f);
                tiempo = 20;
            }*/
            
        }else{
            tiempo -= Time.deltaTime * 2.0f;
          // Debug.Log($"tiempo:{tiempo}");
        }
    }
    
    private void OnCollisionEnter2D(Collision2D info) {
      
        if(oneShoot){
            
            Destroy(gameObject);
            blocks --;
            destroyBlocks.Play();
        }
        if(twoShoot){
            collision --;
            if(collision == 0){
                createAbility(randomAbility);
                Destroy(gameObject);
                blocks --;
                destroyBlocks.Play();
            }
        }
        if(threeShoot){
            collision --;
            if(collision == 0){
                Destroy(gameObject);
                blocks --;
                destroyBlocks.Play();
            }
        }
        if(fourShoot){
            collision --;
            if(collision == 0){
                Destroy(gameObject);
                blocks --;
                destroyBlocks.Play();
            }
        }
        if(counter > 10){
         counter = 0;
        }
        //Debug.Log(blocks);
    }
    private void createAbility(int ability){
        
        switch(ability){
            /*case 0:
            case 1:*/
            case 3:
                 Instantiate(bigBall,new Vector3(gameObject.transform.position.x,
                   gameObject.transform.position.y - 2,639.1391f),Quaternion.identity);
                break;
           /* case 2:
            case 4:*/
            case 5:
            Instantiate(shortPlatform,new Vector3(gameObject.transform.position.x,
                   gameObject.transform.position.y - 2,639.1391f),Quaternion.identity);
                break; 
            /*case 6:
            case 7:
            case 8:*/
            case 9:
            Instantiate(cloneRaquet,new Vector3(gameObject.transform.position.x,
                   gameObject.transform.position.y - 2,639.1391f),Quaternion.identity);
            break;
        }
    }
}
