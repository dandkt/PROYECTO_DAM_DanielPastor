using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float tiempo = 0.0f;
    public Text timer;
    
    public GameObject canvas;
   
    private void Start() {
        timer.text = "Tiempo: 00:00";
    }

    private void FixedUpdate() {
       if(isTime()){
          timer.text = formatearTiempo();
       }
    }
    private bool isTime(){
        if(canvas.activeSelf){
           // Debug.Log("activo");
            return true;
        }else{
            //Debug.Log("desactivado");
            return false;
        }
       // Debug.Log("no funciona");
    }
    private string formatearTiempo(){
        if(isTime()){
            tiempo += Time.deltaTime;
        }
        string minutos = Mathf.Floor(tiempo / 60).ToString("00");
 		string segundos = Mathf.Floor(tiempo % 60).ToString("00");
		//Devuelvo el string formateado con : como separador
		return minutos + ":" + segundos;

    }
}
