using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Parser : MonoBehaviour
{
    Hashtable commands = new Hashtable();
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
            ifNull();
            
            //Debug.Log(interpret[0] + " " + interpret[1]);
        }
        else if (Input.GetMouseButton(0))
        {
            inputTxt.SetActive(true);
            outputTxt.SetActive(false);
        }
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
                    inputTxt.SetActive(false);
                    outputTxt.SetActive(true);
                    outputTxt.GetComponent<Text>().text = "Hmmm... that doesn't sound right.";
                    Debug.Log("Hmmm... that doesn't sound right.");
                }
                else
                {
                    Debug.Log(value);
                    inputTxt.SetActive(false);
                    outputTxt.SetActive(true);
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

                value = commands[key].ToString();

                if (value == null)
                {
                    inputTxt.SetActive(false);
                    outputTxt.SetActive(true);
                    outputTxt.GetComponent<Text>().text = "Hmmm... that doesn't sound right.";
                    Debug.Log("Hmmm... that doesn't sound right.");
                }
                else
                {
                    Debug.Log(value);
                    inputTxt.SetActive(false);
                    outputTxt.SetActive(true);
                    outputTxt.GetComponent<Text>().text = value;
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

                value = commands[key].ToString();

                if (value == null)
                {
                    inputTxt.SetActive(false);
                    outputTxt.SetActive(true);
                    outputTxt.GetComponent<Text>().text = "Hmmm... that doesn't sound right.";
                    Debug.Log("Hmmm... that doesn't sound right.");
                }
                else
                {
                    Debug.Log(value);
                    inputTxt.SetActive(false);
                    outputTxt.SetActive(true);
                    outputTxt.GetComponent<Text>().text = value;
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
        commands.Add("look at fridge ", "Huh, I haven't seen these photos of Arnas and I since...");
        commands.Add("look at microwave ", "Arnas' choice cooking method. Mine too, if i'm honest.");
        //PICK UP
        commands.Add("pick up photo ", "This one was only taken a month ago...");
        commands.Add("pick up photos ", "This one was only taken a month ago...");
        commands.Add("pick up noodle ", "Cheese, cheese and cheese. guess i'm eating cheese noodles.");
        commands.Add("pick up noodles ", "Cheese, cheese and cheese. guess i'm eating cheese noodles.");
        //USE
        commands.Add("use noodles on kettle ", "Alright, time to try and enjoy some noodles.");
        commands.Add("use photo on kettle ", "That would never work.");
        commands.Add("use noodles and photo on kettle ", "Contrary to popular belief this photo isn't needed to make noodles.");
        commands.Add("use photo and noodles on kettle ", "Contrary to popular belief this photo isn't needed to make noodles.");
    }

    void ifNull()
    {
        if (value == null)
        {
            inputTxt.SetActive(false);
            outputTxt.SetActive(true);
            outputTxt.GetComponent<Text>().text = "Hmmm... that doesn't sound right.";
            Debug.Log("Hmmm... that doesn't sound right.");
        }
    }
}
