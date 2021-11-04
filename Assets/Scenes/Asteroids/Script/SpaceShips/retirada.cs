using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class retirada : MonoBehaviour
{
    private Animator animator;
    private Animation anim;
    private GameObject myPlayerObject;
    // Start is called before the first frame update
    void Start()
    {
      animator = GetComponent<Animator>();
      anim = GetComponent<Animation>();   
    }

    // Update is called once per frame
    void Update()
    {
        myPlayerObject = GameObject.FindWithTag("Player");
         if(myPlayerObject == null){
         
            anim.Play("Retirada");
            Destroy(gameObject);
         }
        
    }
}
