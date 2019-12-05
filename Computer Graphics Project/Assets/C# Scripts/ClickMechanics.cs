using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickMechanics : MonoBehaviour
{
    public GameObject textbox = null;
    public GameObject choiceBox1 = null;
    public GameObject choiceBox2 = null;
    public int collectAmount = 5;
    [TextArea(5, 15)] public string[] dialogue = new string[1];
    [TextArea(5, 15)] public string[] completionDialogue = new string[1];
    private bool isTalking = false;

    void Start()
    {
        if (textbox != null && choiceBox1 != null && choiceBox2 != null)
        {
            textbox.SetActive(false);
            choiceBox1.SetActive(false);
            choiceBox2.SetActive(false);
        }
        else
        {
            print("Either the textbox or one of the choice boxes is null");
        }
    }

    // NOTE: This allows you to talk to NPC's with missions one time and then never again.
    // For non-mission NPC's, it might be simpler to create a totally separate queue and script
    // just for them.
    void OnMouseDown()
    {
        // If the mission has been completed, set the global
        // talking variable to false.
        if (DialogueSystem.getMissionComplete())
        {
            DialogueSystem.setIsTalking(false);
        }

        // If the global talking variable is false...
        if (!DialogueSystem.getIsTalking())
        {
            // Set the textbox components to true.
            textbox.SetActive(true);

            // If a mission has not been completed...
            if (!DialogueSystem.getMissionComplete())
            {
                // Place the given text into the queue.
                DialogueSystem.pushToQueue(dialogue);

                // Place the given collect amount into the given
                // global temporary integer.
                DialogueSystem.setTempInt(collectAmount);
            }
            // If a mission has been completed...
            else if (DialogueSystem.getMissionComplete())
            {
                // Place the completion text into the global queue.
                DialogueSystem.pushToQueue(completionDialogue);

                // Set the global mission boolean to false.
                DialogueSystem.setMissionComplete(false);

                // Have the model disappear.
                this.gameObject.SetActive(false);
            }

            // Display the first piece of text.
            textbox.GetComponentInChildren<Text>().text = DialogueSystem.popFromQueue();

            // Set the global talking boolean to true to 
            // prevent other objects from adding to the queue.
            DialogueSystem.setIsTalking(true);
        }
        
        // Reset the global booleans to allow an NPC to be spoken to for infinity.
        if (DialogueSystem.getIsTalking())
        {
            DialogueSystem.resetAllGlobalBooleans();
        }

        // To track variables.
        //print("tempInt: " + DialogueSystem.getTempInt() + " | missionComplete: " + DialogueSystem.getMissionComplete() + " | isTalking: " + DialogueSystem.getIsTalking() + " | local isTalking: " + isTalking);
    }
}
