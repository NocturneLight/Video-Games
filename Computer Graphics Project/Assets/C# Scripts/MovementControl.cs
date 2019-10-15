using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour 
{
	// Create our variables here.
    private const float jumpMultip = 4.5f;
    private int jumpCount = 0;
	public int jumpLimit = 2;
	public float speed = 5.0f;
	bool ground = false;
	private Rigidbody body = null;
    public Animator animator = null;
    
	// Use this for initialization
    void Start() 
	{
		// Get the RigidBody values from the RigidBody component attached to 
		// the GameObject that has this script.
		body = this.GetComponent<Rigidbody>();

		// Get the Animator values from the Animator component attached to 
		// the GameObject that has this script.
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update() 
	{

	}

	// FixedUpdate() is called just before performing any Physics calculations.
    // This is where Physics code will go.
	void FixedUpdate()
	{
		// Create variables here.
		Transform cameraTransform = Camera.main.transform;
		Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
		Vector3 forwardCam = cameraTransform.forward.normalized;
		Vector3 rightCam = cameraTransform.right.normalized;

		// Set the y value of forwardCam and rightCam to 0 to prevent side effects.
		forwardCam.y = 0.0f;
		rightCam.y = 0.0f;

		// If a movement button was pressed, set the corresponding animation in accordance
		// with the isRun variable.
		animator.SetBool("isRun", (Input.GetButton("Horizontal") || Input.GetButton("Vertical")) ? true : false);

		// See if the requirements for jumping have been met.
		DoJump();

		// Apply the necessary rotation.
		doRotate();

		// Apply the movement to our GameObject.
		body.transform.position += (forwardCam * moveVector.z + rightCam * moveVector.x) * speed * Time.deltaTime;
	}

	// A function called upon colliding with an object.
	void OnCollisionStay(Collision collision)
	{
		// If the object we collided with is an object with the tag "Ground"...
		if (collision.gameObject.tag == "Ground")
		{
			// Set ground to true.
			ground = true;
		}
	}

	// Create our other functions here.
	void DoJump()
	{
		// If the user presses the jump button...
		if (Input.GetButtonDown("Jump") && ground && jumpCount < jumpLimit)
		{
			// Apply the jump as an impulse force.
			body.AddForce(Vector3.up * body.mass * jumpMultip, ForceMode.Impulse);

			// Increment jumpCount by 1 jump because we jumped.
			jumpCount++;

			// Set ground to false because we are not grounded when pressing jump.
			ground = false;
		}

		// If the model hits the jump limit...
		if (jumpCount >= jumpLimit)
		{
			// Reset the jump count.
			jumpCount = 0;
		}
	}

	void doRotate()
	{
		// Create variables here.
		Quaternion camRote = Camera.main.transform.parent.rotation;

		// Set values x and z of camRote to 0 so we rotate along the y axis.
		camRote.x = 0.0f;
		camRote.z = 0.0f;

		// Apply the rotation.
		//body.transform.rotation = camRote;

		if (Input.GetKey("w") || Input.GetKey("up"))
		{
			// Transition between rotation values and end up facing away from the camera.
			body.transform.rotation = Quaternion.RotateTowards(body.transform.rotation, camRote, 8.0f);
			
		}
		else if (Input.GetKey("s") || Input.GetKey("down"))
		{
			// Get the forward vector of the camera's parent.
			Vector3 temp = -Camera.main.transform.parent.forward;

			// Set y to 0 because we don't want the GameObject to rotate around y.
			temp.y = 0.0f;

			// Transition the rotation and face towards the camera.
			body.transform.rotation = Quaternion.RotateTowards(body.transform.rotation, Quaternion.LookRotation(temp, Camera.main.transform.up), 8.0f);
		}	
	}
}
