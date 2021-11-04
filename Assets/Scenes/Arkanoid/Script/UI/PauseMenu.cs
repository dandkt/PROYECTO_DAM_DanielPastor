using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public AudioSource musicaMenu;
    public AudioSource musicaFondo;
    private bool GameIsPaused = true;
    public GameObject PauseMenuObject;
   
   
    // Start is called before the first frame update
    
    
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
        PauseMenuObject.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        musicaMenu.Pause();
        musicaFondo.Play();
        
    }
    void Pause(){
            PauseMenuObject.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
            musicaFondo.Pause();
            musicaMenu.Play();
            
    }
   
    


}
