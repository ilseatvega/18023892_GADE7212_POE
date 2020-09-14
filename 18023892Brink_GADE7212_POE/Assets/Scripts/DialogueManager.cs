using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    //string arnasPath;
    //string depressionPath;

    public Text NPCText;
    public Text PlayerText;

    public Text NPCName;
    public Text PName;

    public Text Prompt;

    public GameObject PlayerBox;
    public GameObject NPCBox;

    public List<string> Actors;

    Dialogue dialogue;

    bool inDialogue = false;

    public Sprite[] portraits;
    public Image portrait;

    //instance of linked list
    DoubleLinkList D = new DoubleLinkList();

    private void Awake()
    {
        //singleton
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    //------------------START------------------//
    private void Start()
    {
        Actors.Add("Player");
        Actors.Add("Arnas");
        Actors.Add("Depression");
    }

    //------------------UPDATE------------------//
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && inDialogue)
        {
            NextDialogue();
        }
    }

    //---------METHODS---------//
    
    //DIALOGUE START
    public void DialogueStart(Dialogue dlIn)
    {
        inDialogue = true;
        dialogue = dlIn;
        dialogue.D.GetNext(D.Active);

        //if player
        if (Decypher(dialogue.D.Active.Data)[0] == "0")
        {
            NPCBox.SetActive(false);
            PlayerBox.SetActive(true);

            StopAllCoroutines();
            StartCoroutine(typeSentencePlayer(Decypher(dialogue.D.Active.Data)[1]));
        }
        //if NPC
        else 
        {
            PlayerBox.SetActive(false);
            NPCBox.SetActive(true);

            NPCName.text = Actors[int.Parse(Decypher(dialogue.D.Active.Data)[0])];
            portrait.sprite = portraits[int.Parse(Decypher(dialogue.D.Active.Data)[0])];


            StopAllCoroutines();
            StartCoroutine(typeSentenceNPC(Decypher(dialogue.D.Active.Data)[1]));
        }
    }
    //DIALOGUE NEXT
    public void NextDialogue()
    {
        if (dialogue.D.Active.Next != null)
        {
            dialogue.D.GetNext(D.Active);

            //if player
            if (Decypher(dialogue.D.Active.Data)[0] == "0")
            {
                NPCBox.SetActive(false);
                PlayerBox.SetActive(true);

                StopAllCoroutines();
                StartCoroutine(typeSentencePlayer(Decypher(dialogue.D.Active.Data)[1]));
            }
            //if NPC
            else 
            {
                PlayerBox.SetActive(false);
                NPCBox.SetActive(true);

                NPCName.text = Actors[int.Parse(Decypher(dialogue.D.Active.Data)[0])];
                portrait.sprite = portraits[int.Parse(Decypher(dialogue.D.Active.Data)[0])];

                StopAllCoroutines();
                StartCoroutine(typeSentenceNPC(Decypher(dialogue.D.Active.Data)[1]));
            }
        }
        else
        {
            EndDialogue();
        }
    }

    //DIALOGUE END
    public void EndDialogue()
    {
        PlayerBox.SetActive(false);
        NPCBox.SetActive(false);
        inDialogue = false;
    }

    //DECYPHER
    //splitting strings and storing them in array
    //[0] = who is speaking (eg 1 is Arnas)
    //[1] = what they are saying
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

    //just being fancy, making text display as if it's being typed
    IEnumerator typeSentencePlayer(string sentence)
    {
        PlayerText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            PlayerText.text += letter;
            yield return new WaitForSeconds(0.04f);
        }
    }
    //same but for NPC
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
