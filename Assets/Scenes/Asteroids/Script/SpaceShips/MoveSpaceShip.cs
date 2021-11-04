using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpaceShip : MonoBehaviour
{
    public float speed = 20.0f;
    public AudioSource shootAudio;

   private float _limitScreenMaxX = 73f;
   private float _limitScreenMinX = -48.7f;
   private float _limitScreenMaxY = 32.7f;
   private float _limitScreenMinY = -32.3f;
   
   public GameObject bala;
   
   
    public float speed2 = 4f;
    
    private void Start() {
      shootAudio = GetComponent<AudioSource>();
    }
    void Update()
    {
    if (Input.GetKey(KeyCode.RightArrow)){ 
      if (transform.position.x > _limitScreenMaxX) {
        transform.position = new Vector3(_limitScreenMinX, transform.position.y, 3.7f);
      }
      transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
    }
    if (Input.GetKey(KeyCode.LeftArrow)){
          if (transform.position.x < _limitScreenMinX) {
              transform.position = new Vector3(_limitScreenMaxX, transform.position.y, 3.7f);
        }
          transform.position -= new Vector3(Time.deltaTime * speed, 0, 0);
    }

    if (Input.GetKey(KeyCode.UpArrow)){ 
      if (transform.position.y > _limitScreenMaxY) {
        transform.position = new Vector3(transform.position.x, _limitScreenMinY, 3.7f);
      }
      transform.position += new Vector3(0, Time.deltaTime * speed, 0);
    }
    if (Input.GetKey(KeyCode.DownArrow)){
          if (transform.position.y < _limitScreenMinY) {
              transform.position = new Vector3(transform.position.x, _limitScreenMaxY, 3.7f);
        }
          transform.position -= new Vector3(0, Time.deltaTime * speed, 0);
    }
    

    if(Input.GetKeyDown(KeyCode.Space)){
      shootAudio.Play();
      if(transform.rotation == Quaternion.Euler(-87.478f,512.09f,-153.876f)){
        //Debug.Log("Sobre A");
        Instantiate(bala,transform.position + new Vector3(0,5.88f,0),Quaternion.identity); 
      }else if(transform.rotation == Quaternion.Euler(0.018f,628.236f,-267.736f)){
       // Debug.Log("Sobre W");
        Instantiate(bala,transform.position - new Vector3(4.4f,0.03f,0),Quaternion.identity);
         
      }
      
    }
  
  
  }
    
    
}
