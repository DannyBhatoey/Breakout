using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    /**
    This class is the player functionality
    */

    // Setup a rigidbody component
    private Rigidbody rb;
    private Boundary boundary;

    // Public variables for speed and boundary values
    public float playerSpeed;
    public float xMin, xMax, yMin, yMax;

    void Start()
    {
        // Initialise rigidbody and game manager component
        rb = GetComponent<Rigidbody>();
    }


	// Where the physics calculations are done
	void FixedUpdate ()
    {
        // Put the player input into a float variable
        float moveHorizontal =  Input.GetAxis("Horizontal");

        // Movement variable contains the player input
        Vector3 movement = new Vector3(moveHorizontal, 0, 0);

        // Create boundary for the player by creating a vector 3
        rb.position = new Vector3(
            // Clamp the x and y values with variables for the values
            Mathf.Clamp(rb.position.x, xMin, xMax),
            Mathf.Clamp(rb.position.y, yMin, yMax),
            0.0f
            );
        // The velocity of the player is equal to movement * playerSpeed
        rb.velocity = movement * playerSpeed;


	}

}
