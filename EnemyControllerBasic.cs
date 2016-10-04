using UnityEngine;
using System.Collections;
/*
 * Tom Slavin
 * Code for a basic enemy: it walks until it hits a wall, then changes direction
 */
public class EnemyControllerBasic : MonoBehaviour {

    public float speed;

    public bool startRight; // bool for whether it starts going left or right

    private bool checkFlip = true; // this bool is used to make sure the enemy can't rapidly keep switching until it humps one wall
    private bool facingRight; // not entirely relevant right this instant, but can be used if we need to check enemy's facing direction(animations?)
    private Rigidbody2D rb; // holds a reference we'll use to access the rigidbody
    private CircleCollider2D col; // holds reference to access main collider

    
	// Use this for initialization
	void Start ()
    {
        if (startRight) // Get whether it's going right at the start and set starting direction according
            facingRight = true;
        else
        {
            facingRight = false;
            speed *= -1;
        }
        rb = GetComponent<Rigidbody2D>(); // link rigidbody for manipulation
        col = GetComponent<CircleCollider2D>(); // link circle collider to be used
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
       // if(col.IsTouchingLayers(LayerMask.NameToLayer("Wall"))) // check if a wall is hit

            rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D col2)
    {
        if (col2.gameObject.tag.Equals("boundary") && checkFlip) //if it's good to flip, flip it
        {
                facingRight = !facingRight; // Reverse direction
                speed = speed * -1;
            checkFlip = false; // don't let it flip again until it's away from wall
        }
        if (col2.gameObject.tag.Equals("Player")) // if it hits a player disable the player, essentially kill it for now
            col2.gameObject.SetActive(false);
    }

    void OnTriggerExit2D(Collider2D col2) // once it gets away from the wall let it be flippable again
    {
        if (col2.gameObject.tag.Equals("boundary") && !checkFlip)
            checkFlip = true;
    }
}
