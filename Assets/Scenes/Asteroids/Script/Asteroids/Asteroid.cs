using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject asteroids;
    private  GameObject asteroidClone;
    public GameObject rock;
    public Camera mainCamera;
    //public Gameplay gameplay;
    private  Rigidbody rb;
    private float maxSpeed;
    private int _generation;

    private void Start() {
        mainCamera = Camera.main;
        rb = asteroids.GetComponent<Rigidbody>();
        //calcular la velocidad de X
        float speedX = Random.Range(200f,800f);
        int selectorX = Random.Range(0,2);
        float dirX = 0;
        if(selectorX == 1){
            dirX = -1;
        }else{
            dirX = 1;
        }
        float finalSpeedX = speedX * dirX;
        rb.AddForce(transform.right * finalSpeedX);
        //calcular la velocidad de Y
        float speedY = Random.Range(200f,800f);
        int selectorY = Random.Range(0,2);
        float dirY = 0;
        if(selectorY == 1){
            dirY = -1;
        }else{
            dirY = 1;
        }
        float finalSpeedY = speedY * dirY;
        rb.AddForce(transform.up * finalSpeedY);
    }

    public void SetGeneration(int generation){
        _generation = generation;
    }
    private void Update() {
        CheckPosition();
        float dynamicMaxSpeed = 3f;
        rb.velocity = new Vector2(rb.velocity.y,dynamicMaxSpeed);
    }
    private void OnCollisionEnter(Collision other) {
        if(other.collider.name == "Balas(Clone)"){
                if(_generation < 3){
                    CreateSmallAsteroids(2);

                }
                Destroy(gameObject);
                Debug.Log("Aumentar puntuacion");
        }
        //si choca con la nave 
        if(other.collider.name == "Nave"){
            Debug.Log("Destruir una vida y reiniciar la nave parando el juego varios segundos");
        }
    }
    void CreateSmallAsteroids(int asteroidsNum){
        int newGeneration = _generation +1;
        for(int i=1;i<= asteroidsNum;i++){
            float scaleSize = 0.5f;
            //crear el asteroide una vez hay colisionado con la bala
            asteroidClone = Instantiate(rock,new Vector3(transform.position.x, transform.position.y, 0f), transform.rotation);
            asteroidClone.transform.localScale = new Vector3(asteroidClone.transform.localScale.x * scaleSize, asteroidClone.transform.localScale.y * scaleSize, asteroidClone.transform.localScale.z * scaleSize);
            SetGeneration(newGeneration);
            asteroidClone.SetActive(true);
        
        }
    }
    private void CheckPosition(){
        float sceneWidth = mainCamera.orthographicSize *2 * mainCamera.aspect;
        float sceneHeight = mainCamera.orthographicSize *2;
        float sceneRightEdge = sceneWidth /2;
        float sceneLeftEdge = sceneRightEdge * -1;
        float sceneTopEdge = sceneHeight /2;
        float sceneBottomEdge = sceneTopEdge * -1;
        float rockOffset;
        bool flag = true;
        if (flag)
        {
            rockOffset = 1.0f;
            float reverseSpeed = 2000.1f;

            if (asteroids.transform.position.x > sceneRightEdge + rockOffset)
            {
                asteroids.transform.rotation = Quaternion.identity;
                rb.AddForce(transform.right * (reverseSpeed * (-1)));
            }

            if (asteroids.transform.position.x < sceneLeftEdge - rockOffset) { asteroids.transform.rotation = Quaternion.identity; rb.AddForce(transform.right * reverseSpeed); } if (asteroids.transform.position.y > sceneTopEdge + rockOffset)
            {
                asteroids.transform.rotation = Quaternion.identity;
                rb.AddForce(transform.up * (reverseSpeed * (-1)));
            }

                if (asteroids.transform.position.y < sceneBottomEdge - rockOffset) {
                    asteroids.transform.rotation = Quaternion.identity; rb.AddForce(transform.up * reverseSpeed); 
                }
             } else { 
                 rockOffset = 2.0f; 
                 if (asteroids.transform.position.x > sceneRightEdge + rockOffset){
                    asteroids.transform.position = new Vector2(sceneLeftEdge - rockOffset, asteroids.transform.position.y);
                }
            if (asteroids.transform.position.x < sceneLeftEdge - rockOffset) {
                 asteroids.transform.position = new Vector2(sceneRightEdge + rockOffset, asteroids.transform.position.y); }
            if (asteroids.transform.position.y > sceneTopEdge + rockOffset){
                asteroids.transform.position = new Vector2(asteroids.transform.position.x, sceneBottomEdge - rockOffset);
            }
            if (asteroids.transform.position.y < sceneBottomEdge - rockOffset){
                asteroids.transform.position = new Vector2(asteroids.transform.position.x, sceneTopEdge + rockOffset);
            }
        }
    }
    
}
