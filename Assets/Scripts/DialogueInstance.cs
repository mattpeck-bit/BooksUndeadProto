using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInstance
{
    //Every dialogue instance will have four pieces of chosen player dialogue,an audio clip that plays before it, and a "pointer" of sorts to the next dialogue instance the choice sets up
    string yDialogue;
    string xDialogue;
    string aDialogue;
    string bDialogue;

    DialogueInstance nextInstance;
}
