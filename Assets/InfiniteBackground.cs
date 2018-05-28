using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackground : MonoBehaviour {

	public InfiniteBackground infiniteBackgroundPrefab; //defined in the inspector

	private PlayerController player;
	private Transform spawnPoint;
	private bool nextBackgroundSpawned;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
		spawnPoint = transform.GetChild(0);
		nextBackgroundSpawned = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!nextBackgroundSpawned && player.transform.position.y > spawnPoint.position.y){
			//when the player goes above a certain point relative to each iteration of the background, spawn the next iteration only once
			Instantiate(infiniteBackgroundPrefab, new Vector3(transform.position.x, transform.position.y + 20f, transform.position.z), Quaternion.identity);
			nextBackgroundSpawned = true;
		}
		
	}
}
