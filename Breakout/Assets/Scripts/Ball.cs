using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    /**
    Ball functionality class
    */

    // Public variables for initial velocity and velocity when hit
    public float ballInitialVelocity;
    public float ballHitVelocityY;
    public float ballHitVelocityX;

    // Rigidbody component and boolean to make sure ball is in play
    private Rigidbody rb;
    private bool ballIsInPlay;
    
    // Variables to check incoming ball direction
    private Vector3 ballDirectionLeft;
    private Vector3 ballDirectionRight;

    // Variables that return if incoming ball direction is true or false
    private bool incomingLeft = false;
    private bool incomingRight = false;

    // Use this for initialization
    void Start () {

        // Initialise rigidbody component
        rb = GetComponent<Rigidbody>();
}
	
	// Update is called once per frame
	void FixedUpdate () {

        // If user presses space, then ball fires
        if (Input.GetKeyDown("space") && ballIsInPlay == false)
        {

            // Remove the children from the parent
            transform.parent = null;
            // The ball is now in play
            ballIsInPlay = true;
            // Make sure that the ball on release is not kinematic
            rb.isKinematic = false;
            // Force is added so it can go into play
            rb.AddForce(new Vector3(0, ballInitialVelocity, 0));
        }

	}

    void OnCollisionEnter(Collision other)
    {
        // If the ball hits the player and incoming left is false
        if(other.gameObject.tag == "Player" && incomingLeft == false)
        {
            // Call method
            BallIncomingLeft();   
        }
        // Else if the ball is incoming right towards the player
        else if(other.gameObject.tag == "Player" && incomingRight == false)
        {
            // Call method
            BallIncomingRight();
        }
    }

    void BallIncomingLeft()
    {
        // Incoming left is true
        incomingLeft = true;
        // Get the direction of the ball by getting its local direction
        ballDirectionLeft = transform.InverseTransformDirection(rb.velocity);
        if(incomingLeft == true)
        {
            // Add an additional force that hits the ball away
            rb.AddForce(new Vector3(ballHitVelocityX, ballHitVelocityY, 0));
            Debug.Log(ballDirectionLeft + "Ball incoming left");
        }
        
    }

    void BallIncomingRight()
    {
        // Incoming right is true
        incomingRight = true;
        // Get the direction of the ball by getting its local direction
        ballDirectionRight = transform.InverseTransformDirection(rb.velocity);
        if (incomingRight == true)
        {
            // Add an additional force that hits the ball away
            rb.AddForce(new Vector3(ballHitVelocityX, ballHitVelocityY, 0));
            Debug.Log(ballDirectionRight + "ball incoming right");
        }
        
    }


}
