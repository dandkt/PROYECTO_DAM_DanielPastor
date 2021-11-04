using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAsteroids : MonoBehaviour
{
    private float _asteroidSpeed = 10f;
    
    private float _limitScreenMaxY = 32.7f;
    private float _limitScreenMinY = -32.3f;
    private float _limitScreenMaxX = 73f;
    private float _limitScreenMinX = -48.7f;

    void Update()
    {
        transform.position -= new Vector3(0,_asteroidSpeed * Time.deltaTime,0); 
         if (transform.position.y > _limitScreenMaxY) {
                transform.position = new Vector3(transform.position.x,_limitScreenMaxY,3.7f);
                
            }
            if(transform.position.y < _limitScreenMinY){
                 transform.position = new Vector3(transform.position.x, _limitScreenMaxY, 3.7f);
            }
            if (transform.position.x > _limitScreenMaxX) {
                transform.position = new Vector3(_limitScreenMinX,transform.position.y,3.7f);
              
            }
         
            if(transform.position.x < _limitScreenMinX){
                 transform.position = new Vector3(_limitScreenMaxX, transform.position.y, 3.7f);
            }

            transform.position += new Vector3(Time.deltaTime * _asteroidSpeed, 0, 0);

    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "Bala(Clone)"){
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
         if(other.gameObject.tag == "ship"){
           Destroy(this.gameObject);
        }
       
    }
}
