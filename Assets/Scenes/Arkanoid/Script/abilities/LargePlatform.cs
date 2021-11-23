using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargePlatform : MonoBehaviour
{
    
   private GameObject racket;
    void Start()
    {
        racket = GameObject.Find("racket");
    }
    private void FixedUpdate() {
      if(!racket.activeInHierarchy){
        Destroy(this.gameObject);
      }
    }
    
    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.name == "racket"){
            Debug.Log("COlision con racket");
            racket.gameObject.transform.localScale = new Vector3(3.5f,3.5f,3.5f);
            Destroy(this.gameObject);
        }
        if(col.gameObject.tag == "limit"){
            Destroy(this.gameObject);
        }
    }
}
