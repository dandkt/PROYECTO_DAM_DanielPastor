using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePlayer : MonoBehaviour
{
    public Image barraVida;
    public float vidaActual;
    
    public float vidaMaxima;

    public GameObject gameOver;
    public GameObject UserInterfaces;
    public GameObject youWin;
    

    private GameObject[] listShip;
    private GameObject[] asteroidsList;
    
    public GameObject SpacesGameManager;
    public GameObject AsteroidGameManager;
    
     

   
    private void Start() {
       //Debug.Log(puntuacion);
        //puntTotal = _puntuacion.getPuntuacion();
        
    }

    private void Update() {
        barraVida.fillAmount = vidaActual/vidaMaxima;
       
        //puntos.text = "Puntuación: "+ puntuacion.getPuntuacion();
    }
   

     private void OnCollisionEnter(Collision other) {
        // reanimated = GameObject.Find("Reanimated");
         switch(other.gameObject.name){
             case "bala_model1(Clone)":
             case "bala_model_2(Clone)":
             case "bala_model3(Clone)":
             case "bala_model4(Clone)":
                vidaActual = vidaActual - 50;
              break;
             case "Medium(Clone)":
                vidaActual = vidaActual - 45;
              break;
              case "small(Clone)":
                vidaActual = vidaActual - 50;
                break;
              case "FinalBoss":
                    vidaActual = vidaActual -75;
                    break;
              case "MegaShooter1(Clone)":
                    vidaActual = vidaActual -150;
                    break;
              case "heartItem(Clone)":
                    //no debe pasar del limite
                    if(vidaActual < vidaMaxima){
                        vidaActual = vidaActual +100;
                    }
                    
                    break;
         }
        //eliminacion de vidas y reaparicion del jugador
        if(vidaActual < 0){
                //Debug.Log("Final del Juego");
                Destroy(gameObject);
                gameover();
            }
    }
    private void gameover(){
        listShip = GameObject.FindGameObjectsWithTag("ship");
        for(int i=0;i<listShip.Length;i++){
            Destroy(listShip[i]);
        }
        asteroidsList = GameObject.FindGameObjectsWithTag("MyEnemy");
        for(int i=0;i<asteroidsList.Length;i++){
            Destroy(asteroidsList[i]);
        }
        UserInterfaces.SetActive(false);
        gameOver.SetActive(true);
    }
}

