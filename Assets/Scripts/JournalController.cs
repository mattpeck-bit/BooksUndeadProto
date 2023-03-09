using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JournalController : MonoBehaviour
{

    public Animator bookAnimator;
    public bool automatic = false;
    public Camera camera;
    public GameObject Journal;
    private int pageCount = 4;
    private Texture2D myTex;
    public TextMeshPro hintText;

    // Start is called before the first frame update
    void Start()
    {
        myTex = Resources.Load<Texture2D>($"Journal Page Textures/Page4.png");
        bookAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //We're checking to see if we're in the vicinity of the journal
        if (AmIClose(camera, Journal))
        {
            //If we are, we can use the triggers to move the animation along
            if(OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.3f)
            {
                bookAnimator.SetBool("go_ahead", true);
            }
            if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) < 0.3f)
            {
                bookAnimator.SetBool("go_ahead", false);
            }
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.3f)
            {
                bookAnimator.SetBool("go_back", true);
            }
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) < 0.3f)
            {
                bookAnimator.SetBool("go_back", false);
            }
        }
    }

    private bool AmIClose(Camera c, GameObject targetObj)
    {
        var targTransform = targetObj.transform.position;
        var myLocation = c.transform.position;

        var tempDistance = Vector3.Distance(myLocation, targTransform);
        if (tempDistance <= 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddPage()
    {
        hintText.text = "HINT: The demons have trapped you in this hellish prototype. Please exit the game, the prototype is finished.";
        //Get the gameobject representing the page we are on
        GameObject gamePage = Journal.transform.GetChild(3).gameObject;

        //Then get the material for the page we're on (should be blank) and add the appropriate texture
        Material[] pageMats = gamePage.GetComponent<Renderer>().materials;

        /*for (int i = 0; i < pageMats.Length; i++)
        {
            Debug.LogError(pageMats[i].name);
            if (pageMats[i].name == "pg4 (Instance)")
            {
                Debug.LogError("SHOULD BE SETTING TEXTURE");
                pageMats[i].mainTexture = myTex;
            }
        }*/

        /*foreach(Material mat in pageMats) {
            if(mat.name == "Pg " + pageCount)
            {
                mat.SetTexture("_MainTex", Resources.Load<Texture2D>($"Journal Page Textures/Page{pageCount}"));
                break;
            }
        }*/
    }
}
