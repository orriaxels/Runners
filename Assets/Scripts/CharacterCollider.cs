using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D col)
	{     
		if(col.gameObject.name == "Hovering_platform")
		{
			transform.parent = col.transform;
		}
	}
 
	void OnTriggerExit2D(Collider2D col)
	{
		if(col.gameObject.name == "Hovering_platform")
		{
			transform.parent = null; 
		}
	} 
}
