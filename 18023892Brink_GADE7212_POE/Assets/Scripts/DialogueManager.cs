using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    //DLinkedList _testList = new DLinkedList(new Node("why"));

    //void loadDialogue()
    //{
    //    _testList.AddNode(new Node("what"), _testList.getActive());

    //}

    DoubleLinkList D = new DoubleLinkList();

    void Dialogue()
    {
        D.Addfirst("hello");
        D.Add("my name is ilse");

        foreach (Node item in D)
        {
            Debug.Log(item.Data + "");
        }
    }

    private void Start()
    {
        Dialogue();
    }
}
