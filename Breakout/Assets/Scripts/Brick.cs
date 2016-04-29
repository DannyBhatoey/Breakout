using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {


    /**
    This class models a brick and if a ball has been hit by it
    */
    public GameObject brickParticle;

    void OnCollisionEnter(Collision other)
    {
        // If the object collided has the tag Ball 
        if (other.gameObject.tag == "Ball")
        {
            // Instantiate brick particle at the position of the brick
            Instantiate(brickParticle, transform.position, Quaternion.identity);
            // Destroy the brick
            Destroy(gameObject);
        }
    }
}
