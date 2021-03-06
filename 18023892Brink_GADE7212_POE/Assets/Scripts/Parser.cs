﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Parser : MonoBehaviour
{
    Hashtable commands = new Hashtable();
    Hashtable inv = new Hashtable();

    string[] interpret;
    public GameObject inputTxt;
    public GameObject outputTxt;
    string key;
    string value;


    // Start is called before the first frame update
    void Start()
    {
        AddCommmands();
        
        //IGNORE CASE
        //if (stringName.Equals("astringvalue", StringComparison.InvariantCultureIgnoreCase))
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StoreInput();
            TextOutput();
            
            //Debug.Log(interpret[0] + " " + interpret[1]);
        }
        else if (Input.GetMouseButton(0))
        {
            inputTxt.SetActive(true);
            outputTxt.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void ToggleUI()
    {
        inputTxt.SetActive(false);
        outputTxt.SetActive(true);
    }

    void TextOutput()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //IF LOOK AT ITEM
            if (interpret[0] == "look" && interpret[1] == "at")
            {
                key = null;
                value = null;
                    //string array into a single string
                    foreach (string item in interpret)
                    {
                        key += item + " ";
                    }
                //Debug.Log(key);

                value = commands[key].ToString();

                if (value == null)
                {
                    ToggleUI();
                    outputTxt.GetComponent<Text>().text = "Hmmm... that doesn't sound right.";
                    Debug.Log("Hmmm... that doesn't sound right.");
                }
                else
                {
                    Debug.Log(value);
                    ToggleUI();
                    outputTxt.GetComponent<Text>().text = value;
                }
            }

            //IF PICK UP ITEM
            else if (interpret[0] == "pick" && interpret[1] == "up")
            {
                key = null;
                value = null;
                //string array into a single string
                foreach (string item in interpret)
                {
                    key += item + " ";
                }
                //Debug.Log(key);
                
                if (key == "pick up photo ")
                {
                    ToggleUI();
                    value = commands[key].ToString();
                    inv.Add(001,"photo1");
                    Debug.Log(inv.ContainsKey(001));
                    outputTxt.GetComponent<Text>().text = value;
                }
                else if (key == "pick up noodles ")
                {
                    ToggleUI();
                    value = commands[key].ToString();
                    inv.Add(002, "noodles");
                    Debug.Log(inv.ContainsKey(002));
                    outputTxt.GetComponent<Text>().text = value;
                }
                else if (key == "pick up noodles and photo " || key == "pick up photo and noodles ")
                {
                    ToggleUI();
                    value = commands[key].ToString();
                    inv.Add(001, "photo1");
                    inv.Add(002, "noodles");
                    outputTxt.GetComponent<Text>().text = value;
                }
                else
                {
                    ToggleUI();
                    outputTxt.GetComponent<Text>().text = "Hmmm... that doesn't sound right.";
                }
            }

            //IF USING ITEM
            else if (interpret[0] == "use")
            {
                key = null;
                value = null;
                //string array into a single string
                foreach (string item in interpret)
                {
                    key += item + " ";
                }
                //Debug.Log(key);
                
                if (inv.ContainsKey(001) && key == "use photo on kettle ")
                {
                    ToggleUI();
                    value = commands[key].ToString();
                    outputTxt.GetComponent<Text>().text = value;
                }
                else if (inv.ContainsKey(002) && key == "use noodles on kettle ")
                {
                    ToggleUI();
                    value = commands[key].ToString();
                    outputTxt.GetComponent<Text>().text = value;
                }
                else if (inv.ContainsKey(001) && inv.ContainsKey(002) && (key == "use noodles and photo on kettle " || key == "use noodles and photo on kettle "))
                {
                    ToggleUI();
                    value = commands[key].ToString();
                    outputTxt.GetComponent<Text>().text = value;
                }
                else
                {
                    ToggleUI();
                    outputTxt.GetComponent<Text>().text = "Hmmm... that doesn't sound right.";
                }
            }

            //ELSE IF WRONG INPUT
            else
            {
                inputTxt.SetActive(false);
                outputTxt.SetActive(true);
                outputTxt.GetComponent<Text>().text = "Hmmm... that doesn't sound right.";
                Debug.Log("Hmmm... that doesn't sound right.");
            }
        }
    }

    void StoreInput()
    {
        //storing the input text into the array and splitting it by using space
        interpret = inputTxt.GetComponent<Text>().text.Split(' ');
    }

    //commands need to have spaces at the end
    void AddCommmands()
    {
        //LOOK AT
        commands.Add("look at kettle ", "I could use this to make some noodles.");
        commands.Add("look at plant ", "I'm surpised it isn't dead yet.");
        commands.Add("look at stove ", "We never really used the stove.");
        commands.Add("look at cupboard ", "I bet I could find some noodles in here.");
        commands.Add("look at fridge ", "Huh, I haven't seen these photos of Arnas and I since... Maybe I should take one.");
        commands.Add("look at microwave ", "Arnas' choice cooking method. Mine too, if i'm honest.");
        //PICK UP
        commands.Add("pick up photo ", "Photo has been added to inventory.");
        commands.Add("pick up noodles ", "Noodles have been added to inventory.");
        commands.Add("pick up noodles and photo ", "Noodles and photo have been added to inventory.");
        commands.Add("pick up photo and noodles ", "photo and noodles have been added to inventory.");
        //USE
        commands.Add("use noodles on kettle ", "Alright, time to try and enjoy some noodles.");
        commands.Add("use photo on kettle ", "That would never work. I need noodles!");
        commands.Add("use noodles and photo on kettle ", "Contrary to popular belief this photo isn't needed to make noodles.");
        commands.Add("use photo and noodles on kettle ", "Contrary to popular belief this photo isn't needed to make noodles.");
    }
}
