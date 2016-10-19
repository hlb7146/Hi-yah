using UnityEngine;
using System.Collections;
// attached to Enemy
// Initially moves Enemy left. If it hits a Boundary,
// Enemy switches direction
public class EnemyMove : MonoBehaviour 
{
	// Public RigidBody 2D declared to access
	// velocity
	public Rigidbody2D rb;
	// Determines if Enemy hit Boundary
	public bool hitBoundary = false;
	// Use this for initialization
	void Start () 
	{
		// initializes rb
		rb = GetComponent<Rigidbody2D> ();
	}
	// Toggles hitBoundary to determine direction of enemy
	// Ex. Enemy will move left when false, will move right when
	// true, then left when false again. See Update()
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag("Boundary"))
		{
			if (hitBoundary == false) 
			{
				hitBoundary = true;
			} 
			else if (hitBoundary == true) 
			{
				hitBoundary = false;
			}
		}	
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		// Enemy will move left at first;
		// it will change direction if it hits a boundary
		if (!hitBoundary) 
		{
			rb.velocity = new Vector2 (-2, 0);
		} 
		else if (hitBoundary) 
		{
			rb.velocity = new Vector2 (2, 0);
		}
	}
		
}
