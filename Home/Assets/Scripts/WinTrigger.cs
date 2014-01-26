using UnityEngine;
using System.Collections;

public class WinTrigger : MonoBehaviour
{
	public GameObject splash;
	
	public string nextLevelName;
	
	public bool firstIsLanded = false;
	
	void OnTriggerEnter2D(Collider2D col)
	{
		
		// If the player hits the trigger...
		if(col.gameObject.name == "Player 1" || col.gameObject.name == "Player 2")
		{
			
			
			// ... instantiate the splash where the player falls in.
			Instantiate(splash, col.transform.position, transform.rotation);
			// ... destroy the player.
			Destroy (col.gameObject);
			
			
			if (firstIsLanded == false) {
				firstIsLanded = true;
				
			} else {
				
				// .. stop the camera tracking the player
				GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;
				
				// ... reload the level.
				Application.LoadLevel(nextLevelName);
				
			}}
		else
		{
			// Destroy the enemy.
			Destroy (col.gameObject);	
		}
	}
	
}
