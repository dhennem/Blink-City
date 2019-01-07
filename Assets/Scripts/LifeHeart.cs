using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeHeart : MonoBehaviour {

	public int lifeHeartValue;
	public PlayerController player;
	public AudioClip pickupSound;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.tag == "Player"){
			print("Resource pickup");
			HandleLifeHeartPickups();
			Destroy(gameObject);
		}
	}

	void HandleLifeHeartPickups(){
		player.LifeHeartPickup(lifeHeartValue);
		AudioSource.PlayClipAtPoint(pickupSound, transform.position);
	}
}
