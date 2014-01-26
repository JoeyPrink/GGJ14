using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

	Object go;

	void Start ()
	{
		go = Resources.Load("Stein");
		InvokeRepeating("Spawn", 10f, 6f);
	}


	void Spawn ()
	{
		Instantiate((GameObject)go, transform.position, transform.rotation);
	}
}
