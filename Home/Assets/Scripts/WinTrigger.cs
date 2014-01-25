using UnityEngine;
using System.Collections;

public class WinTrigger : MonoBehaviour
{
	public GameObject splash;
	
	public string nextLevelName;

	void OnTriggerEnter2D(Collider2D col)
	{

		// If the player hits the trigger...
		if(col.gameObject.tag == "Player")
		{
			// .. stop the camera tracking the player
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;
			
			// ... instantiate the splash where the player falls in.
			Instantiate(splash, col.transform.position, transform.rotation);
			// ... destroy the player.
			Destroy (col.gameObject);
			// ... reload the level.
			Application.LoadLevel(nextLevelName);
			
		}
		else
		{
			// Destroy the enemy.
			Destroy (col.gameObject);	
		}
	}
	
}
