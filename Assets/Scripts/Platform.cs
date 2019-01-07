using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	static public int lastSpawnedPlatformPosition = 5; //the last spawned platform's position affects the position of the next spawned platform
	static public bool winPortalSpawned;

	public float jumpVelocity;
	public Platform platformPrefab; //used to spawn new platforms
	public bool isInitialPlatform;
	public Resource resource1Prefab;
	public Resource resource2Prefab;
	public Resource resource3Prefab;
	public LifeHeart lifeHeartPrefab;
	public EnemyBehavior flyingEnemyPrefab;
	public Platform portalPlatformPrefab;
	public ScoreKeeper scoreKeeper;
	public WinDetector winDetector;
	public int platformScoreValue;
	public AudioClip jumpingSound;

	private PlayerController player;
	private CameraController camera;
	private Transform spawnPoint; //point at which new platforms are spawned
	private bool spawnedNewPlatform = false;
	private bool spawnedNewEnemy = false;
	private int spawnPointXPos;
	private bool gavePlayerScoreForJump; //only 1 score increase per platform

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
			if(!winPortalSpawned) HandleResourceSpawns();
		}
		scoreKeeper = FindObjectOfType<ScoreKeeper>();
		winDetector = FindObjectOfType<WinDetector>();
		camera = FindObjectOfType<CameraController>();
		//each spawn point has a random horizontal position but a static vertical distance from the current platform
		spawnPoint = transform.GetChild(0);
		while(spawnPointXPos == lastSpawnedPlatformPosition || Mathf.Abs(spawnPointXPos-lastSpawnedPlatformPosition)>2f){ //ensures that no two consecutive platforms are at the same horizontal position and that consecutive platforms are not too far apart
			spawnPointXPos = Random.Range(1, 9);
		}
		spawnPoint.transform.position = new Vector3(spawnPointXPos, spawnPoint.transform.position.y, spawnPoint.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if(player == null) player = FindObjectOfType<PlayerController>();
		//when player goes above this platform, spawn a new one a distance above it
		if(!spawnedNewPlatform && player.transform.position.y > transform.position.y && winDetector.numBarsFilled<3){
			Instantiate(platformPrefab, spawnPoint.transform.position, Quaternion.identity);
			spawnedNewPlatform = true;
			lastSpawnedPlatformPosition = spawnPointXPos;
		}
		if(!spawnedNewEnemy && player.transform.position.y > transform.position.y && winDetector.numBarsFilled<3){
			if(Random.Range(0,100) > 80){
				Vector3 enemyPos = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y + Random.Range(0,1), 0f);
				Instantiate(flyingEnemyPrefab, enemyPos, Quaternion.identity);
			}
			spawnedNewEnemy = true;
		}
		if(winDetector.numBarsFilled == 3 && !winPortalSpawned){
			print("win portal trying to be spawned");
			SpawnWinPortal();
			winPortalSpawned = true;
		}
		
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.relativeVelocity.y <= 0f && collision.collider.tag == "Player"){ //only bounce player up if they are coming from above
			//JumpPlayer(collision.collider.GetComponent<Rigidbody2D>());
			AudioSource.PlayClipAtPoint(jumpingSound, transform.position);
			//GetComponent<Rigidbody2D>().gravityScale = 0.03f;
			if(!gavePlayerScoreForJump){
				scoreKeeper.score += platformScoreValue;
				gavePlayerScoreForJump = true;
			}
		}
	}

	void HandleResourceSpawns(){
		float random = Random.Range(0,1000);
		Transform resourceSpawnPoint = transform.GetChild(1);
		if(random<100){
			Instantiate(resource1Prefab, resourceSpawnPoint.position, Quaternion.identity);
		}
		else if(random<200){
			Instantiate(resource2Prefab, resourceSpawnPoint.position, Quaternion.identity);
		}
		else if(random<300){
			Instantiate(resource3Prefab, resourceSpawnPoint.position, Quaternion.identity);
		}
		else if(random<325){
			Instantiate(lifeHeartPrefab, this.transform);

		}
	}

	//spawns a trail of platforms that lead to the win portal. Only spawn once all 3 bars are filled
	void SpawnWinPortal(){
		int numPlatformsToSpawn = 10;
		Instantiate(portalPlatformPrefab, new Vector3(5f, camera.transform.position.y + 9.5f + (float)numPlatformsToSpawn, 0f), Quaternion.identity);
		while(numPlatformsToSpawn > 0){
			print("spawning a win platform");
			Instantiate(platformPrefab, new Vector3(5f, camera.transform.position.y + 8.5f + (float)numPlatformsToSpawn, 0f), Quaternion.identity);
			numPlatformsToSpawn -= 1; 
		}
	}

	public void JumpPlayer(Rigidbody2D playerRigidBody){
		Rigidbody2D playerRigidbody = playerRigidBody;
		Vector2 newPlayerVelocity = playerRigidbody.velocity;
		newPlayerVelocity.y = jumpVelocity;
		playerRigidbody.velocity = newPlayerVelocity;
	}


}
