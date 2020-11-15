using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CommandScreen : MonoBehaviour
{
    public Button back;

    public AudioSource button;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        back.onClick.AddListener(Back);
        button = GetComponent<AudioSource>();
    }

    void Back()
    {
        if (button.isPlaying) return;
        {
            button.Play();
        }
        //load first game scene
        SceneManager.LoadScene(sceneName: "START");
    }
}
