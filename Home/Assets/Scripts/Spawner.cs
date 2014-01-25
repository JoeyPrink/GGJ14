using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

	GameObject go = (GameObject)Instantiate(Resources.Load("Stein"));

	void Start ()
	{
		InvokeRepeating("Spawn", 16f, 6f);
	}


	void Spawn ()
	{
		go = (GameObject)Instantiate(Resources.Load("Stein"));
		Instantiate(go, transform.position, transform.rotation);

	}
}
