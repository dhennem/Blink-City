using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portal : MonoBehaviour {

	public ScoreKeeper scoreKeeper;
	public AudioClip winSound;

	private PlayerController player;


	// Use this for initialization
	void Start () {
		scoreKeeper = FindObjectOfType<ScoreKeeper>();
		player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.tag == "Player"){
			print("player trigger detected with portal");
			scoreKeeper.CheckHighScores();
			AudioSource.PlayClipAtPoint(winSound, transform.position);
			player.gameObject.SetActive(false);
		}
	}


}
