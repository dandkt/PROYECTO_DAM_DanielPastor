using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulsoBalaEnemigo : MonoBehaviour
{
    // Start is called before the first frame update
 void Update()
    {
       
            transform.Translate(Vector3.down*30f*Time.deltaTime);
        
        if(transform.position.y <= -38.8f){
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other) {
        switch(other.gameObject.name){
            case "SpacePlayer":
                Destroy(this.gameObject);
                break;
            case "Medium(Clone)":
            case "small(Clone)":
                Destroy(this.gameObject);
                Destroy(other.gameObject);
            break;
        }
      
    }
}
