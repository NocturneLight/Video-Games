using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GatheringSystem : MonoBehaviour 
{
	// Create variables here.
	public Text itemCountText = null;
	private int itemCount = 0;


	// Use this for initialization
	void Start () 
	{
		// Default text for the item count.
		itemCountText.text = "0/" + DialogueSystem.getCollectNumber();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void FixedUpdate()
	{
		// If it's visible, update the GUI information.
		if (itemCountText.gameObject.activeSelf)
		{
			// Always update the local and global item count values in the text component of the UI
			// when we make the GUI visible.
			itemCountText.text = itemCount + "/" + DialogueSystem.getCollectNumber();

			// Whenever the global collect number is 0,  we know there's no mission. 
			// So, we make the local item count always be 0. 
			if (DialogueSystem.getCollectNumber() == 0)
			{
				itemCount = 0;
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		// If the object collided with is a machine piece...
		if (other.gameObject.CompareTag("Machine Piece") && itemCount < DialogueSystem.getCollectNumber())
		{
			// To check the global collect variable.
			//print(DialogueSystem.getCollectNumber());

			// Make the item disappear.
			other.gameObject.SetActive(false);

			// Then update the item count.
			itemCountText.text = ++itemCount + "/" + DialogueSystem.getCollectNumber();
		}
		
		// When the number of collected items is equal to the global collect number and the global
		// collect number isn't 0, then set the global mission boolean to true.
		if (itemCount == DialogueSystem.getCollectNumber() && DialogueSystem.getCollectNumber() != 0)
		{
			DialogueSystem.setMissionComplete(true);
		}
	}
}
