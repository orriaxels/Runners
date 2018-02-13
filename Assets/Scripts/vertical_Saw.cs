using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vertical_Saw : MonoBehaviour {
	
	public bool up;
	public float rotationSpeed = 180;
	public float speed = 1f;
	
	void Update () 
	{
		Vector3 sawPos = transform.position;
		Quaternion sawRotation = transform.rotation;
		float z = sawRotation.eulerAngles.z;
		z -= rotationSpeed * Time.deltaTime;
		sawRotation = Quaternion.Euler(0, 0, z);

		if(up)
		{
			sawPos.y += Time.deltaTime * speed;
		}
		else
		{
			sawPos.y -= Time.deltaTime * speed;
		}

		transform.position = sawPos;
		transform.rotation = sawRotation;
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "sawUp")
		{
			up = false;
		}
		else if(col.tag == "sawDown")
		{
			up = true;
		}
	}
}
