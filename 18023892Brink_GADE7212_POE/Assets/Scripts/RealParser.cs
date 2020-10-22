using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RealParser : MonoBehaviour
{
    Hashtable commands = new Hashtable();
    Hashtable inv = new Hashtable();

    string[] interpret;

    public GameObject inputTxt;
    public GameObject outputTxt;
    public GameObject inputField;
    public GameObject Arnas;
    public GameObject Depression;
    public GameObject Check1;
    public GameObject Check2;
    public GameObject Uncheck1;
    public GameObject Uncheck2;

    string key;
    string value;


    // Start is called before the first frame update
    void Start()
    {
        AddCommmands();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StoreInput();
            TextOutput();
        }
        else if (Input.GetMouseButton(0))
        {
            inputTxt.SetActive(true);
            outputTxt.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (inputField.active == true)
            {
                inputField.SetActive(false);

                Arnas.GetComponent<DialogueTrigger>().enabled = true;
                Depression.GetComponent<DialogueTrigger>().enabled = true;
            }
            else if (inputField.active == false)
            {
                inputField.SetActive(true);

                Arnas.GetComponent<DialogueTrigger>().enabled = false;
                Depression.GetComponent<DialogueTrigger>().enabled = false;
            }
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

                if (key == "pick up jug ")
                {
                    ToggleUI();
                    value = commands[key].ToString();
                    inv.Add(001, "jug");
                    outputTxt.GetComponent<Text>().text = value;
                }
                else if (key == "pick up milk ")
                {
                    ToggleUI();
                    value = commands[key].ToString();
                    inv.Add(002, "milk");
                    outputTxt.GetComponent<Text>().text = value;
                }
                else if (key == "pick up tea ")
                {
                    ToggleUI();
                    value = commands[key].ToString();
                    inv.Add(003, "tea");
                    outputTxt.GetComponent<Text>().text = value;
                }
                else if (key == "pick up milk and tea " || key == "pick up milk and tea ")
                {
                    ToggleUI();
                    value = commands[key].ToString();
                    inv.Add(002, "milk");
                    inv.Add(003, "tea");
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

                if (inv.ContainsKey(001) && key == "use jug on plant ")
                {
                    ToggleUI();
                    value = commands[key].ToString();
                    outputTxt.GetComponent<Text>().text = value;
                    Uncheck1.SetActive(false);
                    Check1.SetActive(true);
                }
                else if (inv.ContainsKey(002) && key == "use milk on kettle ")
                {
                    ToggleUI();
                    value = commands[key].ToString();
                    outputTxt.GetComponent<Text>().text = value;
                }
                else if (inv.ContainsKey(003) && key == "use tea on kettle ")
                {
                    ToggleUI();
                    value = commands[key].ToString();
                    outputTxt.GetComponent<Text>().text = value;
                }
                else if (inv.ContainsKey(002) && inv.ContainsKey(003) && (key == "use tea and milk on kettle " || key == "use milk and tea on kettle "))
                {
                    ToggleUI();
                    value = commands[key].ToString();
                    outputTxt.GetComponent<Text>().text = value;
                    Uncheck2.SetActive(false);
                    Check2.SetActive(true);
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
        commands.Add("look at kettle ", "I could use this to make some tea.");
        commands.Add("look at plant ", "I'm surpised it isn't dead yet. I should water it.");
        commands.Add("look at stove ", "We never really used the stove.");
        commands.Add("look at cupboard ", "Empty. I haven't gone shopping in weeks.");
        commands.Add("look at fridge ", "Huh, I haven't seen these photos of Arnas and I since...");
        commands.Add("look at microwave ", "Arnas' choice cooking method. Mine too, if i'm honest.");
        //PICK UP
        commands.Add("pick up milk ", "Milk has been added to your inventory.");
        commands.Add("pick up jug ", "Jug has been added to your inventory.");
        commands.Add("pick up tea ", "Tea has been added to  your inventory.");
        commands.Add("pick up tea and milk ", "Tea has been added to  your inventory.");
        commands.Add("pick up milk and tea ", "Tea has been added to  your inventory.");
        //USE
        commands.Add("use tea and milk on kettle ", "Alright, maybe this will help me sleep.");
        commands.Add("use milk and tea on kettle ", "Alright, maybe this will help me sleep.");
        commands.Add("use jug on plant ", "Hang in there buddy, it'll get better.");
        commands.Add("use tea on kettle ", "I think I'm missing something...");        commands.Add("use milk on kettle ", "I think I'm missing something...");
    }
}
