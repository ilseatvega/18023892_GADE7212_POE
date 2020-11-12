using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using System;
using System.Linq;

public class NewDialogueTrigger : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void Update()
    {
        NewDialogueManager._dlm.StartDialogue();
        NewDialogueManager._dlm.Interact();
    }
}
