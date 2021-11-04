using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortPlatform : MonoBehaviour
{
    private GameObject racket;
    void Start()
    {
        racket = GameObject.Find("racket");
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.name == "racket" || col.gameObject.name == "racket(Clone)"){
            Debug.Log("COlision con racket");
            racket.gameObject.transform.localScale = new Vector3(1.0f,1.0f,1.0f);
            Destroy(this.gameObject);
        }
        if(col.gameObject.tag == "limit"){
            Destroy(this.gameObject);
        }
    }
}
