using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Make usable outside of runtime.
[System.Serializable]

public class DialogueSystem
{
    // Create variables here.
    public static int lineNumber = 1;                                       // The number of lines an object has.
    [TextArea(5, 15)] public string[] dialogue = new string[lineNumber];    // That which stores the dialogue.

    public bool isEmpty()
    {
        // Create local variables here.
        int emptyCount = 0;

        // Iterate through the string array...
        foreach (string item in dialogue)
        {
            
            // If we hit an empty string...
            if (string.IsNullOrEmpty(item))
            {
                // Increment emptyCount.
                emptyCount++;
            }
        }

        // Return true if emptyCount is not 0, false otherwise.
        return (emptyCount == 0) ? false : true;
    }
}
