using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : MonoBehaviour
{
	private Rigidbody2D rb;
	
	void OnEnable()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2 (5f,0f); //When enabled, the orange will fly to the right.
		
		//Can you adjust this code so the orange goes left when the player is facing the other way?
	}
	
    void OnBecameInvisible() 
	{
		 this.gameObject.SetActive(false); //When the orange crosses off screen it will be disabled again and effectively returned to the pool.
        
    }
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		//Checks if the collision was with the tag used for enemies, in this case "Bad"
		if (collision.gameObject.CompareTag("Bad")) 
		{ 
			//Similar to the player hurt script, this just prints to the console and disables the projectile. Expand on this function as you see fit.
			Debug.Log("Splat!");
			this.gameObject.SetActive(false);
		} 
		
		else if (collision.gameObject.CompareTag("Player"))
		{
			Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>()); //Ignore collision with the player. We don't need to hurt ourselves.
		}
		
		else
		{
			//Lets get rid of it if it hits a platform too.
			this.gameObject.SetActive(false);
		}
    }
}
