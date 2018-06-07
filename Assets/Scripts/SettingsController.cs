using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {

//need way to update player image with dropdown value

	public Slider volumeSlider;
	public Image playerImage;
	public Dropdown playerDropdown;
	public LevelManager levelManager;
	public Image resetWarning;

	public Sprite[] playerImages; //used to store the sprites for each type of player

	private MusicPlayer musicPlayer;

	// Use this for initialization
	void Start () {
		musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();
		playerImage.sprite = playerImages[PlayerPrefsManager.GetPlayerType()];
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		playerDropdown.value = PlayerPrefsManager.GetPlayerType();
		playerDropdown.ClearOptions();
		playerDropdown.AddOptions(new List<string> {"Orange Player", "Green Player", "Gray Player", "Red Player", "Brown Player"});
	}
	
	// Update is called once per frame
	void Update () {
		//musicPlayer.SetVolume(volumeSlider.value)
		playerImage.sprite = playerImages[playerDropdown.value];
	}

	public void SaveAndExit(){
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayerPrefsManager.SetPlayerType(playerDropdown.value);
		levelManager.LoadLevel("Home_01");
	}

	public void SetDefaults(){
		volumeSlider.value = 0.5f;
		playerDropdown.value = 0;
		//set dropdown value to first player
		playerImage.sprite = playerImages[0];

	}

	public void ShowResetWarning(){
		resetWarning.gameObject.SetActive(true);
	}

	public void CloseResetWarning(){
		resetWarning.gameObject.SetActive(false);
	}

	public void ResetScoresAndLevels(){
		PlayerPrefsManager.SetLevel2Lock(0);
		PlayerPrefsManager.SetLevel3Lock(0);
		PlayerPrefsManager.SetLevel4Lock(0);
		PlayerPrefsManager.SetLevel5Lock(0);
		PlayerPrefsManager.SetLevel1HighScore(0);
		PlayerPrefsManager.SetLevel2HighScore(0);
		PlayerPrefsManager.SetLevel3HighScore(0);
		PlayerPrefsManager.SetLevel4HighScore(0);
		PlayerPrefsManager.SetLevel5HighScore(0);
		PlayerPrefsManager.SetLevel1HighScorer("---");
		PlayerPrefsManager.SetLevel2HighScorer("---");
		PlayerPrefsManager.SetLevel3HighScorer("---");
		PlayerPrefsManager.SetLevel4HighScorer("---");
		PlayerPrefsManager.SetLevel5HighScorer("---");
	}
}
