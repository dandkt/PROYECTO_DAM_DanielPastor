using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGameManager : MonoBehaviour
{

    public GameObject gameOver;
    public GameObject UserInterfaces;
    public GameObject youWin;
    public Image lifeBarPlayer;
    public ImpulsoBalaJugador impulsoBalaJugador;

    private float lifeTotal;

    private ImpulsoBalaJugador impulsoBala;

    public Text puntuacionTotal;

    private GameObject[] listShip;
    private GameObject[] asteroidsList;

    private GameObject bala;

    public AudioSource musicaLose;
    public AudioSource musicaWin;

    // Start is called before the first frame update
    void Start()
    {
        lifeTotal = lifeBarPlayer.fillAmount;
        //bala = GameObject.FindGameObjectWithTag("bala").GetComponent<GameObject>();
       // impulsoBala = GameObject.FindGameObjectWithTag("bala").GetComponent<ImpulsoBalaJugador>();
        
    }


    
    // Update is called once per frame
    void Update()
    {
        if(lifeTotal == 0){
            gameOver.SetActive(true);
            UserInterfaces.SetActive(false);

            musicaLose.Play();
           
           /* puntuacionTotal.text = "Puntuacion Total: "+impulsoBala.getPuntuacion();*/
            
        }
    }
}
