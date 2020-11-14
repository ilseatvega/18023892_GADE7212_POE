using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using UnityEngine.UI;

public class InvManager : MonoBehaviour
{
    public GameObject tea;
    public GameObject milk;
    public GameObject jug;
    public GameObject photo;
    public GameObject remote;
    public GameObject album;
    public GameObject clothes;
    public GameObject dishes;

    public Text teaText;
    public Text milkText;
    public Text jugText;
    public Text photoText;
    public Text remoteText;
    public Text albumText;
    public Text clothesText;
    public Text dishesText;

    // Update is called once per frame
    void Update()
    {
        Contains();
    }

    void Contains()
    {
        if (RealParser.RP.inv.ContainsKey(001))
        {
            jug.SetActive(false);
            jugText.enabled = false;
        }
        if (RealParser.RP.inv.ContainsKey(002))
        {
            milk.SetActive(false);
            milkText.enabled = false;
        }
        if (RealParser.RP.inv.ContainsKey(003))
        {
            tea.SetActive(false);
            teaText.enabled = false;
        }
        if (RealParser.RP.inv.ContainsKey(004))
        {
            photo.SetActive(false);
            photoText.enabled = false;
        }
        if (RealParser.RP.inv.ContainsKey(005))
        {
            remote.SetActive(false);
            remoteText.enabled = false;
        }
        if (RealParser.RP.inv.ContainsKey(006))
        {
            album.SetActive(false);
            albumText.enabled = false;
        }
        if (RealParser.RP.inv.ContainsKey(007))
        {
            clothes.SetActive(false);
            clothesText.enabled = false;
        }
        if (RealParser.RP.inv.ContainsKey(008))
        {
            dishes.SetActive(false);
            dishesText.enabled = false;
        }
    }
}
