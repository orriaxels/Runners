using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCubePlatform : MonoBehaviour {

	public bool up;
	public bool left;
	public float speed = 1.0f;

	// Update is called once per frame
	void Update () {
		Vector3 floatyAnim = transform.position;
		if(up)
		{
			floatyAnim.y += Time.deltaTime * speed;
		}
		else
		{
			floatyAnim.y -= Time.deltaTime * speed;
		}

		if(left)
		{
			floatyAnim.x -= Time.deltaTime;
		}
		else
		{
			floatyAnim.x += Time.deltaTime;
		}

		transform.position = floatyAnim;
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.name == "up_trigger")
		{
			up = false;
		}
		else if(col.gameObject.name == "down_trigger")
		{
			up = true;
		}
		else if(col.gameObject.name == "left_trigger")
		{
			left = false;
		}
		else if(col.gameObject.name == "right_trigger")
		{
			left = true;
		}
		else if(col.gameObject.name == "IceCube")
		{
			if(left)
			{
				left = false;
				GetComponent<AudioSource>().Play();
			}
			else
			{
				left = true;
				GetComponent<AudioSource>().Play();
			}
		}
	}
}
