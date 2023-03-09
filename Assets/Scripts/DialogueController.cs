using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    //Dialogue trees should be set up for each individual controller. In this case (the prototype) we'll load at start.
    //First thing we'll do is plot out our Dialogue instances so they're all ready to be filled with appropriate things;

    public string nameOfConversant = "Dante";
    public AudioSource sourcey;
    public GameObject theJournal;

    public GameObject grabbedObject;

    public TextMeshPro yText;
    public TextMeshPro xText;
    public TextMeshPro aText;
    public TextMeshPro bText;

    DialogueInstance opener;
    DialogueInstance endReveal;
    DialogueInstance introduction;
    DialogueInstance hellReview;
    DialogueInstance angry;
    DialogueInstance smellResponse;
    DialogueInstance happy;

    public int iteration = 0;
    bool journalUpdated = false;

    DialogueInstance currentInstance;

    // Start is called before the first frame update
    void Start()
    {
        //Now we populate the instances

        opener = new DialogueInstance(4, nameOfConversant, "Opener", new string[] { "Where are we?\n 'Press Y'", "Sorry, and you are?\n 'Press X'", "Get bent, book\n 'Press A'", "Ha! Spine! I see what you did there\n 'Press B'" }, new DialogueInstance[]{endReveal, introduction, angry, happy});
        endReveal = new DialogueInstance(0, nameOfConversant, "EndReveal", new string[0], new DialogueInstance[0]);
        introduction = new DialogueInstance(1, nameOfConversant, "Introduction", new string[] { "Oh, the Inferno. How was Hell anyways? \n 'Press X, Y, A, or B'" }, new DialogueInstance[] { hellReview });
        hellReview = new DialogueInstance(1, nameOfConversant, "HellReview", new string[] { "I'd love to help, but I'm not even sure where we are. Any ideas?\n 'Press X, Y, A, or B" }, new DialogueInstance[] { endReveal });
        angry = new DialogueInstance(2, nameOfConversant, "Angry", new string[] { "Oh, the Inferno. How was Hell anyways? \n 'Press X or Y'", "Hey, I smell great! I showered this morning and everything!\n 'Press A or B'" }, new DialogueInstance[] { hellReview, smellResponse});
        smellResponse = new DialogueInstance(1, nameOfConversant, "SmellResponse", new string[] {"Do you think it's something in the room? 'Press X, Y, A, or B'"}, new DialogueInstance[] { endReveal });
        happy = new DialogueInstance(2, nameOfConversant, "Happy", new string[] { "I'd love to help, but I'm not even sure where we are. Any ideas? \n 'Press X or Y'", "Sorry, no. All I've been able to see is this store\n 'Press A or B'" }, new DialogueInstance[] { endReveal, smellResponse });


        //At the time these are passed, many of them are empty, so simply set them once you've filled things up so you don't have null references anymore
        opener.UpdateReferences(new DialogueInstance[] { endReveal, introduction, angry, happy });
        introduction.UpdateReferences(new DialogueInstance[] { hellReview });
        hellReview.UpdateReferences(new DialogueInstance[] { endReveal });
        angry.UpdateReferences(new DialogueInstance[] { hellReview, smellResponse });
        smellResponse.UpdateReferences(new DialogueInstance[] { endReveal });
        happy.UpdateReferences(new DialogueInstance[] { endReveal, smellResponse });


        currentInstance = opener;

        //Debug.LogError(currentInstance.);
    }

    // Update is called once per frame
    void Update()
    {
        //We only want the dialogue tree to initiate if the object is grabbed
        if (grabbedObject.transform.GetComponent<OVRGrabbable>().isGrabbed)
        {
            if (!journalUpdated)
            {
                JournalController accessMeans = theJournal.GetComponent<JournalController>();
                accessMeans.AddPage();
                journalUpdated = true;
            }



            if (iteration == 0)
            {
                yText.text = "";
                xText.text = "";
                aText.text = "";
                bText.text = "";

                iteration++;
                StartCoroutine(openingRun());
            }
            else if (iteration > 1)
            {
                //Here, the audio will have played and the text will have appeared, so we wait for input
                //Once we get input, we set the iteration back to 0 and start anew after changing the current instance to the corresponding instance
                if (OVRInput.GetDown(OVRInput.Button.One))//A Button
                {
                    if (currentInstance.options > 0)
                    {
                        iteration = 0;
                        currentInstance = currentInstance.aNextInstance;
                    }
                }
                if (OVRInput.GetDown(OVRInput.Button.Two))//B Button
                {
                    if (currentInstance.options > 0)
                    {
                        iteration = 0;
                        currentInstance = currentInstance.bNextInstance;
                    }
                }
                if (OVRInput.GetDown(OVRInput.Button.Three))//X Button
                {
                    if (currentInstance.options > 0)
                    {
                        iteration = 0;
                        currentInstance = currentInstance.xNextInstance;
                    }
                }
                if (OVRInput.GetDown(OVRInput.Button.Four))//Y Button
                {
                    if (currentInstance.options > 0)
                    {
                        iteration = 0;
                        currentInstance = currentInstance.yNextInstance;
                    }
                }
            }


        }
        else
        {
            //If we're not being grabbed, then we want to make sure our text is invisible and our audio isn't playing
            if (yText.text != "")
            {
                yText.text = "";
                xText.text = "";
                aText.text = "";
                bText.text = "";
            }
            if (sourcey.isPlaying)
            {
                sourcey.Stop();
            }
            iteration = 0;
        }
    }

    void ManageText()
    {
        if(currentInstance.options == 4)
        {
            yText.text = currentInstance.yDialogue;
            xText.text = currentInstance.xDialogue;
            aText.text = currentInstance.aDialogue;
            bText.text = currentInstance.bDialogue;
        }
        else if (currentInstance.options == 3)
        {
            yText.text = currentInstance.yDialogue;
            xText.text = currentInstance.xDialogue;
            aText.text = currentInstance.aDialogue;
            bText.text = "";
        }
        else if (currentInstance.options == 2)
        {
            yText.text = currentInstance.yDialogue;
            xText.text = "";
            aText.text = "";
            bText.text = currentInstance.bDialogue;
        }
        else if (currentInstance.options == 1)
        {
            yText.text = currentInstance.yDialogue;
            xText.text = "";
            aText.text = "";
            bText.text = "";
        }
        else
        {
            yText.text = "";
            xText.text = "";
            aText.text = "";
            bText.text = "";
        }
    }

    IEnumerator openingRun()
    {
        sourcey.clip = currentInstance.myClip;
        sourcey.Play();

        //After we play the audio, we present the text for the user to choose from
        ManageText();

        iteration++;

        yield return null;
    }
}
