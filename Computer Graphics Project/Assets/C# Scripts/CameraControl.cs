using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour 
{

	// Create our variables here.
	public GameObject playerObject; // Allows us to attach a GameObject to the script in the Unity Editor.
	private Vector3 offset;
	private float cameraSpeed = 10.0f;

	// Use this for initialization
	void Start() 
	{
		// Get the offset coordinates.
		offset = this.transform.position - playerObject.transform.position;
	}
	
	// Update is called once per frame
	void Update() 
	{
		// While right-click is being held...
		if (Input.GetMouseButton(1))
		{
			// Calculate a value for rotation and store it in the offset variable.
			offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * cameraSpeed, Vector3.up) * offset;

			// Offset the position to prevent the camera from rotating with the GameObject
			// along undesirable axes.
			this.transform.position = playerObject.transform.position + offset;
		}

		// Rotate the transform such that the forward vector points at worldPosition.
		this.transform.LookAt(playerObject.transform.position);
	}
}
