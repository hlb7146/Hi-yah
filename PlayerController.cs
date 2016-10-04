using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    //Variables for walking speed and jump height, easily modifiable
    public float accel; //how fast the player gets up to speed, set to at least a few times the max speed
    public float maxSpeed; // how fast do we want the player to even out at?
    public float jumpForce; // how much force goes into a player jump

    public bool isGrounded; // bool to track if the player is on the ground and able to jump
    private Rigidbody2D rb; //we'll use this to access the player's associated Rigidbody
    private BoxCollider2D bc;
	// Use this for initialization
	void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody2D>(); //Link rb to the player's Rigidbody2D component
        bc = gameObject.GetComponent<BoxCollider2D>(); // link bc to the player's BoxCollider2D component
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //grab player's horizontal input

            rb.AddForce((Vector2.right * accel) * moveHorizontal); //apply horizontal movement only, worth noting with this kind of movement you need either drag or coding to slow down properly

        if (rb.velocity.x > maxSpeed) // if player starts going too fast cap their speed
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        else if (rb.velocity.x < (-maxSpeed))
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);

        // stop immediately if no input? can be avoided by adding linear drag through Unity
        //if (moveHorizontal == 0)
        
	}

    void Update ()
    {
        if (Input.GetButtonDown("Jump") && isGrounded) // if player presses jump and is on the ground
        {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce); // apply a bunch of velocity like instantly straight up
        }
    }


}