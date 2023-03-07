using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_book : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator livro;
    public bool automatico=false;


    

    void Start()
    {
        livro = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
       if (automatico == true)
        {
            livro.SetBool("Automatic", true);
        }

        
      
        if (Input.GetKeyDown("up"))
        {
          livro.SetBool("go_ahead", true);                    
         }

        if (Input.GetKeyUp("up"))
        {
          livro.SetBool("go_ahead", false);
        }

        if (Input.GetKeyDown("down"))
        {
            livro.SetBool("go_back", true);
        }
        if (Input.GetKeyUp("down"))
        {
            livro.SetBool("go_back", false); 
        }
    }
}
