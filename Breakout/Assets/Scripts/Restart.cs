using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

    // Create a gui component
	void OnGUI()
    {
        // If the button created is pressed
        if (GUI.Button(new Rect(10, 800, 200, 40), "Restart"))
        {
            // Reload the level
            Application.LoadLevel(Application.loadedLevel);

        }
            
    }
}
