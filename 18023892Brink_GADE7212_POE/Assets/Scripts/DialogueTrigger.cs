using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] float interactionDist;

    private Transform player;

    private bool enable = false;

    public string dialogueFile;
    Animator NPCAnim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        NPCAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        //i fix!!

        if (Vector3.Distance(transform.position, player.position) <= interactionDist && !enable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TriggerDialogue();
                enable = true;
                this.GetComponent<NPCMovement>().enabled = false;
                NPCAnim.SetBool("Walk", false);
            }
        }
        else if (Vector3.Distance(transform.position, player.position) > interactionDist && enable)
        {
            DialogueManager.instance.EndDialogue();
            enable = false;
            this.GetComponent<NPCMovement>().enabled = true;
        }
    }

    public void TriggerDialogue()
    {
        string path = Application.dataPath + @"\ObjectData\Dialogues\" + dialogueFile + @".txt";
        DialogueManager.instance.DialogueStart(new Dialogue(path));
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, interactionDist);
    }
}
