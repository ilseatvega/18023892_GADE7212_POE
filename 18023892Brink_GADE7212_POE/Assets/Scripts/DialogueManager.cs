using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    string filePath;
    int lineNumber;

    DoubleLinkList D = new DoubleLinkList();

    void Dialogue()
    {
        lineNumber = 1;
        D.Addfirst(ReadLine());

        lineNumber = 2;
        D.Add(ReadLine());

        foreach (Node item in D)
        {
            Debug.Log(item.Data + "");
        }
    }

    private void Awake()
    {
        filePath = Application.persistentDataPath + "\\FirstScenario.txt";
    }

    private void Start()
    {
        ExternalData.WriteTxt();

        Dialogue();

    }

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
