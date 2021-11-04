using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMove : MonoBehaviour
{
    public float speed = 2.0f;
    private float _limitScreenMinX = -275.7f;
    private float _limitScreenMaxX = 350.65f;
    
    private void Start() {
        InvokeRepeating("aumentarVelocidad",6.0f,16.0f);
    }

    void aumentarVelocidad(){
        Debug.Log("Aumentando velocidad racket");
        speed = speed + 20.0f;
    }

   private void FixedUpdate() {
      if (Input.GetKey(KeyCode.RightArrow)){ 
      this.transform.Translate(Vector3.right*Time.deltaTime*speed);
      }
      if (Input.GetKey(KeyCode.LeftArrow)){
          this.transform.Translate(Vector3.left*Time.deltaTime*speed);
      }

      if(transform.position.x >= _limitScreenMaxX){
          Debug.Log("Entrando en limite maximo");
        transform.position = new Vector3(_limitScreenMaxX,transform.position.y,transform.position.z);
      }
      
      if(transform.position.x < _limitScreenMinX){
          Debug.Log("Entrando en limite minimo");
        transform.position = new Vector3(_limitScreenMinX,transform.position.y,transform.position.z);
      }
       

    
    }
}
