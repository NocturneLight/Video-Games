using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueMechanics : MonoBehaviour
{
    // Create variables here.
    public GameObject textbox = null;
    public GameObject choiceBox1 = null;
    public GameObject choiceBox2 = null;
    private Text choiceText1 = null;
    private Text choiceText2 = null;

    // Start is called before the first frame update
    void Start()
    {
        // If we're not missing one of the game objects, get their text components.
        if (choiceBox1 != null && choiceBox2 != null)
        {
            choiceText1 = choiceBox1.GetComponentInChildren<Text>();
            choiceText2 = choiceBox2.GetComponentInChildren<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TextboxButtonPress()
    {
        // Create local variables here.
        Text textComp = this.gameObject.GetComponentInChildren<Text>();
        string peekedString = DialogueSystem.peekQueue();

        // If we encounter our separator '|'...
        if (peekedString.Contains("|"))
        {
            // Temporarily store the choice strings.
            string[] tempYes = DialogueSystem.popFromQueue().Split('|');
            string[] tempNo = DialogueSystem.popFromQueue().Split('|');

            // Place the yes/no response text into the ArrayList.
            DialogueSystem.setChoices(tempYes[1]);
            DialogueSystem.setChoices(tempNo[1]);

            // Set the text components of the choice buttons with the yes/no choice text.
            choiceText1.text = tempYes[0];
            choiceText2.text = tempNo[0];
        }
        
        // If there are choices, show the choice UI.
        if (DialogueSystem.getChoiceSize() == 2)
        {
            choiceBox1.SetActive(true);
            choiceBox2.SetActive(true);
        }
        
        // Display the next piece of text in the global queue when this function gets called.
        textComp.text = DialogueSystem.popFromQueue();
        
        // If true is returned, then we got "", so reverse the 
        // truth value to false so we can hide the UI.
        this.gameObject.SetActive(!textComp.text.Equals(""));

        // When all dialogue related UI is invisible, do the following...
        if (!this.gameObject.activeSelf && !choiceBox1.activeSelf && !choiceBox2.activeSelf)
        {
            // Set the collect number to the global collect variable.
            DialogueSystem.setCollectNumber();
        }
    }

    public void ChoiceButtonPress()
    {
        
    }

    public void yesPressed()
    {
        // Hide the choice UI.
        this.gameObject.SetActive(false);
        choiceBox2.SetActive(false);

        // Set the text component on the textbox to the yes dialogue in the global ArrayList.
        textbox.GetComponentInChildren<Text>().text = DialogueSystem.getChoiceAt(0);

        // Make the textbox UI visible.
        textbox.gameObject.SetActive(true);

        // We've picked yes, so we're done. Clear the global choice ArrayList.
        DialogueSystem.removeChoices();
    }

    public void noPressed()
    {
        // Hide the choice UI.
        this.gameObject.SetActive(false);
        choiceBox1.SetActive(false);

        // Set the text component on the textbox to the no dialogue in the global ArrayList.
        textbox.GetComponentInChildren<Text>().text = DialogueSystem.getChoiceAt(1);

        // Make the textbox UI visible.
        textbox.gameObject.SetActive(true);

        // We've picked yes, so we're done. Clear the global choice ArrayList.
        //DialogueSystem.removeChoices();

        // Check the global choice size variable.
        //print(DialogueSystem.getChoiceSize());
    }
}
