using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public float waitTimeBeforeNextLevel;
	public bool isSplash;
	public PlayerController player;
	public static int highestLevelReached;
	public float waitTimeBeforeLose;

	// Use this for initialization
	void Start () {
		if(isSplash){
			LoadNextLevel();
		}
		player = FindObjectOfType<PlayerController>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadLevel(string levelName){
		RefreshValuesBeforeNewLevel();
		Application.LoadLevel(levelName);
	}
	public void QuitRequestl(){
		Debug.Log("Quit requested");
	}
	private void LoadNextLevel(){
		RefreshValuesBeforeNewLevel();
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	public void LoadNextLevelWithWait(){
		/*if(waitTimeBeforeNextLevel == 0){
			LoadNextLevel();
		}
		else{*/
		Invoke("LoadNextLevel", waitTimeBeforeNextLevel);
		//}
	}
	public void LoadLoseWithPause(){
		Invoke("Lose",waitTimeBeforeLose);
	}
	/*public void LoadHighestLevelReached(){
		Application.LoadLevel(highestLevelReached);
	}*/
	private void Lose(){
		RefreshValuesBeforeNewLevel();
		//if(Application.loadedLevel > highestLevelReached) highestLevelReached = Application.loadedLevel;
		LoadLevel("Lose");
		//player.DeactivateSuperpower();
	}

	private void RefreshValuesBeforeNewLevel(){
		FadeOut.nextLevelName = "";
		Platform.winPortalSpawned = false;
		Bar.OneBarDepleted = false;
		//return static variables, etc to original values before loading a new level
		/*player.shieldBar.resourceValue = player.shieldBar.GetMinValue();
		player.healthBar.resourceValue = player.originalMaxHealth;
		player.healthBar.ChangeMaxValue(player.originalMaxHealth);
		player.DeactivateSuperpower();
		*/
	}
}
