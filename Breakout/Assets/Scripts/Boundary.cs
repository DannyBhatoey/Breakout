using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {

    // Objects for player and player death particle
    public GameObject playerParticle;
    public GameObject player;

    void OnCollisionEnter(Collision other)
    {
        // Where there is a collision, if the game object is tagged Ball
        if(other.gameObject.tag == "Ball")
        {
            // Instantiate player death particle at the player position
            Instantiate(playerParticle, player.transform.position, Quaternion.identity);
            // Destroy the game object that just entered the boundary
            Destroy(other.gameObject);
            // Destroy the player
            Destroy(player.gameObject);
            // Start the coroutine method
            StartCoroutine(Dead());
        }

    }

    // Used as we are using the WaitForSeconds method, tells script to wait
    IEnumerator Dead()
    {
        //Debug.Log("lost");
        yield return new WaitForSeconds(1);
        //Debug.Log("spawn");

        // Reload the level
        Application.LoadLevel(Application.loadedLevel);
    }
}
