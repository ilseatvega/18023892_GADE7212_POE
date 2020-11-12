using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class DevScenes : MonoBehaviour
{
    public Button linkedList;
    public Button textParser;
    public Button graphs;
    public Button back;

    [SerializeField]
    private GameObject[] backgrounds;

    private System.Random rand = new System.Random();


    // Start is called before the first frame update
    void Start()
    {
        linkedList.onClick.AddListener(LinkedListButton);
        textParser.onClick.AddListener(TextParser);
        graphs.onClick.AddListener(GraphsButton);
        back.onClick.AddListener(Back);

        InvokeRepeating("LoopBG", 5f, 10f);
    }

    void LinkedListButton()
    {
        //load first game scene
        SceneManager.LoadScene(sceneName: "Standalone");
    }

    void TextParser()
    {
        //load first game scene
        SceneManager.LoadScene(sceneName: "TextParser");
    }

    void GraphsButton()
    {
        //load first game scene
        SceneManager.LoadScene(sceneName: "GraphPrototype");
    }

    void Back()
    {
        //load first game scene
        SceneManager.LoadScene(sceneName: "START");
    }

    public void LoopBG()
    {

        int random = rand.Next(0, 3);
        Debug.Log(random);

        if (backgrounds[random] == backgrounds[0])
        {
            backgrounds[0].SetActive(true);
            backgrounds[1].SetActive(false);
            backgrounds[2].SetActive(false);
        }
        else if (backgrounds[random] == backgrounds[1])
        {
            backgrounds[1].SetActive(true);
            backgrounds[0].SetActive(false);
            backgrounds[2].SetActive(false);
        }
        else if (backgrounds[random] == backgrounds[2])
        {
            backgrounds[2].SetActive(true);
            backgrounds[1].SetActive(false);
            backgrounds[0].SetActive(false);
        }
    }
}
