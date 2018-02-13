using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemy : MonoBehaviour {

	private bool moveRight;
	public float speed;
	private float y;

	// Use this for initialization
	void Start () 
	{
		moveRight = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 pos = transform.position;
		Quaternion enemyRotation = transform.rotation;
		
		enemyRotation = Quaternion.Euler(0, y, 0);
		if(moveRight)
		{
			y = 180;
			pos.x += Time.deltaTime * speed;
		}
		else
		{
			y = 0;
			pos.x -= Time.deltaTime * speed;
		}
		transform.rotation = enemyRotation;
		transform.position = pos;
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.name == "TriggerLeft")
		{			
			moveRight = true;
		}
		if(coll.gameObject.name == "TriggerRight")
		{			
			moveRight = false;
		}
	}
}
