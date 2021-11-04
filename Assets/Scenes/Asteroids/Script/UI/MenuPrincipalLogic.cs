using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class MenuPrincipalLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadGame(){
        SceneManager.LoadScene("LevelAsteroid");
    }
  
    public void QuitGame(){
        Debug.Log("Saliendo");
        Application.Quit();
    }

    public void QuitToMenu(){
        SceneManager.LoadScene("MainMenuAsteroid");
    }
   
      //salir de la aplicación
    public void QuitGameMenu(){
       
         SceneManager.LoadScene("MainMenu");
    }
}
