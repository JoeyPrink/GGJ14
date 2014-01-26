using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
		[HideInInspector]
		public bool
				facingRight = true;			// For determining which way the player is currently facing.
		[HideInInspector]
		public bool
				jump = false;				// Condition for whether the player should jump.

		public float moveForce = 365f;			// Amount of force added to move the player left and right.
		public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
		public AudioClip[] jumpClips;			// Array of clips for when the player jumps.
		public float jumpForce = 1000f;			// Amount of force added when the player jumps.

		private Transform groundCheck;			// A position marking where to check if the player is grounded.
		private bool grounded = false;			// Whether or not the player is grounded.
		private Animator anim;			        // Reference to the player's animator component.

		public Vector2 lookDirection;
		public long lastLookUpdate;
		private LineRenderer lineRenderer;

		// The index of the player for this controller (1 based)
		public int playerNumber;
	
		void Awake ()
		{
				// Setting up references.
				groundCheck = transform.Find ("groundCheck");
				anim = GetComponent<Animator> ();
				lineRenderer = GetComponent<LineRenderer> ();
		}

		void Start ()
		{
				lookDirection = new Vector2 (1, 0);
		}
	
		void Update ()
		{
				// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
				grounded = Physics2D.Linecast (transform.position, groundCheck.position, 
		                         1 << LayerMask.NameToLayer ("Ground"));  

				// If the jump button is pressed and the player is grounded then the player should jump.
				if (Input.GetButtonDown ("Jump" + playerNumber) && grounded)
						jump = true;
		}

		void FixedUpdate ()
		{
				// Cache the horizontal input.
				float h = Input.GetAxis ("Horizontal" + playerNumber);
		
				// The Speed animator parameter is set to the absolute value of the horizontal input.
				anim.SetFloat ("Speed", Mathf.Abs (h));
		
				// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
				if (h * rigidbody2D.velocity.x < maxSpeed)
			// ... add a force to the player.
						rigidbody2D.AddForce (Vector2.right * h * moveForce);
		
				// If the player's horizontal velocity is greater than the maxSpeed...
				if (Mathf.Abs (rigidbody2D.velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
						rigidbody2D.velocity = new Vector2 (Mathf.Sign (rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
		
				// If the input is moving the player right and the player is facing left...
				if (h > 0 && !facingRight)
			// ... flip the player.
						Flip ();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if (h < 0 && facingRight)
			// ... flip the player.
						Flip ();
		
				// If the player should jump...
				if (jump) {
						// Set the Jump animator trigger parameter.
						anim.SetTrigger ("Jump");
			
						// Play a random jump audio clip.
						int i = Random.Range (0, jumpClips.Length);
						if (i > 0) {
								AudioSource.PlayClipAtPoint (jumpClips [i], transform.position);
						}
						// Add a vertical force to the player.
						rigidbody2D.AddForce (new Vector2 (0f, jumpForce));
			
						// Make sure the player can't jump again until the jump conditions from Update are satisfied.
						jump = false;
				}
				float inputLookY = Input.GetAxis ("LookVertical" + playerNumber);
				float inputLookX = Input.GetAxis ("LookHorizontal" + playerNumber);

				float inputAngle = Mathf.Atan2 (inputLookY, inputLookX) + Mathf.PI / 2;
				lookDirection.y = Mathf.Sin (inputAngle);
				lookDirection.x = Mathf.Cos (inputAngle);

				lineRenderer.enabled = (inputLookX != 0 || inputLookY != 0);
				if (lineRenderer.enabled) {
						lineRenderer.SetPosition (0, transform.position);
						lineRenderer.SetPosition (1, new Vector2 (transform.position.x, transform.position.y) + lookDirection * 100);
		
						RaycastHit2D[] hit = Physics2D.RaycastAll (transform.position, lookDirection, 100, 1 << LayerMask.NameToLayer("Player"));
			print (hit.Length);
						if (hit.Length > 1) {
								if (hit [1].collider != null) {
										if (hit [1].collider.gameObject != null 
					    					&& hit [1].collider.gameObject != this
					    					&& hit [1].collider.gameObject.rigidbody2D != null
					                        && hit [1].collider.gameObject.tag == "Player") {
												Vector2 pos = new Vector2 (transform.position.x, transform.position.y);
												float squaredDistance = (hit [1].point - pos).sqrMagnitude; 
												hit [1].collider.gameObject.rigidbody2D.AddForce (lookDirection * (100 - squaredDistance));
										}
								}
						}
				}
		}
	
		void Flip ()
		{
				// Switch the way the player is labelled as facing.
				facingRight = !facingRight;
		
				// Multiply the player's x local scale by -1.
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;

				// Transform the look direction
				lookDirection.x = -lookDirection.x;
		}
}

