using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;
// Attached to Player
public class GameOver : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	// Detects a collision with Circle component because it has the collision component
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag ("Boomerang")) 
		{
			EditorSceneManager.LoadSceneAsync (0);
			print ("Game over");
		}
		if (coll.gameObject.CompareTag("Enemy"))
		{
			EditorSceneManager.LoadSceneAsync (0);
			print ("Game over");
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
