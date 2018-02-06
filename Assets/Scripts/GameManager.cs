using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class GameManager : MonoBehaviour {

	public GameObject currentCheckpoint;
	public UpperPlayerUserController upperPlayer;
	public LowerPlayerUserControl lowerPlayer;
	
	// Use this for initialization
	void Start () {
		upperPlayer = FindObjectOfType<UpperPlayerUserController>();
		lowerPlayer = FindObjectOfType<LowerPlayerUserControl>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}