using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//There are multiple ways to do movement in Unity and you might prefer another on a specific project. In this case I make use of the physics engine and use the RigidBody2D velocity. Plenty of examples use other things like the Transform.Position value instead. If you don't like the feel of something feel free to try out those examples online and play around. Using transform can require a little more manual work when it comes to physics but can give you finer control to make it feel less clumsy.

public class PlayerMove : MonoBehaviour
{
	private float speed;
	private float jumpPower;
	private float currentSpeed;
	
	//These are for ground check
	public ContactFilter2D cf;
    // Start is called before the first frame update
    void Start()
    {
        speed = 4f; //Setting this here allows easy fine tuning of the movement.
		jumpPower = 8f;
		currentSpeed = 0f;
		
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		//This takes in the player velocity vector from the RigidBody component and applies the current speed to its x value.
		GetComponent<Rigidbody2D>().velocity = new Vector2(currentSpeed,GetComponent<Rigidbody2D>().velocity.y);
		
		//Flip the sprite when going backwards.
		if (currentSpeed < 0)
		{
			GetComponent<SpriteRenderer>().flipX = true;
		}
		else if (currentSpeed > 0)
		{
			GetComponent<SpriteRenderer>().flipX = false;
		}
		
		//Uncomment this to see the velocity in the debug log
		//Debug.Log(GetComponent<Rigidbody2D>().velocity);
		
		//Basic side to side movement using basic WASD controls
		if(Input.GetKey(KeyCode.D))
		{
			currentSpeed = speed;
		}
		
		else if(Input.GetKey(KeyCode.A))
		{
			currentSpeed = -speed;
		}
		
		else
		{
			currentSpeed = 0;
		}
		
		//Basic jump ability
		
		//To include jumping we need to check if the player is on the ground. Otherwise they can jump forever. See the isGrounded function to see how that's checked.
		//This is a basic collision based jump check. Raycast is more complex but usually more accurate with uneven ground shapes. Just something to keep in mind.
		
		//Uncomment this to see in the debug log whether the player is on the ground or 
		//Debug.Log(isGrounded());
		
		if (Input.GetKey(KeyCode.Space) && isGrounded())
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(currentSpeed,jumpPower);
		}
		
		
	}
	
	bool isGrounded()
	{
		//To check if it's grounded we will check if it's touching another collider with conditions filtered by Contact Fitler cf. This is set in the main scene editior.
		return(GetComponent<Rigidbody2D>().IsTouching(cf));
		
	}
	
}
