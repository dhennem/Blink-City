using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;
	private LoseDetector loseDetector;

	public AudioClip loseSound;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
		loseDetector = FindObjectOfType<LoseDetector>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		print("trigger detected");
		if(collider.tag == "Player"){
			print("player trigger detected");
			FindObjectOfType<PlayerController>().gameObject.SetActive(false);
			LoseDetector.lost = true;
			AudioSource.PlayClipAtPoint(loseSound, transform.position);
			loseDetector.ShowLosePanel(LoseDetector.LoseReason.falling);

		}
		else{
			Destroy(collider.gameObject);
		}
	}
}
