using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//for streamreader/writer
using System.IO;

public static class ExternalData
{
    //https://wellsb.com/csharp/beginners/streamreader-read-specific-line/

    //public static string ReadSpecificLine(string filePath, int lineNumber)
    //{
    //    //content is null (hasnt been read)
    //    string content = null;
    //    using (StreamReader file = new StreamReader(filePath))
    //    {
    //        //skip over all lines until linenumber
    //        //i=1 instead of 0 so that its easier to read lines
    //        for (int i = 1; i < lineNumber; i++)
    //        {
    //            //read the line in the file
    //            file.ReadLine();

    //            //if file ends
    //            if (file.EndOfStream)
    //            {
    //                break;
    //            }
    //        }
    //        //make content = the line that was read
    //        content = file.ReadLine();
    //    }
    //    //return the content of the lines
    //    return content;
    //}


}
