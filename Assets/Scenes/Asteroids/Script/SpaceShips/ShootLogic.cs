using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLogic : MonoBehaviour
{   
    
    public GameObject Beamsmodel1;
    public GameObject Beamsmodel2;
    public GameObject Beamsmodel3;
    public AudioSource audioShoot;
    public GameObject Beamsmodel4;
    private GameObject shooter;
     private GameObject myPlayerObject;
    void Start()
    {
         InvokeRepeating("shooting",1f,1.5f);
    }
    void shooting(){
    myPlayerObject = GameObject.FindWithTag("Player");
    
    if(myPlayerObject){
        if(gameObject.name == "Model1Grey(Clone)"){
            Instantiate(Beamsmodel1,transform.position + new Vector3(0,-7.52f,0.0f),Quaternion.identity);
            audioShoot.Play();
        }else if(gameObject.name == "Model1Red(Clone)"){
            Instantiate(Beamsmodel1,transform.position + new Vector3(0,-7.52f,0.0f),Quaternion.identity);
            audioShoot.Play();
        }else if(gameObject.name == "Model2_Grey(Clone)" ){
            Instantiate(Beamsmodel2,transform.position + new Vector3(0,-7.52f,0.0f),Quaternion.identity);
            audioShoot.Play();
        }else if( gameObject.name == "Model2_Red(Clone)"){
            Instantiate(Beamsmodel2,transform.position + new Vector3(0,-7.52f,0.0f),Quaternion.identity);
            audioShoot.Play();
        }else if(gameObject.name == "Model3Grey(Clone)" ){
            Instantiate(Beamsmodel3,transform.position + new Vector3(0,-7.52f,0.0f),Quaternion.identity);
            audioShoot.Play();
        }else if( gameObject.name == "Model3Red(Clone)"){
            Instantiate(Beamsmodel3,transform.position + new Vector3(0,-7.52f,0.0f),Quaternion.identity);
            audioShoot.Play();    
        }else if(gameObject.name == "Model4Red(Clone)"){
            Instantiate(Beamsmodel4,transform.position + new Vector3(0,-7.52f,0.0f),Quaternion.identity);
            audioShoot.Play();
        }else if(gameObject.name == "Model4Grey(Clone)"){
            shooter = GameObject.Find($"Shotter");
            Instantiate(Beamsmodel4,transform.position + new Vector3(0,-7.52f,0.0f),Quaternion.identity);
            audioShoot.Play();
        }else{
            Debug.Log("Nothing: "+gameObject.name);
        }
    }
       
    }
}
