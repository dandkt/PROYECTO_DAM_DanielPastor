using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSettings : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image imagenMute;

    public bool GameIsPaused = false;
    public GameObject PauseMenu;

    public AudioSource musicaMenu;

    public AudioSource[] musicaFondo;
    private  AudioSource music;


    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio",0.5f);
        //AudioListener.volume = slider.value;
        isMute();
    }

    public void ChangedSliderValue(float valor){
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio",sliderValue);   
        AudioListener.volume = slider.value;
        isMute();
    }

    private void isMute(){
        if(sliderValue == 0){
            imagenMute.enabled = true;
        }else{
            imagenMute.enabled = false;
        }
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){

                if(GameIsPaused){
                    Resume();
                }else{
                    Pause();
                }
        }
    }
    void Resume(){
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        musicaMenu.Pause();
        music =  musicaFondo[1];
        music.Play();
       
        
    }
    void Pause(){
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
            music =  musicaFondo[1];
            music.Pause();
            musicaMenu.Play();
    }

    
}
