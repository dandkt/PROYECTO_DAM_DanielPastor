using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ImpulsoBalaJugador : MonoBehaviour
{
   
   public GameObject jugador;
   
   public int puntuacion;

   

    //public Text puntos;
    private void Start() {
        
        //puntuacion = PlayerPrefs.GetInt("puntuacion",0);
        //getPuntuacion();
       
    }
    
    
    
    
    void Update()
    {
        transform.Translate(Vector3.up*30f*Time.deltaTime);
        if(transform.position.y >= 40.4f){
            Destroy(gameObject);
        }
        //getPuntuacion();
        

    }
    
    private void OnCollisionEnter(Collision other) {
        
         puntuacion += 10;
         PlayerPrefs.SetInt("puntuacion",puntuacion);
         //getPuntuacion();
        
    }

    /*public int getPuntuacion(){
        if(puntuacion == null){
            puntuacion = 0;
        }
        //Debug.Log(SceneManagement.Scene.isDirty);
        if(Scene.isDirty){
            PlayerPrefs.SetInt("puntuacion",0);
        }
       // puntos.text = "Puntuacion: "+puntuacion;
       // Debug.Log("Puntuacion en impulso: "+puntuacion);
        return puntuacion;
    }*/

    private void OnApplicationQuit() {
        puntuacion = 0;
        PlayerPrefs.SetInt("puntuacion",puntuacion);
    }
    
    
}
