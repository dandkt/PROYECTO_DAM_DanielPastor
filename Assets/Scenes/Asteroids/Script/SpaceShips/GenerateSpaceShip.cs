using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSpaceShip : MonoBehaviour
{
    private bool isRed= true;
    public GameObject model1Red;
    public GameObject model1Grey;
    public GameObject model2Red;
    public GameObject model2Grey;
    public GameObject model3Red;
    public GameObject model3Grey;
    public GameObject model4Red;
    public GameObject model4Grey;
    private string modelString;

    private GameObject gameManagerFind;
    private GameObject myPlayerObject;

    ImpulsoBalaJugador impulsoBala;
    
    void Start()
    {
        InvokeRepeating("createModel1",1f,5f);
        InvokeRepeating("createModel2",5f,10f);
        InvokeRepeating("createModel3",10f,15f);
        InvokeRepeating("createModel4",15f,17f);
        gameManagerFind = GameObject.FindGameObjectWithTag("SpacesManager");
    }

    void createModel1()
    {
      myPlayerObject = GameObject.FindWithTag("Player");
     if(gameManagerFind.activeInHierarchy){ 
       if(myPlayerObject != null){
           var xPosition = Random.Range(-29.9f,-10.3f);
           //var xPosition = Random.Range(-29.9f,20.3f);
           
           var YPosition = Random.Range(32.2f,20.6f);
            if(isRed){ 
                Instantiate(model1Red,new Vector3(xPosition,YPosition,3.5f),Quaternion.Euler(76.276f,183.14f,3.051f));
                isRed = false;
            }else{
                Instantiate(model1Grey,new Vector3(xPosition,YPosition,3.5f),Quaternion.Euler(76.276f,183.14f,3.051f));
                isRed = true;
            }
        }
       }
       
        
    }

    void createModel2()
    {
        myPlayerObject = GameObject.FindWithTag("Player");
      if(gameManagerFind.activeInHierarchy){    
        if(myPlayerObject != null){
            var xPosition = Random.Range(-9.1f,0f);
            var YPosition = Random.Range(27.9f,12.6f);
            if(isRed){ 
                Instantiate(model2Red,new Vector3(xPosition,YPosition,3.5f),Quaternion.Euler(76.276f,183.14f,3.051f));
                isRed = false;
            }else{
                Instantiate(model2Grey,new Vector3(xPosition,YPosition,3.5f),Quaternion.Euler(76.276f,183.14f,3.051f));
                isRed = true;
            }
        }
      }
        /*else{
            Debug.Log("No hay nave espacial");
        }*/
    }
    void createModel3()
    {

      myPlayerObject = GameObject.FindWithTag("Player");
       if(gameManagerFind.activeInHierarchy){ 
            if(myPlayerObject != null){
                var xPosition = Random.Range(1.9f,10.3f);
                var YPosition = Random.Range(32.2f,20.6f);
                if(isRed){ 
                    Instantiate(model3Red,new Vector3(xPosition,YPosition,3.5f),Quaternion.Euler(76.276f,183.14f,3.051f));
                    isRed = false;
                }else{
                    Instantiate(model3Grey,new Vector3(xPosition,YPosition,3.5f),Quaternion.Euler(76.276f,183.14f,3.051f));
                    isRed = true;
                }
            }
       }
       /*else{
           //Debug.Log("No hay nave espacial");
       }*/
        
        
    }
    void createModel4()
    {

      myPlayerObject = GameObject.FindWithTag("Player");
    if(gameManagerFind.activeInHierarchy){  
       if(myPlayerObject != null){
           var xPosition = Random.Range(10.5f,20.3f);
            var YPosition = Random.Range(32.2f,20.6f);
            if(isRed){ 
                Instantiate(model4Red,new Vector3(xPosition,YPosition,3.5f),Quaternion.Euler(76.276f,183.14f,3.051f));
                isRed = false;
            }else{
                Instantiate(model4Grey,new Vector3(xPosition,YPosition,3.5f),Quaternion.Euler(76.276f,183.14f,3.051f));
                isRed = true;
        }
       }
    } 
       /*else{
           Debug.Log("No hay nave espacial");
       }*/
        
        
    }
}
