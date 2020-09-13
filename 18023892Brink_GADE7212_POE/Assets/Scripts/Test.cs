using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    //strings to hold filepath and number
    string testPath;
    int lineNumber =1;

    public Text NPCText;
    public Text PlayerText;

    public Text DName;
    public Text JName;

    public Text Prompt;

    public GameObject PlayerBox;
    public GameObject DepressionBox;

    public List<string> Actors;

    Dialogue dialogue;

    bool inDialogue = false;

    //instance of linked list
    DoubleLinkList D = new DoubleLinkList();

    private void Start()
    {
        testPath = Application.persistentDataPath + "\\DialogueTest.txt";

        dialogue = new Dialogue(testPath);
        
        Actors.Add("Player");
        Actors.Add("Depression");
    }

    private void Update()
    {
        if (Input.GetKeyDown("e") && !inDialogue)
        {
            DialogueStart();
            Prompt.enabled = false;
        }

        if (Input.GetMouseButtonDown(0) && inDialogue)
        {
            NextDialogue();
        }
    }

    //---------METHODS---------//
    //
    void DialogueStart()
    {
        inDialogue = true;
        dialogue.D.GetNext(D.Active);

        //if player
        if (Decypher(dialogue.D.Active.Data)[0] == "0")
        {
            DepressionBox.SetActive(false);
            PlayerBox.SetActive(true);

            StopAllCoroutines();
            StartCoroutine(typeSentencePlayer(Decypher(dialogue.D.Active.Data)[1]));

            //PlayerText.text = Decypher(dialogue.D.Active.Data)[1];
        }
        else
        {
            PlayerBox.SetActive(false);
            DepressionBox.SetActive(true);

            StopAllCoroutines();
            StartCoroutine(typeSentenceNPC(Decypher(dialogue.D.Active.Data)[1]));

            //NPCText.text = Decypher(dialogue.D.Active.Data)[1];
        }
    }

    void NextDialogue()
    {
        if (dialogue.D.Active.Next != null)
        {
            dialogue.D.GetNext(D.Active);
            if (Decypher(dialogue.D.Active.Data)[0] == "0")
            {
                DepressionBox.SetActive(false);
                PlayerBox.SetActive(true);

                StopAllCoroutines();
                StartCoroutine(typeSentencePlayer(Decypher(dialogue.D.Active.Data)[1]));

                //PlayerText.text = Decypher(dialogue.D.Active.Data)[1];
            }
            else
            {
                PlayerBox.SetActive(false);
                DepressionBox.SetActive(true);

                StopAllCoroutines();
                StartCoroutine(typeSentenceNPC(Decypher(dialogue.D.Active.Data)[1]));

                //NPCText.text = Decypher(dialogue.D.Active.Data)[1];
            }
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        PlayerBox.SetActive(false);
        DepressionBox.SetActive(false);
        inDialogue = false;
    }

    public string[] Decypher(string lineIn)
    {
        string[] output = lineIn.Split('#');
        //Debug.Log("Output Length: " + output.Length);

        for (int i = 0; i < output.Length; i++)
        {
            //Debug.Log(output[i]);
        }
        return output;
    }

    IEnumerator typeSentencePlayer(string sentence)
    {
        PlayerText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            PlayerText.text += letter;
            yield return new WaitForSeconds(0.04f);
        }
    }

    IEnumerator typeSentenceNPC(string sentence)
    {
        NPCText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            NPCText.text += letter;
            yield return new WaitForSeconds(0.04f);
        }
    }
}
