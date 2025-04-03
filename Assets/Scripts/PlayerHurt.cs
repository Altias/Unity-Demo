using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{	
	//This function is called when you hit something else with a 2D collider
	void OnCollisionEnter2D(Collision2D collision)
	{
		//Checks if the collision was with the tag used for enemies, in this case "Bad"
		if (collision.gameObject.CompareTag("Bad")) 
		{ 
			//You can make anything happen here like taking damage or triggering a loss. For now it just prints to the debug log
			Debug.Log("Ouch");
		} 
    }
}
