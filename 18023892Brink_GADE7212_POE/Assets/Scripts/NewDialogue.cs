using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class NewDialogue : MonoBehaviour
{
    public Graph G = new Graph();

    public NewDialogue(string path)
    {
        string[] lines;

        using (StreamReader sr = new StreamReader(path))
        {
            string input = sr.ReadToEnd();
            
            lines = input.Split('\n');
        }
    }
}
