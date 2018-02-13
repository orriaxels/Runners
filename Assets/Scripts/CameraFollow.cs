using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	public Vector3 offset;
	
	void LateUpdate () 
	{
		transform.position = new Vector3(target.position.x + offset.x, offset.y, offset.z);
	}
}


