using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Linq;

public class NextScene : MonoBehaviour
{
    private void Update()
    {
       
    }

    void OnCollisionEnter2D(Collision2D wall)
    {
        //if wall collides w player & dialogue ended
        if (wall.gameObject.tag == "Player" && NewDialogueManager.DLM.dialogueEnd)
        {
            //load next scene in build manager
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
