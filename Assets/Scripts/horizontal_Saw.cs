using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontal_Saw : MonoBehaviour {
	public bool left;
	public float rotationSpeed = 180;
	
	void Start () 
	{	
	}
	
	void Update () 
	{
		Vector3 sawPos = transform.position;
		Quaternion sawRotation = transform.rotation;
		float z = sawRotation.eulerAngles.z;
		z -= rotationSpeed * Time.deltaTime;
		sawRotation = Quaternion.Euler(0, 0, z);

		if(left)
		{
			sawPos.x -= Time.deltaTime;
		}
		else
		{
			sawPos.x += Time.deltaTime;
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
