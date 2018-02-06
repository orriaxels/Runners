using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour {

	public Sprite redMushroom;
	public Sprite greenMushroom;
	private SpriteRenderer checkpointSpriteRenderer;
	public bool checkpointReached;
	// Use this for initialization
	void Start () {
		checkpointSpriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
    if (other.tag == "Player") {
      checkpointSpriteRenderer.sprite = greenMushroom;
      checkpointReached = true;
    }
  }
}
