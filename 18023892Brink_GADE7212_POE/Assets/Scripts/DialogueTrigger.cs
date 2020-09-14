using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DialogueTrigger : MonoBehaviour
{
    //[SerializeField] float interactionDist;

    //private Transform player;

    //private bool enable = false;

    public string dialogueFile;

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        //was gonna be used to only trigger dialogue if player is close enough
        //ran out of time

        //if (Vector3.Distance(transform.position, player.position) <= interactionDist && !enable)
        //{
            //if (Input.GetKey("e"))
            //{
                //TriggerDialogue();
                //enable = true;
            //}
        //}
        //else if (Vector3.Distance(transform.position, player.position) > interactionDist && enable)
        //{
            //DialogueManager.instance.EndDialogue();
            //enable = false;
        //}
    }

    public void TriggerDialogue()
    {
        string path = Application.dataPath + @"\ObjectData\Dialogues\" + dialogueFile + @".txt";
        DialogueManager.instance.DialogueStart(new Dialogue(path));
    }

    //private void OnDrawGizmos()
    //{
       // Gizmos.DrawWireSphere(transform.position, interactionDist);
    //}
}
