using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
   
   public void QuitMainMenu(){
       Debug.Log("Volviendo al principal");
       SceneManager.LoadScene("MainMenu");
   }
   public void QuitMenu(){
       SceneManager.LoadScene("MainMenuAkanoid");
       Debug.Log("Volviendo al menu");
   }

}
