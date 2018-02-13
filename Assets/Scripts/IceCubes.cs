using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCubes : MonoBehaviour {

	public GameObject startPoint;
	public GameObject endPoint;
	public float speed = 1.0f;
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 fallingCube = transform.position;

		fallingCube.y -= Time.deltaTime * speed;

		transform.position = fallingCube;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject == endPoint.gameObject)
		{
			transform.position = startPoint.gameObject.transform.position;
		}
	}
}
