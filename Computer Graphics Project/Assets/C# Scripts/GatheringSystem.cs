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
		itemCountText.text = "0/?";
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		// If the object collided with is a machine piece...
		if (other.gameObject.CompareTag("Machine Piece"))
		{
			// Make the item disappear.
			other.gameObject.SetActive(false);

			// Then update the item count.
			itemCountText.text = ++itemCount + "/?";
		}
	}
}
