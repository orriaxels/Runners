using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontal_Saw : MonoBehaviour {
	public bool left;
	public bool stationary;

	public float rotationSpeed = 180;
	public float speed = 1;
	
	void Update () 
	{
		Vector3 sawPos = transform.position;
		Quaternion sawRotation = transform.rotation;
		float z = sawRotation.eulerAngles.z;
		z -= rotationSpeed * Time.deltaTime;
		sawRotation = Quaternion.Euler(0, 0, z);

		if(!stationary)
		{
			if(left)
			{
				sawPos.x -= Time.deltaTime * speed;
			}
			else
			{
				sawPos.x += Time.deltaTime * speed;
			}
		}

		transform.position = sawPos;
		transform.rotation = sawRotation;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "sawLeft")
		{
			left = false;
		}
		else if(col.tag == "sawRight")
		{
			left = true;
		}
	}
}
