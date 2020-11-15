using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class StartScreen : MonoBehaviour
{
    public Button start;
    public Button commands;
    public Button devScenes;
    public Button exit;

    [SerializeField]
    private GameObject[] backgrounds;

    private System.Random rand = new System.Random();

    public AudioSource button;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        button = GetComponent<AudioSource>();

        start.onClick.AddListener(Play);
        commands.onClick.AddListener(Commands);
        devScenes.onClick.AddListener(DevScenes);
        exit.onClick.AddListener(Exit);

        //NewDialogueManager.DLM.dialogueEnd = false;

        InvokeRepeating("LoopBG", 5f, 10f);
    }

    void Play()
    {
        if (button.isPlaying) return;
        {
            button.Play();
        }
        //load first game scene
        SceneManager.LoadScene(sceneName: "INTRO");
    }

    void Commands()
    {
        if (button.isPlaying) return;
        {
            button.Play();
        }
        //load commands scene
        SceneManager.LoadScene(sceneName: "CommandsListScene");
    }

    void DevScenes()
    {
        if (button.isPlaying) return;
        {
            button.Play();
        }
        //load devscenes
        SceneManager.LoadScene(sceneName: "DevScenes");
    }

    void Exit()
    {
        if (button.isPlaying) return;
        {
            button.Play();
        }
        //quit game
        Application.Quit();
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
