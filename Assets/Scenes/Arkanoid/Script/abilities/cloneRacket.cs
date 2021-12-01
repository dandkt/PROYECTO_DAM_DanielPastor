using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloneRacket : MonoBehaviour
{
    private GameObject racket;
    void Start()
    {
        racket = GameObject.Find("racket");
    }
    private void FixedUpdate() {
      if(!racket.activeInHierarchy){
        Destroy(this.gameObject);
        Destroy(racket);
      }
  }
     private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.name == "racket" || col.gameObject.name == "racket(Clone)"){
             Instantiate(racket,new Vector3(racket.gameObject.transform.position.x + 84.0f,
                   racket.gameObject.transform.position.y,639.1391f),Quaternion.identity);
            Destroy(this.gameObject);
        }
        if(col.gameObject.tag == "limit"){
            Destroy(this.gameObject);
        }
    }
}
