using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Make usable outside of runtime.
[System.Serializable]

public static class DialogueSystem
{
    private static bool isTalking = false;  // A global variable to control who gets to talk.
    private static Queue<string> dialogueQueue = new Queue<string>(); // A global queue used to pass text to the UI.

    // Checks the global bool.
    public static bool getIsTalking()
    {
        return isTalking;
    }

    // Sets the value of the global bool.
    public static void setIsTalking(bool truthValue)
    {
        isTalking = truthValue;
    }

    // Allows us to check the size of the global queue.
    public static int getQueueSize()
    {
        return dialogueQueue.Count;
    }

    // Pops a string from the queue, reducing its size by 1.
    public static string popFromQueue()
    {
        return dialogueQueue.Dequeue();
    }

    // Adds dialogue to the queue.
    public static void pushToQueue(string[] script)
    {
        // If the queue is empty...
        if (dialogueQueue.Count == 0)
        {
            // Place each string in the given array into the queue.
            foreach (string item in script)
            {
                dialogueQueue.Enqueue(item);
            }
        }
    }
}
