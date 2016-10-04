using UnityEngine;
using System.Collections;
/*
 * Tom Slavin
 * GroundCheck script to be attached to a player. Separate hitbox below player entity, passes checks to the parent
 */
public class GroundCheck : MonoBehaviour {

    private PlayerController player;
	// Use this for initialization
	void Start ()
    {
        player = gameObject.GetComponentInParent<PlayerController>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D col) // another collider enters trigger
    {
        player.isGrounded = true;
    }

    void OnTriggerStay2D(Collider2D col) // another collider remains in the trigger at end of frame
    {
        player.isGrounded = true;
    }

    void OnTriggerExit2D(Collider2D col) // another collider leaves the trigger
    {
        player.isGrounded = false;
    }
}
