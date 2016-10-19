using UnityEngine;
using System.Collections;
// attached to Player
// determines whether Player can jump
public class CanJump : MonoBehaviour 
{
	// bool to store result of test
	public static bool jumpState;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		jumpState = true;
	}

/*	void OnTriggerStay2D(Collider2D other)
	{
		jumpState = true;
	}
*/	void OnTriggerExit2D(Collider2D other)
	{
		jumpState = false;
	}

}
