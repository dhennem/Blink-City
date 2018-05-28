using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseDetector : MonoBehaviour {

	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision){
		print("collision detected");
		if(collision.collider.tag == "Player"){
			print("player collision detected");
			levelManager.LoadLoseWithPause();
		}
	}
}
