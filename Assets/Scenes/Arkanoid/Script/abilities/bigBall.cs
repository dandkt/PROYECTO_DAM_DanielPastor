using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigBall : MonoBehaviour
{
    private GameObject ball;
    private GameObject racket;
    void Start()
    {
        ball = GameObject.Find("ball");
        racket = GameObject.Find("racket");
    }

  private void FixedUpdate() {
      if(!racket.activeInHierarchy){
        Destroy(this.gameObject);
      }
  }
    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.name == "racket" || col.gameObject.name == "racket(Clone)" ){
           // Debug.Log("COlision con racket");
            ball.gameObject.transform.localScale = new Vector3(5.0f,5.0f,5.0f);
            Destroy(this.gameObject);
        }
        if(col.gameObject.tag == "limit"){
            Destroy(this.gameObject);
        }
    }
}
