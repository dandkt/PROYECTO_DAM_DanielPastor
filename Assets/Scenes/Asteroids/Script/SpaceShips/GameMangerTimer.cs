using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameMangerTimer : MonoBehaviour
{
    //va  a tener un temporizador que se va a ir mostrando en pantalla.
    //Cuando llegue a una cantidad, se desactivará un GameManger y se activará otro.
    //Cuando falte un minuto, se activarán los dos GameManager.
    //Una vez terminado el tiempo se destruirán todos los asteroides y las naves se irán,
    //activando al boss, pero no antes de poner un texto de advertencia de que viene un boss

    public float tiempo;

    public GameObject gameOver;
    public Text timer;
    public GameObject canvas;
    

    public Text cuentaAtras;
    public float cTime;
    private bool pasadoCuenta = false;

    public GameObject AsteroidGameManager;
    public GameObject SpacesShipGameManager;

    private GameObject[] listAsteroids;
    private GameObject[] listShips;


    public GameObject finalBoss;

   
    public AudioSource[] audioSources; 
 private void Start() {
        
       
        tiempo = 601.0f;
        timer.text = "Tiempo: 10:00";
        cTime = 4;
        audioSources[2].Play();
    }
private void FixedUpdate() {
       if(isTime()){
          if(tiempo < 0){
              timer.enabled = false;
          }
          timer.text = formatearTiempoAtras();
       }else{
           cuentaAtras.text = fase1();
       }
       
    }
    private bool isTime(){
     if(pasadoCuenta == true){
         if(canvas.activeSelf){
            return true;
        }else{
            Debug.Log("desactivado");
            return false;
        }
     }else{
         return false;
     }   
        
       
    }
    private string formatearTiempoAtras(){
        if(isTime()){
            if(gameOver.activeSelf == false){
                if(tiempo <=0){
                //Debug.Log("Desactivar gameManager");
                }else{
                tiempo -= Time.deltaTime *3.0f;
                }
            }
        }
        string minutos = Mathf.Floor(tiempo / 60).ToString("00");
 		string segundos = Mathf.Floor(tiempo % 60).ToString("00");
        
        defineFase(tiempo);

        
		//Devuelvo el string formateado con : como separador
		return minutos + ":" + segundos;

    }

    private void  defineFase(float myTimer){
        
        switch(myTimer){
            case float n when (n<=601.0f && n>=551.0f):
               
                fase1();
            break;
            case float n when (n<=550.0f && n>=421.0f):
              
                AsteroidGameManager.SetActive(false);
                SpacesShipGameManager.SetActive(true);
                
            break;
            case float n when (n<=420.0f && n>=0.0f):
                AsteroidGameManager.SetActive(true);
               
                if(cTime >= 0){
                    cTime -= Time.deltaTime;
                }else{
                    AsteroidGameManager.SetActive(false);
                    //clearAsteroids();
                    cTime = 5;
                }
            break;
            case float n when (n<0.0f):
                SpacesShipGameManager.SetActive(false);
                AsteroidGameManager.SetActive(false);
               // Comenzar fase de conteo para el jefe final
                if(cTime >=0){
                   
                    cTime -= Time.deltaTime;
                }else{
                  
                
                    finalBoss.SetActive(true);
                    
                }
            break; 
        }
    }

    private void clearAsteroids(){
        listAsteroids = GameObject.FindGameObjectsWithTag("MyEnemy");
        listShips = GameObject.FindGameObjectsWithTag("ship");
        if(listAsteroids.Length > 0){
            for(int i = 0; i< listAsteroids.Length;i++){
            Destroy(listAsteroids[i]);
            }
        }
    }

    private string fase1(){
        
        if(cTime >= 0 && pasadoCuenta == false){
            cTime -= Time.deltaTime;

           // string minutos = Mathf.Floor(tiempo / 60).ToString("00");
 		    string segundos = Mathf.Floor(cTime % 60).ToString("0");
            return segundos;
        }else{
            pasadoCuenta = true;
            AsteroidGameManager.SetActive(true);
            cuentaAtras.enabled = false;
            cTime = 4;
            return "";
        }
        
        
    }

}
