using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Destruir : MonoBehaviour
{
  

    public Animator anima;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "cajado")
        {
          
            anima.SetBool("Destruir", true);
            Destroy(gameObject, 1.5f);
        }
    }


   
}
