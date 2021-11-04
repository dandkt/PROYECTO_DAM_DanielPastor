using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartItem : MonoBehaviour
{
    //si se sale del limite
    private void FixedUpdate() {
        if(transform.position.y <= -38.2f){
            Destroy(this.gameObject);
        }      
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "Bala(Clone)"){
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag == "ship"){
            Destroy(this.gameObject);
        }
        if(other.gameObject.name == "SpacePlayer"){
            Destroy(this.gameObject);
        }
        
    }
}
