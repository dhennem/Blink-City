using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawner : MonoBehaviour {

	public IntroSequenceManager intro;
	public PlayerController player1Prefab;
	public PlayerController player2Prefab;
	public PlayerController player3Prefab;
	public PlayerController player4Prefab;
	public PlayerController player5Prefab;
	public HealthDisplay healthDisplay;

	public string levelThatDoorwayLeadsTo;
	public string doorwayMessage;
	public string highScoreMessage;
	public string levelListingMessage;
	public Image highScoreMenu;
	public Image levelListingMenu;
	public Image settingsMenu;
	public Image helpMenu;
	public float speedMultiplier;
	public PlayerController.PlayerState currentState;
	public float scaleMultiplier;
	public int maxHealth;

	public bool spawnedPlayer = false;
	public bool updatedPlayerValues = false;

	private PlayerController player;

	// Use this for initialization
	void Start () {
		intro = FindObjectOfType<IntroSequenceManager>();
		healthDisplay = FindObjectOfType<HealthDisplay>();
		SpawnPlayer();
		
	}
	
	// Update is called once per frame
	void Update () {
		/*if(!spawnedPlayer && intro.introFinished){
			SpawnPlayer();
			spawnedPlayer = true;
		}*/
		if(player==null && spawnedPlayer){
			player = FindObjectOfType<PlayerController>();
		}
		if(spawnedPlayer && !updatedPlayerValues && player!=null){
			UpdatePlayerValues();
			updatedPlayerValues = true;
		}
		
	}

	void SpawnPlayer(){
		switch(PlayerPrefsManager.GetPlayerType()){
			case 0:
				Instantiate(player1Prefab, new Vector3(5f,5f,0f), Quaternion.identity);
				break;
			case 1:
				Instantiate(player2Prefab, new Vector3(5f,5f,0f), Quaternion.identity);
				break;
			case 2:
				Instantiate(player3Prefab, new Vector3(5f,5f,0f), Quaternion.identity);
				break;
			case 3:
				Instantiate(player4Prefab, new Vector3(5f,5f,0f), Quaternion.identity);
				break;
			case 4:
				Instantiate(player5Prefab, new Vector3(5f,5f,0f), Quaternion.identity);
				break;
		}
		spawnedPlayer = true;
	}

	void UpdatePlayerValues(){
		player.doorwayMessage = doorwayMessage;
		player.levelThatDoorwayLeadsTo = levelThatDoorwayLeadsTo;
		player.highScoreMessage = highScoreMessage;
		player.levelListingMessage = levelListingMessage;
		player.speedMultiplier = speedMultiplier;
		player.highScoreMenu = highScoreMenu;
		player.levelListingMenu = levelListingMenu;
		player.settingsMenu = settingsMenu;
		player.helpMenu = helpMenu;
		player.currentState = currentState;
		Vector3 currentScale = player.transform.localScale;
		player.transform.localScale = new Vector3(currentScale.x*scaleMultiplier, currentScale.y*scaleMultiplier, currentScale.z);
		player.maxHealth = maxHealth;
		player.currentHealth = maxHealth;
		if(player.currentState != PlayerController.PlayerState.OutOfCombat) healthDisplay.UpdateHealthDisplay();
	}


	public void showSettingsMenu(){
		player.ReadSettingsMenu();
	}
}
