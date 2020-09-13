using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//for streamreader/writer
using System.IO;

public static class ExternalData
{
    public static void WriteTxt()
    {
        //path of file
        string path = Application.persistentDataPath + "\\FirstScenario.txt";

        //new streamwriter instance w this file path
        StreamWriter sw = new StreamWriter(path);
        //write lines used for dialogue
        sw.WriteLine("...");
        sw.WriteLine("How did it get so dark? The days have just been flying by...");
        sw.WriteLine("I didn't think this was going to be the way I lose you. Two weeks ago you were fine.");
        sw.WriteLine("A week ago you said you were feeling sick. And now...");
        sw.WriteLine("I feel so alone. Loneliness feels almost tangible, weighing down the air around me.");
        sw.WriteLine("It's lurking around every corner, waiting for those quiet moments to curl around me and suffocate me.");
        sw.WriteLine("I don't know how I'm supposed to do this without you now.");
        sw.WriteLine("No job, stuck alone in this house for the next two weeks, and even after that...");
        sw.WriteLine("*sigh*");
        sw.WriteLine("Maybe I should try get some sleep again.");
        sw.WriteLine("Maybe things will be better tomorrow.");
        //close so that it saves
        sw.Close();
    }

    //https://wellsb.com/csharp/beginners/streamreader-read-specific-line/

    public static string ReadSpecificLine(string filePath, int lineNumber)
    {
        //content is null (hasnt been read)
        string content = null;
        //using streamreader 
        using (StreamReader file = new StreamReader(Application.persistentDataPath + "\\FirstScenario.txt"))
        {
            //skip over all lines until linenumber
            //i=1 instead of 0 so that its easier to read lines
            for (int i = 1; i < lineNumber; i++)
            {
                //read the line in the file
                file.ReadLine();

                //if file ends
                if (file.EndOfStream)
                {
                    break;
                }
            }
            //make content = the line that was read
            content = file.ReadLine();
        }
        //return the content of the lines
        return content;
    }
}
