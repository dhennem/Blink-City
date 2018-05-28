using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string PLAYER_TYPE_KEY = "player_type";
	const string LEVEL_1_LOCK_KEY = "level1lock";
	const string LEVEL_2_LOCK_KEY = "level2lock";
	const string LEVEL_3_LOCK_KEY = "level3lock";
	const string LEVEL_4_LOCK_KEY = "level4lock";
	const string LEVEL_5_LOCK_KEY = "level5lock";
	const string LEVEL_1_HIGH_SCORE_KEY = "level1highscore";
	const string LEVEL_2_HIGH_SCORE_KEY = "level2highscore";
	const string LEVEL_3_HIGH_SCORE_KEY = "level3highscore";
	const string LEVEL_4_HIGH_SCORE_KEY = "level4highscore";
	const string LEVEL_5_HIGH_SCORE_KEY = "level5highscore";
	const string LEVEL_1_HIGH_SCORER_KEY = "level1highscorer";
	const string LEVEL_2_HIGH_SCORER_KEY = "level2highscorer";
	const string LEVEL_3_HIGH_SCORER_KEY = "level3highscorer";
	const string LEVEL_4_HIGH_SCORER_KEY = "level4highscorer";
	const string LEVEL_5_HIGH_SCORER_KEY = "level5highscorer";
	//const string DIFFICULTY_KEY = "difficulty";

	public static void SetMasterVolume(float volume){
		if(volume >= 0f && volume <=1f){
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		}
		else{
			Debug.LogError("Master volume out of range");
		}
	}
	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}

	public static void SetPlayerType(int id){
		PlayerPrefs.SetInt(PLAYER_TYPE_KEY, id);
	}
	public static int GetPlayerType(){
		return PlayerPrefs.GetInt(PLAYER_TYPE_KEY);
	}


	/*public static void SetDifficulty(float difficulty){
		if(difficulty >= 1f && difficulty <= 5f){
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty); 
		}
		else{
			Debug.LogError("Difficulty out of range");
		}
	}
	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}*/

	public static void SetLevel1Lock(int lockValue){
		PlayerPrefs.SetInt(LEVEL_1_LOCK_KEY, lockValue);
	}
	public static void SetLevel2Lock(int lockValue){
		PlayerPrefs.SetInt(LEVEL_2_LOCK_KEY, lockValue);
	}
	public static void SetLevel3Lock(int lockValue){
		PlayerPrefs.SetInt(LEVEL_3_LOCK_KEY, lockValue);
	}
	public static void SetLevel4Lock(int lockValue){
		PlayerPrefs.SetInt(LEVEL_4_LOCK_KEY, lockValue);
	}
	public static void SetLevel5Lock(int lockValue){
		PlayerPrefs.SetInt(LEVEL_5_LOCK_KEY, lockValue);
	}

	public static int getLevel1Lock(){
		return PlayerPrefs.GetInt(LEVEL_1_LOCK_KEY);
	} 
	public static int getLevel2Lock(){
		return PlayerPrefs.GetInt(LEVEL_2_LOCK_KEY);
	}
	public static int getLevel3Lock(){
		return PlayerPrefs.GetInt(LEVEL_3_LOCK_KEY);
	}
	public static int getLevel4Lock(){
		return PlayerPrefs.GetInt(LEVEL_4_LOCK_KEY);
	}
	public static int getLevel5Lock(){
		return PlayerPrefs.GetInt(LEVEL_5_LOCK_KEY);
	}

	public static void SetLevel1HighScore(int score){
		PlayerPrefs.SetInt(LEVEL_1_HIGH_SCORE_KEY, score);
	}
	public static void SetLevel2HighScore(int score){
		PlayerPrefs.SetInt(LEVEL_2_HIGH_SCORE_KEY, score);
	}
	public static void SetLevel3HighScore(int score){
		PlayerPrefs.SetInt(LEVEL_3_HIGH_SCORE_KEY, score);
	}
	public static void SetLevel4HighScore(int score){
		PlayerPrefs.SetInt(LEVEL_4_HIGH_SCORE_KEY, score);
	}
	public static void SetLevel5HighScore(int score){
		PlayerPrefs.SetInt(LEVEL_5_HIGH_SCORE_KEY, score);
	}

	public static int getLevel1HighScore(){
		return PlayerPrefs.GetInt(LEVEL_1_HIGH_SCORE_KEY);
	}
	public static int getLevel2HighScore(){
		return PlayerPrefs.GetInt(LEVEL_2_HIGH_SCORE_KEY);
	}
	public static int getLevel3HighScore(){
		return PlayerPrefs.GetInt(LEVEL_3_HIGH_SCORE_KEY);
	}
	public static int getLevel4HighScore(){
		return PlayerPrefs.GetInt(LEVEL_4_HIGH_SCORE_KEY);
	}
	public static int getLevel5HighScore(){
		return PlayerPrefs.GetInt(LEVEL_5_HIGH_SCORE_KEY);
	}

	public static void SetLevel1HighScorer(string name){
		PlayerPrefs.SetString(LEVEL_1_HIGH_SCORER_KEY, name);
	}
	public static void SetLevel2HighScorer(string name){
		PlayerPrefs.SetString(LEVEL_2_HIGH_SCORER_KEY, name);
	}
	public static void SetLevel3HighScorer(string name){
		PlayerPrefs.SetString(LEVEL_3_HIGH_SCORER_KEY, name);
	}
	public static void SetLevel4HighScorer(string name){
		PlayerPrefs.SetString(LEVEL_4_HIGH_SCORER_KEY, name);
	}
	public static void SetLevel5HighScorer(string name){
		PlayerPrefs.SetString(LEVEL_5_HIGH_SCORER_KEY, name);
	}

	public static string getLevel1HighScorer(){
		return PlayerPrefs.GetString(LEVEL_1_HIGH_SCORER_KEY);
	}
	public static string getLevel2HighScorer(){
		return PlayerPrefs.GetString(LEVEL_2_HIGH_SCORER_KEY);
	}
	public static string getLevel3HighScorer(){
		return PlayerPrefs.GetString(LEVEL_3_HIGH_SCORER_KEY);
	}
	public static string getLevel4HighScorer(){
		return PlayerPrefs.GetString(LEVEL_4_HIGH_SCORER_KEY);
	}
	public static string getLevel5HighScorer(){
		return PlayerPrefs.GetString(LEVEL_5_HIGH_SCORER_KEY);
	}



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
