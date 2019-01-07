using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public int score = 0;
	public Text scoreDisplay;

	public enum CurrentLevel {level1, level2, level3, level4, level5};
	public CurrentLevel level;
	public Image newHighScorePanel;
	public Image nextLevelPanel;
	private PlayerController player;

	public Text newHighScorePanelTitle;
	public Text previousHighScoreDescription;
	public Text newHighScoreValue;
	public InputField newHighScorer;
	public Text completedLevelMessage;
	public Text unlockedLevelMessage;

	private bool doneCheckingHighScores;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
		
	}
	
	// Update is called once per frame
	void Update () {
		scoreDisplay.text = score.ToString();
		if(doneCheckingHighScores){
			ShowNextLevelMessage();
		}
	}

	public void CheckHighScores(){
		switch (level){
			case ScoreKeeper.CurrentLevel.level1:
				if(score > PlayerPrefsManager.getLevel1HighScore()){
					newHighScorePanelTitle.text = "New High Score for Level 1!";
					previousHighScoreDescription.text = PlayerPrefsManager.getLevel1HighScore().ToString() + " by " + PlayerPrefsManager.getLevel1HighScorer();
					ShowNewHighScoreMessage();
				}
				else{
					doneCheckingHighScores = true;
				}
				break;
			case ScoreKeeper.CurrentLevel.level2:
				if(score > PlayerPrefsManager.getLevel2HighScore()){
					newHighScorePanelTitle.text = "New High Score for Level 2!";
					previousHighScoreDescription.text = PlayerPrefsManager.getLevel2HighScore().ToString() + " by " + PlayerPrefsManager.getLevel2HighScorer();
					ShowNewHighScoreMessage();
				}
				else{
					doneCheckingHighScores = true;
				}
				break;
			case ScoreKeeper.CurrentLevel.level3:
				if(score > PlayerPrefsManager.getLevel3HighScore()){
					newHighScorePanelTitle.text = "New High Score for Level 3!";
					previousHighScoreDescription.text = PlayerPrefsManager.getLevel3HighScore().ToString() + " by " + PlayerPrefsManager.getLevel3HighScorer();
					ShowNewHighScoreMessage();
				}
				else{
					doneCheckingHighScores = true;
				}
				break;
			case ScoreKeeper.CurrentLevel.level4:
				if(score > PlayerPrefsManager.getLevel4HighScore()){
					newHighScorePanelTitle.text = "New High Score for Level 4!";
					previousHighScoreDescription.text = PlayerPrefsManager.getLevel4HighScore().ToString() + " by " + PlayerPrefsManager.getLevel4HighScorer();
					ShowNewHighScoreMessage();
				}
				else{
					doneCheckingHighScores = true;
				}
				break;
			case ScoreKeeper.CurrentLevel.level5:
				if(score > PlayerPrefsManager.getLevel5HighScore()){
					newHighScorePanelTitle.text = "New High Score for Level 5!";
					previousHighScoreDescription.text = PlayerPrefsManager.getLevel5HighScore().ToString() + " by " + PlayerPrefsManager.getLevel5HighScorer();
					ShowNewHighScoreMessage();
				}
				else{
					doneCheckingHighScores = true;
				}
				break;
		}
	}

	public void ShowNewHighScoreMessage(){
		print("new high score!");
		newHighScoreValue.text = score.ToString();
		newHighScorePanel.gameObject.SetActive(true);
		//set the fields of the high score panel correctly: your score, previous highest score, previous highest scorer, what is your name?
		
	}

	public void CloseNewHighScoreMessage(){
		doneCheckingHighScores = true;
		switch (level){
			case ScoreKeeper.CurrentLevel.level1:
				PlayerPrefsManager.SetLevel1HighScore(score);
				PlayerPrefsManager.SetLevel1HighScorer(newHighScorer.text);
				break;
			case ScoreKeeper.CurrentLevel.level2:
				PlayerPrefsManager.SetLevel2HighScore(score);
				PlayerPrefsManager.SetLevel2HighScorer(newHighScorer.text);
				break;
			case ScoreKeeper.CurrentLevel.level3:
				PlayerPrefsManager.SetLevel3HighScore(score);
				PlayerPrefsManager.SetLevel3HighScorer(newHighScorer.text);
				break;
			case ScoreKeeper.CurrentLevel.level4:
				PlayerPrefsManager.SetLevel4HighScore(score);
				PlayerPrefsManager.SetLevel4HighScorer(newHighScorer.text);
				break;
			case ScoreKeeper.CurrentLevel.level5:
				PlayerPrefsManager.SetLevel5HighScore(score);
				PlayerPrefsManager.SetLevel5HighScorer(newHighScorer.text);
				break;
		}
		newHighScorePanel.gameObject.SetActive(false);
	}

	public void ShowNextLevelMessage(){
		nextLevelPanel.gameObject.SetActive(true);
		switch (level){
			case ScoreKeeper.CurrentLevel.level1:
				completedLevelMessage.text = "Level 1 Completed!";
				if(PlayerPrefsManager.getLevel2Lock()==0){
					unlockedLevelMessage.text = "Level 2 Unlocked!";
					PlayerPrefsManager.SetLevel2Lock(1);
				}
				else{
					unlockedLevelMessage.text = "";
				}
				break;
			case ScoreKeeper.CurrentLevel.level2:
				completedLevelMessage.text = "Level 2 Completed!";
				if(PlayerPrefsManager.getLevel3Lock()!=1){
					unlockedLevelMessage.text = "Level 3 Unlocked!";
					PlayerPrefsManager.SetLevel3Lock(1);
				}
				else{
					unlockedLevelMessage.text = "";
				}
				break;
			case ScoreKeeper.CurrentLevel.level3:
				completedLevelMessage.text = "Level 3 Completed!";
				if(PlayerPrefsManager.getLevel4Lock()!=1){
					unlockedLevelMessage.text = "Level 4 Unlocked!";
					PlayerPrefsManager.SetLevel4Lock(1);
				}
				else{
					unlockedLevelMessage.text = "";
				}
				break;
			case ScoreKeeper.CurrentLevel.level4:
				completedLevelMessage.text = "Level 4 Completed!";
				if(PlayerPrefsManager.getLevel5Lock()!=1){
					unlockedLevelMessage.text = "Level 5 Unlocked!";
					PlayerPrefsManager.SetLevel5Lock(1);
				}
				else{
					unlockedLevelMessage.text = "";
				}
				break;
			case ScoreKeeper.CurrentLevel.level5:
				completedLevelMessage.text = "Level 5 Completed!";
				unlockedLevelMessage.text = "All levels are unlocked!";
				break;
		}
	}

}
