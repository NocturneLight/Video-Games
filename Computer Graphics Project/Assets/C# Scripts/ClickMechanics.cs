using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickMechanics : MonoBehaviour
{
    // Create variables here.
    private GameObject textObject = null;
    public GameObject textbox = null;
    public Text textArea = null;
    public static int lineNumber = 1;
    [TextArea(5, 15)] public string[] dialogue = new string[lineNumber];

    // Start is called before the first frame update
    void Start()
    {
        // Get the text component's Game Object form.
        textObject = textArea.gameObject;

        // If the Game Objects aren't null, make them invisible.
        if (textObject != null && textbox != null)
        {
            textObject.SetActive(false);
            textbox.SetActive(false);    
        }
        // Otherwise, inform the user of the likely problem.
        else
        {
            print("You forgot to attach a text object or textbox to the ClickMechanics script.");
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        //print("Object's name is: " + objectName + " | The global bool is: " + DialogueSystem.getIsTalking());

        // Show the text and textbox.
        textObject.SetActive(true);
        textbox.SetActive(true);

        // If no object is already talking...
        if (!DialogueSystem.getIsTalking())
        {
            // Set the global talking value to true.
            DialogueSystem.setIsTalking(true);

            //print("Global dialogue bool locked by: " + objectName + " | bool: " + DialogueSystem.getIsTalking());

            // Push the dialogue on the object to the global queue.
            DialogueSystem.pushToQueue(dialogue);

            // Show the first piece of dialogue in the text box.
            textArea.text = DialogueSystem.popFromQueue();
        }
        // If an object is currently talking...
        else if (DialogueSystem.getIsTalking())
        {
            //print(objectName + " tried to talk but someone is speaking right now. | bool: " + DialogueSystem.getIsTalking());

            // If the queue size is empty...
            if (DialogueSystem.getQueueSize() == 0)
            {
                //print("T'is an empty queue");

                // Set the global talking value to false.
                DialogueSystem.setIsTalking(false);

                // Clear the text in the textbox.
                textArea.text = "";

                // Hide the text and textbox.
                textObject.SetActive(false);
                textbox.SetActive(false);  
            }
            // If the queue size is not empty, then we display a piece of dialogue.
            else
            {
                textArea.text = DialogueSystem.popFromQueue();
            }
        }
    }
}
