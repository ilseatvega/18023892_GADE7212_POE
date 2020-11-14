using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonologueTrigger : MonoBehaviour
{
    [SerializeField]
    public ScriptableDialogue dialogue;

    private Animator playerAnim;
    private void Start()
    {
        playerAnim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            NewDialogueManager.DLM.activateDialogue(dialogue);
        }

        if (NewDialogueManager.DLM.inDialogue)
        {
            playerAnim.SetBool("Talk", true);
        }
        else if (!NewDialogueManager.DLM.inDialogue)
        {
            playerAnim.SetBool("Talk", false);
        }


        //if intro scene
        if (NewDialogueManager.DLM.dialogueEnd && Input.GetMouseButtonDown(0) && 
            SceneManager.GetActiveScene() == SceneManager.GetSceneByName("INTRO"))
        {
            SceneManager.LoadScene(sceneName: "WAKEUP");
        }


        //if kitchen 1 scene
        if (NewDialogueManager.DLM.dialogueEnd && Input.GetMouseButtonDown(0) && 
            SceneManager.GetActiveScene() == SceneManager.GetSceneByName("KITCHEN") &&
            RealParser.RP.check1True &&
            RealParser.RP.check2True)
        {
                SceneManager.LoadScene(sceneName: "KITCHEN2");
        }

        //check box 1 if monologue done
        if (NewDialogueManager.DLM.dialogueEnd &&
            SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LIVINGROOM"))
        {
            RealParser.RP.ToggleCheck1();
        }

        //if livingroom mono & done tasks
        if (NewDialogueManager.DLM.dialogueEnd && Input.GetMouseButtonDown(0) &&
            SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LIVINGROOM") &&
            RealParser.RP.check1True &&
            RealParser.RP.check2True)
        {
                SceneManager.LoadScene(sceneName: "LRSLEEP");
        }

        //if end1
        if (NewDialogueManager.DLM.dialogueEnd && Input.GetMouseButtonDown(0) &&
            SceneManager.GetActiveScene() == SceneManager.GetSceneByName("END1"))
        {
            SceneManager.LoadScene(sceneName: "END1.1");
        }
        //if end2
        if (NewDialogueManager.DLM.dialogueEnd &&
            SceneManager.GetActiveScene() == SceneManager.GetSceneByName("END2"))
        {
            SceneManager.LoadScene(sceneName: "END2.1");
        }
    }
}
