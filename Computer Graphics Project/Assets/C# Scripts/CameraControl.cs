using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour 
{

	// Create our variables here.
	public GameObject playerObject; // Allows us to attach a GameObject to the script in the Unity Editor.
	private Vector3 offset;

	// Use this for initialization
	void Start() 
	{
		// Get the offset coordinates.
		offset = this.transform.position - playerObject.transform.position;
	}
	
	// Update is called once per frame
	void Update() 
	{
		// Offset the position to prevent the camera from rotating with the GameObject.
		this.transform.position = playerObject.transform.position + offset;
	}
}
