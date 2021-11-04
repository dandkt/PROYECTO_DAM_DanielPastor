using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string nombre;
    public void LoadGame(){
       Debug.Log(nombre);
       switch(nombre){
           case "Ellen":
           SceneManager.LoadScene("Start_Explorer");
           Debug.Log("Enviando a Ellen's Adventure ");
           break;
           case "Shotter":
           Debug.Log("Enviando a Shotter");
           SceneManager.LoadScene("IntroMenu");
           break;
           case "SpacesInvader":
            Debug.Log("Enviando a Space Invader");
            SceneManager.LoadScene("MainMenuAsteroid");
           break;
           case "Arkanoid":
           Debug.Log("Enviando a Arkanoid");
           SceneManager.LoadScene("MainMenuAkanoid");
           break;
           case "MainMenu":
           Debug.Log("Enviando a MainMenu");
           SceneManager.LoadScene("MainMenu");
           break;
           case "Level1":
           Debug.Log("Enviando a nivel de Shooter");
           SceneManager.LoadScene("Level1");
           break;
       }
    }
    //salir de la aplicación
    public void QuitGame(){
        Debug.Log("Saliendo");
        Application.Quit();
    }
}
