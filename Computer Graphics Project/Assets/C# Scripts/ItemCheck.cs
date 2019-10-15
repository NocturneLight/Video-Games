using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Needed to work with UI objects.

public class ItemCheck : MonoBehaviour
{
    // Create variables exclusive to this function here.
    private Text textObject = null;


    // Start is called before the first frame update
    void Start()
    {
        // Get the component so we can work with it.
        textObject = this.GetComponent<Text>();

        // Default to the GUI being invisible.
        textObject.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called for the rendering and handling of GUI events.
    void OnGUI()
    {
        // If the Q key was pressed, show the GUI.
        textObject.enabled = Input.GetButton("Open Inventory") ? true : false;
    }
}