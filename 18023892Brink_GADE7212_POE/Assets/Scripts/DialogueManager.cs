using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //strings to hold filepath and number
    string filePath;
    int lineNumber;

    public GameObject DialogueText;

    public GameObject DName;
    public GameObject AName;
    public GameObject JName;

    public GameObject PlayerCharacter;
    public GameObject DepressionCharacter;
    public GameObject ArnasCharacter;

    public GameObject PlayerBox;
    public GameObject DepressionBox;
    public GameObject ArnasBox;

    //instance of linked list
    DoubleLinkList D = new DoubleLinkList();

    private void Awake()
    {
       // filePath = Application.persistentDataPath + "\\FirstScenario.txt";
    }

    private void Start()
    {
        filePath = Application.persistentDataPath + "\\FirstScenario.txt";

        //write text to file
        ExternalData.WriteTxt();
        Dialogue();

        //DialogueText.GetComponent<Text>().text = D.GetNth(1);
        //DialogueText.GetComponent<Text>().text = D.GetNth(2);
        //DialogueText.GetComponent<Text>().text = D.GetNth(3);

    }

    private void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            PlayerBox.SetActive(true);
            //DialogueText.GetComponent<Text>().text = D.GetNext();
            //DialogueText.GetComponent<Text>().text = D.GetNext();
            //DialogueText.GetComponent<Text>().text = D.GetNth(3);
            Debug.Log(D.GetNext());
            Debug.Log(D.GetNext());
            Debug.Log(D.GetNext());
        }
    }

    //---------METHODS---------//

    void Dialogue()
    {
        lineNumber = 1;
        D.Addfirst(ReadLine());

        lineNumber = 2;
        D.Add(ReadLine());

        lineNumber = 3;
        D.Add(ReadLine());
    }

    //
    private string ReadLine()
    {
        string lineCont = ExternalData.ReadSpecificLine(filePath, lineNumber);

        if (lineCont != null)
        {
            //Debug.Log(lineCont);
        }
        return lineCont;
    }
}
