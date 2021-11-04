using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PrincipalMenuLogic : MonoBehaviour
{
    public void LoadGame(){
        SceneManager.LoadScene("LevelArkanoid");
    }
  
    public void QuitGame(){
        Debug.Log("Saliendo");
        Application.Quit();
    }
      //salir de la aplicación
    public void QuitGameMenu(){
       
         SceneManager.LoadScene("MainMenu");
    }

}
