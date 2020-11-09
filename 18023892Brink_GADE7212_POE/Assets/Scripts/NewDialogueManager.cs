using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewDialogueManager : MonoBehaviour
{
    public Graph G = new Graph();
    private Graph.GraphNodes currentNode = new Graph.GraphNodes();

    public static NewDialogueManager instance;
    
    public Text NPCText;
    public Text PlayerText;

    public Text NPCName;
    public Text PName;

    public Text Prompt;

    public GameObject PlayerBox;
    public GameObject NPCBox;

    public List<string> Actors;

    //NewDialogue dialogue;

    bool inDialogue = false;

    public Sprite[] portraits;
    public Image portrait;

    //dictionaries, keys for all dicts are the same value
    public Dictionary<string, string> Name = new Dictionary<string, string>();
    public Dictionary<string, string> Words = new Dictionary<string, string>();
    public Dictionary<string, string> Option1 = new Dictionary<string, string>();
    public Dictionary<string, string> Option2 = new Dictionary<string, string>();

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
            //NextDialogue();
        }
    }

    //---------METHODS---------//



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
