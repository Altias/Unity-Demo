using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
	private Camera MainCamera;
	private Vector2 screenBounds;
	private float objectWidth;
	private float objectHeight;
	
	
    // Start is called before the first frame update
    void Start () {
		
		//The screen boundaries we want are the camera bounds since that's what we see.
		MainCamera = Camera.main; //So we take the camera object
		screenBounds = new Vector2(MainCamera.orthographicSize * MainCamera.aspect,MainCamera.orthographicSize); //And use it's x and y size as the screen bound size. You can see how the x and y are calculated respectively in this line.
		
		//Now we need the size of the player object. It should stop movement when either edge of the player box hits the edge of the bounds.
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
		
		//Uncomment to see the boundary in the debug log
		//Debug.Log(screenBounds); 
        
    }

    // Update is called once per frame
    void FixedUpdate(){
		
		//Here we are taking the player position and restricting them via Math.clamp. Then applying this restriction to the actual position again now that it's been calculated.
        Vector2 viewPos = GetComponent<Rigidbody2D>().position; 
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
		
		GetComponent<Rigidbody2D>().position = new Vector2(viewPos.x,viewPos.y);
 
    }
}
