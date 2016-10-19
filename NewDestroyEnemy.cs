using UnityEngine;
using System.Collections;
// attached to Boomerang
public class NewDestroyEnemy : MonoBehaviour {
	// Boomerang object declared to access velocity of parent
	Boomerang boom;
	// Rigidbody2D created to access velocity of self
	Rigidbody2D rb;

	void Start()
	{
		// Assigns rb to Rigidbody2D of Boomerang
		rb = GetComponent<Rigidbody2D> ();
		boom = GetComponent<Boomerang> ();
	}
	// Detects 2D collisions, verifies the collision
	// is with an Enemy object, destroys enemy
	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.CompareTag ("Enemy")) 
		{
			Destroy (coll.gameObject);
			// Keeps Boomerang moving after collision
			rb.velocity = boom.velocity;

		}
	}
}