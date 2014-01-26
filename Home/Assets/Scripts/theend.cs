using UnityEngine;
using System.Collections;

public class theend : MonoBehaviour {

	private Vector2 velocity;
	public GameObject ship;

	public float waitBeforeStart;
	private float startTime;

	public string nextLevelName;

	// Use this for initialization
	void Start () {
		waitBeforeStart = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {

			velocity.y *= 1.05f;
			Vector3 change = new Vector3 (velocity.x, velocity.y, 0.0f);
			this.transform.position += change;	


		if (transform.position.y > 20.0f) {
			Application.LoadLevel(nextLevelName);
		}

	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Player") {
			velocity = new Vector2(0.0f, 0.03f);
			startTime = Time.time;
			GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
			foreach(GameObject g in players)
			{
				Destroy(g);
			}

			GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
			Destroy (cam.GetComponent("CameraFollow"));
		}
	}
	
}
