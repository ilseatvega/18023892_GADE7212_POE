using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using UnityEngine.SceneManagement;

public class StopMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //if scene is start stop palying end music
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("START"))
        {
            GameObject.FindGameObjectWithTag("ENDMusic").GetComponent<Music>().StopMusic();
        }
        //if scene is intro stop playing start
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("INTRO"))
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().StopMusic();
        }
        //if scene is end stop playing bg
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("END1") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("END2"))
        {
            GameObject.FindGameObjectWithTag("BGMusic").GetComponent<Music>().StopMusic();
        }
    }
}
