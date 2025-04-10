using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootOrange : MonoBehaviour
{
	public Orange orangeBase;
	private float cooldown;
	private float x = 0f;
	private float y = 0f;
	public Rigidbody2D player;
	public BoxCollider2D playerBox;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.F))
		{
			Spawn();
		}
    }
	
	void FixedUpdate()
	{
		if (cooldown > 0)
		{
			cooldown--;
		}
		
	}
	
	void Spawn()
	{
		if (cooldown == 0)
		{
			GameObject orange = ObjectPool.SharedInstance.GetPooledOranges(); //This is how to reference the shared instance. By calling GetPooledOranges we take the next currently inactive one from the list.
			
			if (orange != null)
			{
				x = player.position.x;
				y = player.position.y;
				Vector2 spawnSpot = new Vector2(x + 1.1f,y); //I added the float of 1.1 so it spawns in front of the player rather than on top. Feel free to adjust as you want.
				orange.transform.position = spawnSpot;
				cooldown = 150;
				orange.SetActive(true); //Position the orange on the player so it shoots from their position. Then enable it.
			}
		}
		
	}
}
