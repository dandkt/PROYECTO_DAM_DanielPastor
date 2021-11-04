
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Puntuacion : MonoBehaviour
{
    
    private int puntos;
    public Text puntuacion;
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        Debug.Log(other);
    }
}
