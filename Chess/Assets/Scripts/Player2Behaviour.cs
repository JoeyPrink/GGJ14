using UnityEngine;
using System.Collections;

public class Player2Behaviour : MonoBehaviour {
	
	
	
	/// <summary>
	/// 1 - The speed of the ship
	/// </summary>
	public Vector2 speed = new Vector2(50, 50);
	
	// 2 - Store the movement
	private Vector2 movement;
	
	void Update()
	{
		// 3 - Retrieve axis information
		float inputX = Input.GetAxis("Horizontal2");
		float inputY = Input.GetAxis("Vertical2");
		
		
		/*	if(Input.GetAxisRaw("Joystick 1 X axis")> 0.3|| Input.GetAxisRaw("Joystick 1 X axis") < -0.3)
		{
			inputX = Input.GetAxisRaw("Joystick 1 X axis");
		}
		
		if(Input.GetAxisRaw("Y axis")> 0.3|| Input.GetAxisRaw("Y axis") < -0.3)
		{
			 inputY = Input.GetAxisRaw("Y axis");
		}


		/*
		if(Input.GetAxisRaw("3rd axis")> 0.3|| Input.GetAxisRaw("3rd axis") < -0.3)
		{
			currentAxis = "3rd axis";
			axisInput = Input.GetAxisRaw("3rd axis");
		}
		
		if(Input.GetAxisRaw("4th axis")> 0.3|| Input.GetAxisRaw("4th axis") < -0.3)
		{
			currentAxis = "4th axis";
			axisInput = Input.GetAxisRaw("4th axis");
		}
		
		if(Input.GetAxisRaw("5th axis")> 0.3|| Input.GetAxisRaw("5th axis") < -0.3)
		{
			currentAxis = "5th axis";
			axisInput = Input.GetAxisRaw("5th axis");
		}
		
		if(Input.GetAxisRaw("6th axis")> 0.3|| Input.GetAxisRaw("6th axis") < -0.3)
		{
			currentAxis = "6th axis";
			axisInput = Input.GetAxisRaw("6th axis");
		}
		
		if(Input.GetAxisRaw("7th axis")> 0.3|| Input.GetAxisRaw("7th axis") < -0.3)
		{
			currentAxis = "7th axis";
			axisInput = Input.GetAxisRaw("7th axis");
		}
		
		if(Input.GetAxisRaw("8th axis") > 0.3|| Input.GetAxisRaw("8th axis") < -0.3)
		{
			currentAxis = "8th axis";
			axisInput = Input.GetAxisRaw("8th axis");
		}*/
		
		
		
		// 4 - Movement per direction
		movement = new Vector2(
			speed.x * inputX,
			speed.y * inputY);
		
	}

	
	void FixedUpdate()
	{
		// 5 - Move the game object
		rigidbody2D.velocity = movement;
	}
	
}
