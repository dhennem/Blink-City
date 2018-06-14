using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float waitTimeBeforeNextLevel;
	public bool isSplash;
	public PlayerController player;
	public static int highestLevelReached;
	public float waitTimeBeforeLose;
	public AudioClip levelEnterSound;

	// Use this for initialization
	void Start () {
		if(isSplash){
			LoadNextLevel();
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if(player==null){
			player = FindObjectOfType<PlayerController>();	
		}
		
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

	public void LoadLevelWithFadeOut(string levelName){
		FadeOut.nextLevelName = levelName;
		FadeOut.fadingOut = true;
		print("load level with fade out");
	}

	private void RefreshValuesBeforeNewLevel(){
		FadeOut.nextLevelName = "";
		Platform.winPortalSpawned = false;
		LoseDetector.lost = false;
		IntroSequenceManager.introFinished = false;
	}

	public void PlayEnterLevelSound(){
		AudioSource.PlayClipAtPoint(levelEnterSound, player.transform.position);
	}

	public void ReloadWithFadeOut(){
		FadeOut.nextLevelName = SceneManager.GetActiveScene().name;
		FadeOut.fadingOut = true;
	}

}
