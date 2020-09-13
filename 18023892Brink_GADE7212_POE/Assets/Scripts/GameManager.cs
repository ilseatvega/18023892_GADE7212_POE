using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //instance of linked list
    DoubleLinkList D = new DoubleLinkList();

    public GameObject DName;
    public GameObject AName;
    public GameObject JName;

    public GameObject DialogueText;

    public GameObject PlayerCharacter;
    public GameObject DepressionCharacter;
    public GameObject ArnasCharacter;

    public GameObject PlayerBox;
    public GameObject DepressionBox;
    public GameObject ArnasBox;

    // Start is called before the first frame update
    void Start()
    {
        //DialogueText.GetComponent<Text>().text = D.GetNth(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
