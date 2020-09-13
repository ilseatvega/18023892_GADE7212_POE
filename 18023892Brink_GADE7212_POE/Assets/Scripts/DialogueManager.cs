using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //strings to hold filepath and number
    string testPath;
    string protoPath;
    int lineNumber;

    public GameObject NPCText;
    public GameObject PlayerText;

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

    private void Start()
    {
        testPath = Application.persistentDataPath + "\\DialogueTest.txt";
        protoPath = Application.persistentDataPath + "\\Prototype.txt";

        //Dialogue();


    }

    private void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            PlayerBox.SetActive(true);
            JName.SetActive(true);
            PlayerText.SetActive(true);
            
            PlayerText.GetComponent<Text>().text = D.GetNext(D.Active);
            //NPCText.GetComponent<Text>().text = D.GetNext(D.Active);

            //Debug.Log(D.GetNext(D.Active));
        }
        if (Input.GetMouseButtonDown(0))
        {
            PlayerText.GetComponent<Text>().text = D.GetNext(D.Active);
            //Debug.Log(D.GetNext(D.Active));
        }
    }

    //---------METHODS---------//

    //void Dialogue()
    //{
    //    lineNumber = 1;
    //    D.Addfirst(ReadTestLine());
    //    lineNumber = 2;
    //    D.Add(ReadTestLine());
    //    lineNumber = 3;
    //    D.Add(ReadTestLine());
    //    lineNumber = 4;
    //    D.Add(ReadTestLine());
    //    lineNumber = 5;
    //    D.Add(ReadTestLine());
    //    lineNumber = 6;
    //    D.Add(ReadTestLine());
    //    lineNumber = 7;
    //    D.Add(ReadTestLine());
    //    lineNumber = 8;
    //    D.Add(ReadTestLine());
    //    lineNumber = 9;
    //    D.Add(ReadTestLine());
    //    lineNumber = 10;
    //    D.Add(ReadTestLine());
    //    lineNumber = 11;
    //    D.Add(ReadTestLine());
    //    lineNumber = 12;
    //    D.Add(ReadTestLine());
    //    lineNumber = 13;
    //    D.Add(ReadTestLine());
    //}

    //readline for test scenario
    //private string ReadTestLine()
    //{
    //    //string lineCont = ExternalData.ReadSpecificLine(testPath, lineNumber);

    //    if (lineCont != null)
    //    {
    //        //Debug.Log(lineCont);
    //    }
    //    return lineCont;
    //}
}
