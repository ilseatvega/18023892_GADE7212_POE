using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using UnityEngine.SceneManagement;

public class PlayMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("START"))
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMusic();
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("INTRO"))
        {
            GameObject.FindGameObjectWithTag("BGMusic").GetComponent<Music>().PlayMusic();
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("END1") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("END2"))
        {
            GetComponent<Music>().PlayMusic();
        }
    }
}
