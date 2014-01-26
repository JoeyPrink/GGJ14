using UnityEngine;
using System.Collections;

public class Start : MonoBehaviour
{

	public string nextLevelName;
	void Update()
	{
		
		if(Input.anyKey) {
				// ... reload the level.
				Application.LoadLevel(nextLevelName);
		}	
	}
	
}
