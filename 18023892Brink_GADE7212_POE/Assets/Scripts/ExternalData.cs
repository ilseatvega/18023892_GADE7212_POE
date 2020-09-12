using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public static class ExternalData
{
    public static void WriteTxt()
    {
        string path = Application.persistentDataPath + "\\FirstScenario.txt";

        StreamWriter sw = new StreamWriter(path);
        sw.WriteLine("this is just");
        sw.WriteLine(" a test!");

        sw.Close();
    }


    public static string ReadSpecificLine(string filePath, int lineNumber)
    {
        string content = null;
        using (StreamReader file = new StreamReader(Application.persistentDataPath + "\\FirstScenario.txt"))
        {
            for (int i = 1; i < lineNumber; i++)
            {
                file.ReadLine();

                if (file.EndOfStream)
                {
                    break;
                }
            }
            content = file.ReadLine();
        }
        return content;
    }
}
