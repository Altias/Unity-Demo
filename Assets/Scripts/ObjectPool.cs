using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	public static ObjectPool SharedInstance;
	public List<GameObject> pooledOranges;
	public GameObject orangePool;
	public int amountToPoolOranges;
	
	//Object pooling is a common way to optimize code. It takes less power than creating and destroying objects everytime you need them. It essentially creates a list filled with a set number of clones of the object that are inactive and cycles them in as they are needed.
	
	
    // Start is called before the first frame update
    void Start()
    {
	    pooledOranges = new List<GameObject>(); //The pool is managed via a list. So we create a list of Orange objects.
	    GameObject tmpOrange;
	    for(int i = 0; i < amountToPoolOranges; i++)
	    {
	        tmpOrange = Instantiate(orangePool);
	        tmpOrange.SetActive(false);
	        pooledOranges.Add(tmpOrange); //This loop adds the amount we want to pool to the list. You can change this number in the editor itself rather than in the script with my code, but hardcoding it in if you choose to is an option.
	    }
    }
	
	void Awake()
	{
	    SharedInstance = this; //There is only one instance of the object pool that everything can reference.
	}
	
	public GameObject GetPooledOranges()
	{
	    for(int i = 0; i < amountToPoolOranges; i++)
	    {
	        if(!pooledOranges[i].activeInHierarchy)
	        {
	            return pooledOranges[i]; //Get and return a currently inactive orange.
	        }
	    }
	    return null;
	}
}
