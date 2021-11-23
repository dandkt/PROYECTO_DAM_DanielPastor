using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class BallPyshics : MonoBehaviour
{
    public int puntos;
    public Text puntuacion;
    public float speed = 248.0f;
    public GameObject live1;
    public GameObject live2;
    public GameObject live3;
     BlockLogic block ;
    public GameObject UI;
    public GameObject Blocks;
    public GameObject Lives;
    public GameObject Canvas;
    public GameObject Canvas1;
    private int conter = 3;
    private int blocks;
    private GameObject[] listBlocks;
    public AudioSource win;
    public AudioSource loose;
    public GameObject ballClone;
    private int counterBall = 0;
    

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
       
            InvokeRepeating("aumentarVelocidad",6.0f,6.0f);
       
        
        listBlocks = GameObject.FindGameObjectsWithTag("block");
        blocks = listBlocks.Length;
        block = GetComponent<BlockLogic>();
    }

    void aumentarVelocidad(){
        speed = speed + 20.0f;
    }

    float hitFactor(Vector2 posBola, Vector2 posRacket,float racketAncho){
        return (posBola.x - posRacket.x) / racketAncho;
    }
    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.name == "racket"){
            float x = hitFactor(transform.position,
            col.transform.position,
            col.collider.bounds.size.x);
            Vector2 dir = new Vector2(x,1).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        if(col.gameObject.name == "limit"){
        switch(conter){
            case 3:
                Destroy(live3);
                conter --;
                break;
            case 2:
                Destroy(live2);
                conter --;
                break;
            case 1:
                Destroy(live1);
                conter --;
                break;
            case 0:
                conter = 3;
                UI.SetActive(false);
                Blocks.SetActive(false);
                Lives.SetActive(false);
                Canvas.SetActive(true);
                loose.Play();
                break;
            }
        }
        
        if(col.gameObject.tag == "block"){
                puntos += 10;
                puntuacion.text = "Puntuacion: "+puntos;
                counterBall ++;
                if(counterBall == 6){
                    Instantiate(ballClone,new Vector3(gameObject.transform.position.x,
                   gameObject.transform.position.y - 2,639.1391f),Quaternion.identity);
                   counterBall ++;
                }
                if(counterBall == 15){
                    counterBall = 0;
                }
        }
        if(BlockLogic.blocks == 0){
                UI.SetActive(false);
                Blocks.SetActive(false);
                Lives.SetActive(false);
                Canvas1.SetActive(true);
                win.Play();
        }
        
        

    }

    
}
