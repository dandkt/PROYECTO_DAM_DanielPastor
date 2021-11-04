using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private float _limitScreenMaxX = 73f;
    private float _limitScreenMinX = -48.7f;
    private float microSpeed = 5f;

    private int liveModel1= 1;
    private int liveModel2 = 2;
    private int liveModel3 = 3;
    private int liveModel4 = 4;
    void Start()
    {
        InvokeRepeating("incrementsSpeed",1f,15f);
        
    }

    void incrementsSpeed(){
        microSpeed ++;
    }
    
    
    void Update()
    {
       
        if (transform.position.x > _limitScreenMaxX) {
                transform.position = new Vector3(_limitScreenMinX,transform.position.y,3.7f);
                
        }
        if(transform.position.x < _limitScreenMinX){
                transform.position = new Vector3(_limitScreenMaxX, transform.position.y, 3.7f);
        }
        transform.position += new Vector3(Time.deltaTime * microSpeed, 0, 0);
       

        
    }

    private void OnCollisionEnter(Collision other) {
        
        if(other.gameObject.name == "Bala(Clone)"){
            Destroy(other.gameObject);
            if(gameObject.name == "Model1Red(Clone)" | gameObject.name =="Model1Grey(Clone)"){
              
                liveModel1 --;
                if(liveModel1 == 0){  
                 Destroy(gameObject);
                 liveModel1 = 1;
                } 
            }
            if(gameObject.name == "Model2_Red(Clone)" | gameObject.name =="Model2_Grey(Clone)"){
               
                liveModel2 --;
                if(liveModel2 == 0){  
                 Destroy(gameObject);
                 liveModel2 = 2;
                } 
            }
            if(gameObject.name == "Model3Red(Clone)" | gameObject.name =="Model3Grey(Clone)"){
               
                liveModel3 --;
                if(liveModel3 == 0){  
                 Destroy(gameObject);
                 liveModel3 = 3;
                } 
            }
             if(gameObject.name == "Model4Red(Clone)" | gameObject.name =="Model4Grey(Clone)"){
              
                liveModel4 --;
                if(liveModel4 == 0){  
                 Destroy(gameObject);
                 liveModel3 = 4;
                } 
            }

        }
        
    }

   
}
