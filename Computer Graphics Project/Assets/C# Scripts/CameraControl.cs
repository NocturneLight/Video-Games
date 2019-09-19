using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour 
{

	// Create our variables here.
	public GameObject followObject = null;
	public float cameraSpeed = 10.0f;	// Determines the speed of the camera.
	public float minClamp = -5.0f;
	public float maxClamp = 70.0f; // Determines how far up and down we want the camera to go.
	public float controlSensitivity = 80.0f; // Determines how sensitive to button presses the camera should be.
	private Vector3 followPosition = Vector3.zero;
	private Vector3 distanceToPlayer = Vector3.zero;
	private Vector2 mousePosition = Vector2.zero;
	private Vector2 finalInput = Vector2.zero;
	private Vector2 smoothing = Vector2.zero;
	private Vector2 rotate = Vector2.zero;


	// Use this for initialization
	void Start() 
	{
		// Retrieve the object's transform values in the form of euler angles.
		Vector3 tempRotate = this.transform.localRotation.eulerAngles;

		// Store the values retrieved from the object in our rotate variable.
		rotate = new Vector2(tempRotate.x, tempRotate.y);

		// For convenience, we'll lock the cursor and make it disappear when rotating the camera.
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update() 
	{
		// Create variables exclusive to our functions here.
		float xInput = Input.GetAxis("Horizontal Right Stick");
		float zInput = Input.GetAxis("Vertical Right Stick");
		mousePosition = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

		if (Input.GetMouseButton(1) || Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
		{
			// Calculate the new coordinates for the final input.
			finalInput = mousePosition + new Vector2(xInput, zInput);

			// Calculate the rotation x and y values based on how we're clicking or pushing.
			rotate.x += finalInput.y * controlSensitivity * Time.deltaTime;
			rotate.y += finalInput.x * controlSensitivity * Time.deltaTime;

			// Make the values unable to go past a certain point.
			rotate.x = Mathf.Clamp(rotate.x, minClamp, maxClamp);

			// Convert the values we just found to a Quaternion and set it to our object.
			this.transform.rotation = Quaternion.Euler(rotate.x, rotate.y, 0.0f);
		}
	}

	void LateUpdate()
	{
		// Create variables here.
		Transform follow = followObject.transform; // Set the object to follow.
		float step = cameraSpeed * Time.deltaTime; // Move towards the target GameObject.

		// Set our object's position to this new value.
		this.transform.position = Vector3.MoveTowards(this.transform.position, follow.position, step);
	}
}
