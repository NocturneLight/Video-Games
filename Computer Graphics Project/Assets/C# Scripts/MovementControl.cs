using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour 
{

	// Create our variables here.
	private float speed = 10;
	private Rigidbody body = null;
    public bool isRun = false;
    public Animator animator;
    // Use this for initialization
    void Start() 
	{
		// Get the RigidBody values from the RigidBody component attached to 
		// the GameObject that has this script.
		body = this.GetComponent<Rigidbody>();

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
        if(Input.GetKey("up")|| Input.GetKey("down")||Input.GetKey("left")|| Input.GetKey("right"))
        {
            isRun = true;
            animator.SetBool("isRun", true);
        }
        else
        {
            isRun = false;
            animator.SetBool("isRun", false);
        }
		Vector3 moveVector = new Vector3(horizMove, 0.0f, vertiMove);	// We're using the horizontal and vertical axes to create a movement vector for us.

		// Apply force to the GameObject through RigidBody to create movement.
		body.AddForce(moveVector * speed);
	}
}
