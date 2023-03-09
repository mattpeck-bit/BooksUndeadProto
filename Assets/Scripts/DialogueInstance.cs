using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInstance
{
    //Every dialogue instance will have pieces of player dialogue from which to choose,an audio clip that plays before them, and "pointers" of sorts to the next dialogue instances the choices set up
    public AudioClip myClip;

    public int options;

    public string yDialogue;
    public string xDialogue;
    public string aDialogue;
    public string bDialogue;

    public DialogueInstance yNextInstance;
    public DialogueInstance xNextInstance;
    public DialogueInstance aNextInstance;
    public DialogueInstance bNextInstance;

    public DialogueInstance(int howMany, string name, string clipName, string[] dialogues, DialogueInstance[] nexts)
    {
        options = howMany;
        myClip = Resources.Load<AudioClip>($"Dialogue Audio/{name}/{clipName}");
        if (options == 4)
        {
            yDialogue = dialogues[0];
            xDialogue = dialogues[1];
            aDialogue = dialogues[2];
            bDialogue = dialogues[3];
        }
        else if(options == 3)
        {
            yDialogue = dialogues[0];
            xDialogue = dialogues[1];
            aDialogue = dialogues[2];
            bDialogue = dialogues[2];
        }
        else if(options == 2)
        {
            yDialogue = dialogues[0];
            xDialogue = dialogues[0];
            aDialogue = dialogues[1];
            bDialogue = dialogues[1];
        }
        else if (options == 1)
        {
            yDialogue = dialogues[0];
            xDialogue = dialogues[0];
            aDialogue = dialogues[0];
            bDialogue = dialogues[0];
        }
        else if (options == 1)
        {
            yDialogue = xDialogue = aDialogue = bDialogue = dialogues[0];
        }
        else
        {
            yDialogue = xDialogue = aDialogue = bDialogue = "";

        }

        if (options == 4)
        {
            yNextInstance = nexts[0];
            xNextInstance = nexts[1];
            aNextInstance = nexts[2];
            bNextInstance = nexts[3];
        }
        else if(options == 3)
        {
            yNextInstance = nexts[0];
            xNextInstance = nexts[1];
            aNextInstance = nexts[2];
            bNextInstance = nexts[2];
        }
        else if (options == 2)
        {
            yNextInstance = nexts[0];
            xNextInstance = nexts[0];
            aNextInstance = nexts[1];
            bNextInstance = nexts[1];
        }
        else if (options == 1)
        {
            yNextInstance = nexts[0];
            xNextInstance = nexts[0];
            aNextInstance = nexts[0];
            bNextInstance = nexts[0];
        }
        else
        {
            yNextInstance = xNextInstance = aNextInstance = bNextInstance = null;
        }
    }
    public void UpdateReferences(DialogueInstance[] nexts)
    {
        if (options == 4)
        {
            yNextInstance = nexts[0];
            xNextInstance = nexts[1];
            aNextInstance = nexts[2];
            bNextInstance = nexts[3];
        }
        else if (options == 3)
        {
            yNextInstance = nexts[0];
            xNextInstance = nexts[1];
            aNextInstance = nexts[2];
            bNextInstance = nexts[2];
        }
        else if (options == 2)
        {
            yNextInstance = nexts[0];
            xNextInstance = nexts[0];
            aNextInstance = nexts[1];
            bNextInstance = nexts[1];
        }
        else if (options == 1)
        {
            yNextInstance = nexts[0];
            xNextInstance = nexts[0];
            aNextInstance = nexts[0];
            bNextInstance = nexts[0];
        }
        else
        {
            yNextInstance = xNextInstance = aNextInstance = bNextInstance = null;
        }
    }
}
