using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using UnityEngine.SceneManagement;

public class Sleep : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Sleeping());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Sleeping()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("LR2");
    }
}
