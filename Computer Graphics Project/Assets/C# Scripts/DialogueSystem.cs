using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Make usable outside of runtime.
[System.Serializable]

public static class DialogueSystem
{
    // Create our variables here.
    private static int tempInt = 0;
    private static int collectNumber = 0;
    private static int totalCollected = 0;
    private static string[] completionDialogue = null;
    private static bool yesButton = false;
    private static bool noButton = false;
    private static bool missionComplete = false;
    private static bool isTalking = false;  // A global variable to control who gets to talk.
    private static Queue<string> dialogueQueue = new Queue<string>(); // A global queue used to pass text to the UI.
    private static ArrayList choices = new ArrayList();

    public static void addToGlobalCollected(int num)
    {
        totalCollected += num;
    }

    public static int getGlobalCollected()
    {
        return totalCollected;
    }

    public static void resetAllGlobalBooleans()
    {
        yesButton = false;
        noButton = false;
        missionComplete = false;
        isTalking = false;
    }

    public static void setCompletionDialogue(string[] dialogue)
    {
        completionDialogue = dialogue;
    }

    public static void setTempInt(int num)
    {
        tempInt = num;
    }

    public static int getTempInt()
    {
        return tempInt;
    }

    public static bool yesButtonPressed()
    {
        return yesButton;
    }

    public static bool noButtonPressed()
    {
        return noButton;
    }

    public static void setYesButton(bool truth)
    {
        yesButton = truth;
    }

    public static void setNoButton(bool truth)
    {
        noButton = truth;
    }

    public static string getChoiceAt(int index)
    {
        return (string)choices[index];
    }

    public static void setChoices(string option)
    {
        choices.Add(option);
    }

    public static void removeChoices()
    {
        choices.Clear();
    }

    public static int getChoiceSize()
    {
        return choices.Count;
    }

    public static string peekQueue()
    {
        return (dialogueQueue.Count == 0) ? "" : dialogueQueue.Peek();
    }

    public static void setCollectNumber()
    {
        // Move tempInt to collectNumber.
        collectNumber = tempInt;

        // Clear tempInt.
        tempInt = 0;
    }

    public static int getCollectNumber()
    {
        return collectNumber;
    }

    // Checks the global bool.
    public static bool getIsTalking()
    {
        return isTalking;
    }

    public static bool getMissionComplete()
    {
        return missionComplete;
    }

    // Sets the value of the global bool.
    public static void setIsTalking(bool truthValue)
    {
        isTalking = truthValue;
    }

    public static void setMissionComplete(bool truthValue)
    {
        missionComplete = truthValue;
    }

    // Allows us to check the size of the global queue.
    public static int getQueueSize()
    {
        return dialogueQueue.Count;
    }

    // Pops a string from the queue, reducing its size by 1.
    public static string popFromQueue()
    {
        return (dialogueQueue.Count == 0) ?  "" : dialogueQueue.Dequeue();
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
