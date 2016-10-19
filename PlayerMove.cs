using UnityEngine;
using System.Collections;
// attached to Player
// Moves Player. Also links Player to Boomerang
public class PlayerMove : MonoBehaviour 
{
	// Determines magnitude of jump
	public float jumpForce;
	// Determines magnitude of movement
	public float moveForce;
	// Declares a Boomerang object to link
	//it to Player; we will also use its attributes
	public Boomerang boom;
	// Rigidbody 2D to control self's physics
	Rigidbody2D rb;

	void Start()
	{
		// Initializes rb to Player's Rigidbody2D 
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () 
	{
		// If the Boomerang is not traveling, then moving
		// the Player moves the Boomerang
		if (!boom.isGoing)
			// y value of position is raised slightly so
			// it is not touching Platform. Otherwise there will
			// be collision issues
		{
			boom.transform.position = new Vector3 (transform.position.x + 2,
				transform.position.y + .1f, 0f);
		}
		// Jumps if Space is pressed
		if (Input.GetKeyDown (KeyCode.Space) && CanJump.jumpState) 
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		}
		// Moves left with Keycode A
		if (Input.GetKey (KeyCode.A))
			rb.AddForce (Vector2.left * moveForce);
		// Moves right with Keycode D	
		if (Input.GetKey (KeyCode.D))
			rb.AddForce (Vector2.right * moveForce);
	}
}
