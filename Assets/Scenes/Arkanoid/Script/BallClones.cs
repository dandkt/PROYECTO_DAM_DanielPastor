using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallClones : MonoBehaviour
{
    
    public float speed = 250.0f;
    private int counter = 0;
    private GameObject racket;
    
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        racket = GameObject.Find("racket");
        InvokeRepeating("aumentarVelocidad",6.0f,6.0f);
    }

     void aumentarVelocidad(){
            speed = speed + 150.0f;
    }
    float hitFactor(Vector2 posBola, Vector2 posRacket,float racketAncho){
        return (posBola.x - posRacket.x) / racketAncho;
    }
    private void FixedUpdate() {
      if(!racket.activeInHierarchy){
        Destroy(this.gameObject);
      }
    }
     private void OnCollisionEnter2D(Collision2D col) {
            if(col.gameObject.name == "racket"){
                float x = hitFactor(transform.position,
                col.transform.position,
                col.collider.bounds.size.x);
                Vector2 dir = new Vector2(x,1).normalized;
                GetComponent<Rigidbody2D>().velocity = dir * speed;
            }
            if(col.gameObject.tag == "limit"){
                counter ++;
                if(counter == 5){
                    Destroy(this.gameObject);
                }
                
            }
             

     }
}
