using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToDev : MonoBehaviour
{
    public Button back;

    // Start is called before the first frame update
    void Start()
    {
        back.onClick.AddListener(Back);
    }

    void Back()
    {
        //load first game scene
        SceneManager.LoadScene(sceneName: "DevScenes");
    }
}
