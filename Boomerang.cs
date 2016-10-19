using UnityEngine;
using System.Collections;
// Attached to Boomerang
// Determines when Boomerang can move, how and when it comes back
public class Boomerang : MonoBehaviour 
{
	// Declares a Rigidbody2D that can be used throughout the script
	// used in PlayerMove class
	public Rigidbody2D rb;
	// speed is a coefficient for the object's velocity (see FixedUpdate())
	public float speed;
	// Control Boolean to determine if Boomerang is traveling
	public bool isGoing;
	// publicVector2 to store velocity
	// so other scripts can reference it
	public Vector2 velocity;
	// Will eventually use this for position
	Vector2 pos;
	// Sprite Renderer to turn invisible when not firing
	SpriteRenderer sr;
	// BoxCollider2D to deactivate collisions when not firing
	BoxCollider2D bc;
	// Use this for initialization
	void Start () 
	{
		// intitializes sr
		// because it has not been fired, it is invisible
		sr = GetComponent<SpriteRenderer> ();
		sr.enabled = false;
		// initializes rb
		rb = GetComponent<Rigidbody2D> ();
		// freezes rotation
		rb.freezeRotation = true;
		// initializes and disables bc
		bc = GetComponent<BoxCollider2D> ();
		bc.enabled = false;
	}
	
	// FixedUpdate() is better than Update() when dealing with Rigidbody
	void FixedUpdate ()
	{
		// assigns value so other scripts can reference
		velocity = rb.velocity;
		// This section allows the object to leave and return to its origin
		// It makes itself visible and collidable
		if (Input.GetMouseButtonDown(0) && !isGoing) 
		{
			sr.enabled = true;
			bc.enabled = true;
			rb.velocity = Vector2.right * speed;
			isGoing = true;
			// stores position in pos
			pos = transform.position;
		}
		// When Boomerang reaches its farthest point
		// it turns around
		if (transform.position.x >= 10 + pos.x)
			rb.velocity = Vector2.left * speed;
		// if Boomerang goes past a certain point
		if (transform.position.x < pos.x - 10) 
		{
			isGoing = false;
			sr.enabled = false;
			bc.enabled = false;
		}

	}

	// if Boomerang hits a Boundary or Platform while moving, then
	// it will turn around
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (isGoing) 
		{
			rb.velocity = Vector2.left * speed;
		}
	}
}
