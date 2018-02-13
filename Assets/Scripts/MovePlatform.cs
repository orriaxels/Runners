using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour {

	private bool moveUp;
	public float speed;

	// Use this for initialization
	void Start () 
	{
		moveUp = true;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 pos = transform.position;
		if(moveUp)
		{
			pos.y += Time.deltaTime * speed;
		}
		else
		{
			pos.y -= Time.deltaTime * speed;
		}
		transform.position = pos;
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.name == "TriggerUp")
		{			
			moveUp = false;
		}
		if(coll.gameObject.name == "TriggerDown")
		{			
			moveUp = true;
		}
	}
}
