using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInstance
{
    //Every dialogue instance will have pieces of player dialogue from which to choose,an audio clip that plays before them, and a "pointer" of sorts to the next dialogue instance the choice sets up
    AudioClip myClip;

    string yDialogue;
    string xDialogue;
    string aDialogue;
    string bDialogue;

    DialogueInstance nextInstance;
}
