using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoresManager : MonoBehaviour {

	public Text level1HighScoreDisplay;
	public Text level2HighScoreDisplay;
	public Text level3HighScoreDisplay;
	public Text level4HighScoreDisplay;
	public Text level5HighScoreDisplay;

	private string level1HighScoreName;
	private int level1HighScoreValue;
	private string level2HighScoreName;
	private int level2HighScoreValue;
	private string level3HighScoreName;
	private int level3HighScoreValue;
	private string level4HighScoreName;
	private int level4HighScoreValue;
	private string level5HighScoreName;
	private int level5HighScoreValue;

	// Use this for initialization
	void Start () {

		level1HighScoreName = PlayerPrefsManager.getLevel1HighScorer();
		level1HighScoreValue = PlayerPrefsManager.getLevel1HighScore();
		level2HighScoreName = PlayerPrefsManager.getLevel2HighScorer();
		level2HighScoreValue = PlayerPrefsManager.getLevel2HighScore();
		level3HighScoreName = PlayerPrefsManager.getLevel3HighScorer();
		level3HighScoreValue = PlayerPrefsManager.getLevel3HighScore();
		level4HighScoreName = PlayerPrefsManager.getLevel4HighScorer();
		level4HighScoreValue = PlayerPrefsManager.getLevel4HighScore();
		level5HighScoreName = PlayerPrefsManager.getLevel5HighScorer();
		level5HighScoreValue = PlayerPrefsManager.getLevel5HighScore();

		level1HighScoreDisplay.text = "Level 1: " + level1HighScoreValue.ToString() + " (" + level1HighScoreName + ")";
		level2HighScoreDisplay.text = "Level 2: " + level2HighScoreValue.ToString() + " (" + level2HighScoreName + ")";
		level3HighScoreDisplay.text = "Level 3: " + level3HighScoreValue.ToString() + " (" + level3HighScoreName + ")";
		level4HighScoreDisplay.text = "Level 4: " + level4HighScoreValue.ToString() + " (" + level4HighScoreName + ")";
		level5HighScoreDisplay.text = "Level 5: " + level5HighScoreValue.ToString() + " (" + level5HighScoreName + ")";
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
