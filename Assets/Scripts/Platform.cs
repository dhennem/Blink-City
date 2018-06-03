using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	static public int lastSpawnedPlatformPosition = 5; //the last spawned platform's position affects the position of the next spawned platform

	public float jumpVelocity;
	public Platform platformPrefab; //used to spawn new platforms
	public bool isInitialPlatform;
	public Resource resource1Prefab;
	public Resource resource2Prefab;
	public Resource resource3Prefab;

	private PlayerController player;
	private Transform spawnPoint; //point at which new platforms are spawned
	private bool spawnedNewPlatform = false;
	private int spawnPointXPos;

	// Use this for initialization
	void Start () {
		spawnPointXPos = Random.Range(1,9);
		if(isInitialPlatform){
			int platformsToSpawn = 8;
			while(platformsToSpawn > 0){
				while(spawnPointXPos == lastSpawnedPlatformPosition){
					spawnPointXPos = Random.Range(1,9);
				}
				Instantiate(platformPrefab, new Vector3(spawnPointXPos, transform.position.y + (float)(9-platformsToSpawn), transform.position.z), Quaternion.identity);
				lastSpawnedPlatformPosition = spawnPointXPos;
				platformsToSpawn -= 1;
			}
		}
		else{
			HandleResourceSpawns();
		}
		player = FindObjectOfType<PlayerController>();
		//each spawn point has a random horizontal position but a static vertical distance from the current platform
		spawnPoint = transform.GetChild(0);
		while(spawnPointXPos == lastSpawnedPlatformPosition || Mathf.Abs(spawnPointXPos-lastSpawnedPlatformPosition)>2f){ //ensures that no two consecutive platforms are at the same horizontal position and that consecutive platforms are not too far apart
			spawnPointXPos = Random.Range(1, 9);
		}
		spawnPoint.transform.position = new Vector3(spawnPointXPos, spawnPoint.transform.position.y, spawnPoint.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		//when player goes above this platform, spawn a new one a distance above it
		if(!spawnedNewPlatform && player.transform.position.y > transform.position.y){
			Instantiate(platformPrefab, spawnPoint.transform.position, Quaternion.identity);
			spawnedNewPlatform = true;
			lastSpawnedPlatformPosition = spawnPointXPos;
		}
		if(GetComponent<Rigidbody2D>().velocity.y > 0){
			GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
		}
		
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.relativeVelocity.y <= 0f && collision.collider.tag == "Player"){ //only bounce player up if they are coming from above
			Rigidbody2D playerRigidbody = collision.collider.GetComponent<Rigidbody2D>();
			Vector2 newPlayerVelocity = playerRigidbody.velocity;
			newPlayerVelocity.y = jumpVelocity;
			playerRigidbody.velocity = newPlayerVelocity;
			//GetComponent<Rigidbody2D>().gravityScale = 0.03f;
		}
	}

	void HandleResourceSpawns(){
		float random = Random.Range(0,1000);
		Transform resourceSpawnPoint = transform.GetChild(1);
		if(random<35){
			Instantiate(resource1Prefab, resourceSpawnPoint.position, Quaternion.identity);
		}
		else if(random<70){
			Instantiate(resource2Prefab, resourceSpawnPoint.position, Quaternion.identity);
		}
		else if(random<105){
			Instantiate(resource3Prefab, resourceSpawnPoint.position, Quaternion.identity);
		}
	}


}
