using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossLogic : MonoBehaviour
{
    //vida del boss
    public Image barraVida;
    public float vidaActual;
    public float vidaMaxima;
    
    //limites del boss
    private float _limitScreenMaxX = 38.9f;
    private float _limitScreenMinX = -35.6f;
    //velocidad
    private float microSpeed = 10f;
    //posibilidad de moverse o de estar flotando
    private bool moveBoss = true;
    //tiempo de cuando se mueve o cuando flota
    private int isFloating = 15;
    //que shooter dispara la bala normal
    
    public GameObject[] shooters;

    public GameObject model1Red;
    public GameObject model2Red;
    public GameObject model4Red;
    private GameObject shotNormalNow;
    private int shottNormal=1;
    public GameObject normalBala;
    private GameObject shotBigNow;
    private int shotBig = 1;
    public GameObject bigBala;

    public GameObject UI;
    public GameObject win;
    private Rigidbody rB;
    private Animator animator;
    private Animation anim;

     public float cTime;
    private int refuerzoModel1=3;
    
    public AudioSource[] shootsAudio;

    
    private void Start() {
        cTime = 9.0f;
        rB = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        anim = GetComponent<Animation>();
       
        InvokeRepeating("movingBoss",25f,isFloating);
        InvokeRepeating("shoot1",10f,2f);
        InvokeRepeating("shoot2",12f,5f);
    }

    void shoot1(){
       
       shotNormalNow = GameObject.Find($"Shooter{shottNormal}"); 
      // Debug.Log("ShotNormalNow: "+shotNormalNow.transform.position);
       Instantiate(normalBala,new Vector3(shotNormalNow.transform.position.x,shotNormalNow.transform.position.y,3.7f),Quaternion.identity);
        shottNormal ++;
        shootsAudio[0].Play();
        if(shottNormal > 4){
            shottNormal = 1 ;
        }
       
    }

    void shoot2(){
        
        shotBigNow = GameObject.Find($"MegaShooter{shotBig}");
        Instantiate(bigBala,new Vector3(shotNormalNow.transform.position.x,shotNormalNow.transform.position.y,3.7f),Quaternion.identity);
        shotBig++;
        shootsAudio[1].Play();
        if(shotBig > 2){
            shotBig = 1;
        }

    }

    void movingBoss(){
        moveBoss =! moveBoss;
    }

    void Update()
    {
           
        //calcular la barra de vida que le queda al BOSS
        barraVida.fillAmount = vidaActual/vidaMaxima;
        //definir la fase del boss dependiendo de la vida que posea
       switch(vidaActual){
           case float n when (n<=550.0f):
                if(refuerzoModel1 > 0){
                    if(cTime > 0){
                        cTime -= Time.deltaTime;
                    }else{
                        createRefuerzos(gameObject.transform.position.x);
                    }
                }
           break;
        
           
       }
       if(vidaActual == 0){
            Destroy(gameObject);
            UI.SetActive(false);
            win.SetActive(true);

            
        }
       //movimiento
       if(moveBoss){
           animator.enabled = false;
            if (transform.position.x > _limitScreenMaxX) {
                // transform.position = new Vector3(_limitScreenMinX, transform.position.y, 0);
                transform.position = new Vector3(_limitScreenMinX,transform.position.y,3.7f);
            }
            transform.position -= new Vector3(Time.deltaTime * microSpeed, 0, 0);
       
            if(transform.position.x < _limitScreenMinX){
                 transform.position = new Vector3(_limitScreenMaxX, transform.position.y, 3.7f);
            }
        }else{
            animator.enabled = true;
            anim.Play("Flotar");
           
        }

    }


    private void OnCollisionExit(Collision other) {
        if(other.gameObject.name == "Bala(Clone)"){
            vidaActual = vidaActual - 5;
            Destroy(other.gameObject);
        }
        
    }

    private void createRefuerzos(float posicionBoss){
        /*var xPosition = Random.Range((posicionBoss+2.5f),20.3f);
        var YPosition = Random.Range(32.2f,20.6f);*/
        float xPosition;
        float YPosition;
       
       if(refuerzoModel1 != 0){
        for(int i=0;i<3;i++){
               xPosition = Random.Range((posicionBoss+2.5f),20.3f);
               YPosition = Random.Range(32.2f,20.6f);  
             
              switch(i){
                case 1:
                    Instantiate(model1Red,new Vector3(xPosition,YPosition,3.5f),Quaternion.Euler(76.276f,183.14f,3.051f));
                break;
                case 2:
                    Instantiate(model2Red,new Vector3(xPosition,YPosition,3.5f),Quaternion.Euler(76.276f,183.14f,3.051f));
                break;    
                case 3:
                    Instantiate(model4Red,new Vector3(xPosition,YPosition,3.5f),Quaternion.Euler(76.276f,183.14f,3.051f));
                break;
              }
           
              refuerzoModel1 --;
         }
       }else{
           refuerzoModel1 = 4;
            cTime = 25.0f;
       } 
        
            //Debug.Log("Limite de refuerzos alcanzado");
           
        
    }
    
}
