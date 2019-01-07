using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackground : MonoBehaviour {

	public InfiniteBackground infiniteBackgroundPrefab; //defined in the inspector

	private PlayerController player;
	private Transform spawnPoint;
	private bool nextBackgroundSpawned;
	private float imageHeight;

	// Use this for initialization
	void Start () {
		spawnPoint = transform.GetChild(0);
		nextBackgroundSpawned = false;
		imageHeight = GetComponent<SpriteRenderer>().size.y;
		print(imageHeight);

		
	}
	
	// Update is called once per frame
	void Update () {
		if(player == null) player = FindObjectOfType<PlayerController>();
		if(!nextBackgroundSpawned && player.transform.position.y > spawnPoint.position.y){
			//when the player goes above a certain point relative to each iteration of the background, spawn the next iteration only once
			print("making new background");
			Instantiate(infiniteBackgroundPrefab, new Vector3(transform.position.x, transform.position.y + 683/40 -0.915f, transform.position.z), Quaternion.identity);
			nextBackgroundSpawned = true;
		}
		if(player.transform.position.y > transform.position.y + 30f){
			Destroy(gameObject);
		}
	}
}
