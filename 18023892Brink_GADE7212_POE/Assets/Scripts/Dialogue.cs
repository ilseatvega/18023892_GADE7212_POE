using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Dialogue
{
    public DoubleLinkList D = new DoubleLinkList();

    public Dialogue(string path)
   {
        string[] lines;

        using (StreamReader sr = new StreamReader(path))
        {
            string input = sr.ReadToEnd();

            
            //Debug.Log("Raw string data in: " + input);

            lines = input.Split('\n');
            
        }

            for (int i = 0; i < lines.Length; i++)
            {
                if (D.First != null)
                {
                Debug.Log("addng additional node: " + lines[i]);
                    D.Add(lines[i]);
                Debug.Log("node added") ;
            }
                else
                {
                Debug.Log("addng first node: " + lines[i]);
                D.Addfirst(lines[i]);
                Debug.Log("node added");
            }

            }

        //Debug.Log("Current Node: " + D.Active.Data);
        //D.Reset();
        //Debug.Log("Current Node: " + D.Active.Data);
    }

    public DoubleLinkList D1 { get => D; set => D = value; }
}
