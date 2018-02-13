using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerPlayerCheckPointController : MonoBehaviour {

	public Sprite redMushroom;
	public Sprite greenMushroom;
	private SpriteRenderer checkpointSpriteRenderer;
	public bool checkpointReached;
	
	// Use this for initialization
	void Start () {
		checkpointSpriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
    if (other.gameObject.name == "LowerPlayer") 
		{
      checkpointSpriteRenderer.sprite = greenMushroom;
      checkpointReached = true;
    }
  }
}
