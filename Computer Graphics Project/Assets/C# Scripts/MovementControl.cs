using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour 
{

	// Create our variables here.
	public float speed = 10;
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
		// Create variables exclusive to this function here.
		float horizMove = Input.GetAxis("Horizontal");
		float vertiMove = Input.GetAxis("Vertical");
		Vector3 moveVector = new Vector3(horizMove, 0.0f, vertiMove);	// We're using the horizontal and vertical axes to create a movement vector for us.

		
		// If pressing a key associated with movement, apply the walking animation.
		animator.SetBool("isRun", (Input.GetButton("Horizontal") || Input.GetButton("Vertical")) ? true : false);

		// Assign our object's velocity a speed vector using speed multiplied with the Horizontal and Vertical axes.
		body.velocity = new Vector3(horizMove * speed, 0.0f, vertiMove * speed);
	}
}
