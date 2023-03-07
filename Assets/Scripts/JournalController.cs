using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalController : MonoBehaviour
{

    public Animator bookAnimator;
    public bool automatic = false;
    public Camera camera;
    public GameObject Journal;

    // Start is called before the first frame update
    void Start()
    {
        bookAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //We're checking to see if the object is being looked at
        if (canISee(camera, Journal))
        {

        }
    }

    private bool canISee(Camera c, GameObject targetObj)
    {
        return false;
    }
}
