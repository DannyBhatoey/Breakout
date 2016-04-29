using UnityEngine;
using System.Collections;

public class TimedDestroy : MonoBehaviour {

    /**
    This class clears up the particle clones
    */

    // Destroy after 1 second
    public float destroyAfterTime = 1f;

	
	void Start () {

        // Destroy the game object
        Destroy(gameObject, destroyAfterTime);
	}
	
}
