using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickMechanics : MonoBehaviour
{
    // Create variables here.
    public GameObject uiComponent = null;
    public GameObject textboxObject = null;
    public GameObject dialogueObject = null;
    public Text dialogueTextObject = null;
    public DialogueSystem characterText = new DialogueSystem();
    private Queue<string> sentenceQueue = new Queue<string>();
    private bool firstTime = true;
    bool end = false;

    // Start is called before the first frame update
    void Start()
    {
        if (uiComponent != null)
        {
            // Set the textbox and dialogue to false so they aren't on screen.
            textboxObject.SetActive(false);
            dialogueObject.SetActive(false);
        }   
        else
        {
            print("Forgot to add the UIComponent to this object.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        // Set our textbox and text's visibility to true.
        textboxObject.SetActive(true);
        dialogueObject.SetActive(true);

        //print(characterText.isEmpty());

        if (!characterText.isEmpty() && firstTime)
        {
            foreach (string text in characterText.dialogue)
            {
                if (!string.IsNullOrEmpty(text) && !sentenceQueue.Contains(text))
                {
                    sentenceQueue.Enqueue(text);
                }
            }

            dialogueTextObject.text = sentenceQueue.Dequeue();

            firstTime = !firstTime;
        }
        else if (!firstTime && !end)
        {
            if (sentenceQueue.Count == 0)
            {
                end = !end;
            }
            
            if (sentenceQueue.Count > 0)
            {
                dialogueTextObject.text = sentenceQueue.Dequeue();
            }
        }
        
        if (end)
        {
            // Set our textbox and text's visibility to true.
            textboxObject.SetActive(false);
            dialogueObject.SetActive(false);

            firstTime = !firstTime;
            end = !end;

            dialogueTextObject.text = "";

        }

    /*
        // If the text field isn't empty, place the string in the queue.
        foreach (string text in characterText.dialogue)
        {
            if (text != "")
            {
                //print(text);
                sentenceQueue.Enqueue(text);
            }
        }

        dialogueTextObject.text = sentenceQueue.Dequeue();
    */
        /*
        // If at the end, print that we're at the end in the log.
        if (sentenceQueue.Count == 0)
        {
            print("End of queue.");
        }
        // Else we print the text in the queue to the text field on the object.
        else
        {
            dialogueTextObject.text = sentenceQueue.Dequeue();
        }
        */

        //textboxObject.SetActive(false);
        //dialogueObject.SetActive(false);
    }
}
