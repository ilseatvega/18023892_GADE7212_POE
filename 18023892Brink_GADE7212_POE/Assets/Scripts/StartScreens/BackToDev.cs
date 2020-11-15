using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToDev : MonoBehaviour
{
    public Button back;
    public AudioSource button;

    // Start is called before the first frame update
    void Start()
    {
        back.onClick.AddListener(Back);
        button = GetComponent<AudioSource>();
    }

    void Back()
    {
        //DontDestroyOnLoad(gameObject);
        if (button.isPlaying) return;
        {
            button.Play();
        }
        //load dev game scenes
        SceneManager.LoadScene(sceneName: "DevScenes");
    }
}
