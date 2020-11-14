using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class RealParser : MonoBehaviour
{
    //singleton
    public static RealParser _rp;
    public static RealParser RP { get { return _rp; } }

    Hashtable commands= new Hashtable();
    public Hashtable inv = new Hashtable();

    private void Awake()
    {
        if (_rp != null && _rp != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _rp = this;
        }

        //blank key to give access to any dialoge that has no key
        inv.Add(000, "");
    }
    string[] interpret;

    public GameObject inputTxt;
    public GameObject outputTxt;
    public GameObject inputField;
    public GameObject Arnas;
    public GameObject Depression;
    public GameObject Player;
    public GameObject Check1;
    public GameObject Check2;
    public GameObject Uncheck1;
    public GameObject Uncheck2;

    public bool check1True = false;
    public bool check2True = false;

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

                Arnas.GetComponent<NewDialogueTrigger>().enabled = true;
                Depression.GetComponent<NewDialogueTrigger>().enabled = true;
                Player.GetComponent<MonologueTrigger>().enabled = true;
            }
            else if (inputField.active == false)
            {
                inputField.SetActive(true);

                Arnas.GetComponent<NewDialogueTrigger>().enabled = false;
                Depression.GetComponent<NewDialogueTrigger>().enabled = false;
                Player.GetComponent<MonologueTrigger>().enabled = false;
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
                else if (key == "pick up photo ")
                {
                    ToggleUI();
                    value = commands[key].ToString();
                    inv.Add(004, "photo");
                    outputTxt.GetComponent<Text>().text = value;
                }
                else if (key == "pick up remote " || key == "pick up tv remote ")
                {
                    ToggleUI();
                    value = commands[key].ToString();
                    inv.Add(005, "remote");
                    outputTxt.GetComponent<Text>().text = value;
                }
                else if (key == "pick up album " || key == "pick up photo album ")
                {
                    ToggleUI();
                    value = commands[key].ToString();
                    inv.Add(006, "photo album");
                    outputTxt.GetComponent<Text>().text = value;
                }
                else if (key == "pick up dirty clothes " || key == "pick up clothes ")
                {
                    ToggleUI();
                    value = commands[key].ToString();
                    inv.Add(007, "clothes");
                    outputTxt.GetComponent<Text>().text = value;
                    ToggleCheck1();
                }
                else if (key == "pick up dishes " || key == "pick up dirty dishes ")
                {
                    ToggleUI();
                    value = commands[key].ToString();
                    inv.Add(008, "dishes");
                    outputTxt.GetComponent<Text>().text = value;
                    ToggleCheck2();
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
                    ToggleCheck1();
                    inv.Remove(001);
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
                    ToggleCheck2();
                    inv.Remove(002);
                    inv.Remove(003);
                }
                else if (inv.ContainsKey(005) && key == "use remote on tv " || key == "use tv remote on tv ")
                {
                    ToggleUI();
                    value = commands[key].ToString();
                    outputTxt.GetComponent<Text>().text = value;
                    ToggleCheck2();
                    inv.Remove(005);
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
        commands.Add("look at plant ", "I'm surpised it isn't dead yet.");
        commands.Add("look at stove ", "We never really used the stove.");
        commands.Add("look at cupboard ", "Empty. I haven't gone shopping in weeks.");
        commands.Add("look at fridge ", "Huh, I haven't seen these photos of Arnas and I since...");
        commands.Add("look at microwave ", "Arnas' choice cooking method. Mine too, if i'm honest.");
        commands.Add("look at photo ", "An old photo of Arnas and I on a beach somewhere... I really do miss him.");
        //livingroom
        commands.Add("look at couch ", "My bed's comfier but I think I might sleep on the couch today.");
        commands.Add("look at box ", "Was this here before?");
        //bedroom
        commands.Add("look at bed ", "where i spend most of my time these days. i really am pathetic.");
        commands.Add("look at drawer ", "This used to belong to Arnas... I can't even bear to look at everything inside it.");
        commands.Add("look at clothes ", "maybe i should clean these up. or i could just sleep.");
        commands.Add("look at dishes ", "these have been piling up... but i'm so tired right now.");

        //PICK UP
        //kitchen
        commands.Add("pick up milk ", "Milk has been added to your inventory.");
        commands.Add("pick up jug ", "Jug has been added to your inventory.");
        commands.Add("pick up tea ", "Tea has been added to your inventory.");
        commands.Add("pick up tea and milk ", "Tea has been added to your inventory.");
        commands.Add("pick up milk and tea ", "Tea has been added to your inventory.");
        commands.Add("pick up photo ", "Photo has been added to your inventory.");
        //livingroom
        commands.Add("pick up remote ", "TV Remote has been added to your inventory.");
        commands.Add("pick up tv remote ", "TV Remote has been added to your inventory.");
        commands.Add("pick up album ", "Photo Album has been added to your inventory.");
        commands.Add("pick up photo album ", "Photo Album has been added to your inventory.");
        //bedroom
        commands.Add("pick up clothes ", "Dirty Clothes have been added to your inventory.");
        commands.Add("pick up dirty clothes ", "Dirty Clothes have been added to your inventory.");
        commands.Add("pick up dirty dishes ", "Dirty Clothes have been added to your inventory.");
        commands.Add("pick up dishes ", "Dirty Dishes have been added to your inventory.");

        //USE
        //kitchen
        commands.Add("use tea and milk on kettle ", "Alright, maybe this will help me sleep.");
        commands.Add("use milk and tea on kettle ", "Alright, maybe this will help me sleep.");
        commands.Add("use jug on plant ", "Hang in there buddy, it'll get better.");
        commands.Add("use tea on kettle ", "I think I'm missing something...");
        commands.Add("use milk on kettle ", "I think I'm missing something...");
        //livingroom
        commands.Add("use remote on tv ", "Might as well watch some TV. I have nothing better to do.");
        commands.Add("use tv remote on tv ", "Might as well watch some TV. I have nothing better to do.");

        //MOVING TO NEXT SCENE
    }

    public void ToggleCheck1()
    {
        Uncheck1.SetActive(false);
        Check1.SetActive(true);
        check1True = true;
    }

    public void ToggleCheck2()
    {
        Uncheck2.SetActive(false);
        Check2.SetActive(true);
        check2True = true;
    }
}
