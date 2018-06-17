using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public enum PlayerState {OutOfCombat, FlyingCombat, GroundCombat};
	public int maxHealth;
	public int currentHealth;

	private bool facingLeft;
	private bool standingInDoorway;
	private bool enteringDoorway;
	private bool standingNearHighScore;
	private bool readingHighScore;
	private bool standingNearLevelListing;
	private bool readingLevelListing;
	private bool readingSettings;
	private bool readingHelp;
	private bool immuneToDamage;
	private bool dead;
	private Vector3 deathPosition;
	private Vector3 startPosition;
	private float deathSequenceDuration;

	public PlayerState currentState; //current state of player defined in inspector for each scene. This determines how the player is allowed to move/act

	public GUIMessageManager messager; //handles creating and deleting UI messages
	public string doorwayMessage; //message displayed when player stands in a doorway
	public string highScoreMessage; //displayed when near high score board
	public string levelListingMessage; //displayed when near level listing board
	public string levelThatDoorwayLeadsTo;
	public Image highScoreMenu;
	public Image levelListingMenu;
	public Image settingsMenu;
	public Image helpMenu;
	public float speedMultiplier;
	public GameObject playerExplosion;
	public AudioClip loseSound;
	public AudioClip playerExplosionSound;

	private Animator playerAnimator;
	private LevelManager levelManager;
	private HealthDisplay healthDisplay;
	private LoseDetector loseDetector;

	// Use this for initialization
	void Start () {
		playerAnimator = GetComponent<Animator>();
		levelManager = FindObjectOfType<LevelManager>();
		healthDisplay = FindObjectOfType<HealthDisplay>();
		loseDetector = FindObjectOfType<LoseDetector>();
		messager = FindObjectOfType<GUIMessageManager>();
		currentHealth = maxHealth;
		startPosition = transform.position;

		
	}
	
	// Update is called once per frame
	void Update () {
		if ((!dead && IntroSequenceManager.introFinished) || currentState == PlayerController.PlayerState.OutOfCombat){
			HandleMovement();
			HandleTurning();
		}
		HandleDoorwayEntrances();
		HandleHighScoreReads();
		HandleLevelListingReads();
		/*if(){
			print("in doorway");
		}
		else{
			print("not in doorway");
		}*/
		if(dead){
			transform.position = deathPosition;
			ShrinkPlayer(deathSequenceDuration, 0.5f);
			RotatePlayer(deathSequenceDuration, 3.0f);
		}
		if(!IntroSequenceManager.introFinished && currentState == PlayerController.PlayerState.FlyingCombat){
			transform.position = startPosition;
			GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
		}
		if(enteringDoorway){ //makes the player look like they're walking away because their scale shrinks
			 ShrinkPlayer(3f, 0.7f);
		}
		
	}

	void HandleMovement(){
		transform.rotation = Quaternion.identity;
		if(currentState == PlayerState.OutOfCombat && !enteringDoorway && !readingHighScore && !readingLevelListing && !readingHelp && !readingSettings){
			if(Input.GetKey(KeyCode.LeftArrow)){
				GetComponent<Rigidbody2D>().velocity = new Vector2(-2f*speedMultiplier, 0f); 
				playerAnimator.SetBool("Walking", true);
				facingLeft = true;
			}
			else if(Input.GetKey(KeyCode.RightArrow)){
				GetComponent<Rigidbody2D>().velocity = new Vector2(2f*speedMultiplier, 0f);
				facingLeft = false;
				playerAnimator.SetBool("Walking", true);
			}
			else{
				playerAnimator.SetBool("Walking", false);
			}
		}
		else if(currentState == PlayerState.FlyingCombat){
			
			if(transform.position.x > 10f){
				transform.position = new Vector2(-0f, transform.position.y);	
			}
			else if(transform.position.x < -0f){
				transform.position = new Vector2(10f, transform.position.y);	
			}
			if(Input.GetKey(KeyCode.LeftArrow)){
				GetComponent<Rigidbody2D>().velocity = new Vector2(-2f*speedMultiplier, GetComponent<Rigidbody2D>().velocity.y); 
				facingLeft = true;
			}
			else if(Input.GetKey(KeyCode.RightArrow)){
				GetComponent<Rigidbody2D>().velocity = new Vector2(2f*speedMultiplier, GetComponent<Rigidbody2D>().velocity.y);
				facingLeft = false;
			}
			else{
			}

		}
		else if(currentState == PlayerState.GroundCombat){
		}
	}

	//handles player turning
	void HandleTurning(){
		if(facingLeft){
			GetComponent<SpriteRenderer>().flipX = false;
		}
		else{
			GetComponent<SpriteRenderer>().flipX = true;
		}
	}



	void OnCollisionEnter2D(Collision2D collision){
		if(collision.collider.tag == "doorway" && !enteringDoorway){
			standingInDoorway = true;
			messager.displayNewMessage(doorwayMessage);
			print("entering doorway");
		}
		if(collision.collider.tag == "highScore" && !readingHighScore){
			standingNearHighScore = true;
			messager.displayNewMessage(highScoreMessage);
			print("entering high score");
		}
		if(collision.collider.tag == "levelListing" && !readingLevelListing){
			standingNearLevelListing = true;
			messager.displayNewMessage(levelListingMessage);
			print("entering level listing");
		}
	}
	void OnCollisionExit2D(Collision2D collision){
		if(collision.collider.tag == "doorway"){
			standingInDoorway = false;
			messager.deleteMessage();
			print("leaving doorway");
		}
		if(collision.collider.tag == "highScore"){
			standingNearHighScore = false;
			messager.deleteMessage();
			print("leaving high score");
		}
		if(collision.collider.tag == "levelListing"){
			standingNearLevelListing = false;
			messager.deleteMessage();
			print("leaving level listing");
		}
	}



	void HandleDoorwayEntrances(){
		if(standingInDoorway && Input.GetKeyDown(KeyCode.UpArrow)){
			playerAnimator.SetTrigger("WalkingAway");
			enteringDoorway = true;
			messager.deleteMessage();
			FadeOut.fadingOut = true;
			FadeOut.nextLevelName = levelThatDoorwayLeadsTo;

		}

	}

	void HandleHighScoreReads(){
		if(standingNearHighScore && Input.GetKeyDown(KeyCode.UpArrow)){
			readingHighScore = true;
			playerAnimator.SetBool("FacingAway", true);
			messager.deleteMessage();
			if(highScoreMenu != null) highScoreMenu.gameObject.SetActive(true);
			//make high scores appear

		}

	}

	void HandleLevelListingReads(){
		if(standingNearLevelListing && Input.GetKeyDown(KeyCode.UpArrow)){
			readingLevelListing = true;
			playerAnimator.SetBool("FacingAway", true);
			messager.deleteMessage();
			if(levelListingMenu != null) levelListingMenu.gameObject.SetActive(true);
			//make level listings appear

		}

	}

	public void ReadSettingsMenu(){
		readingSettings = true;
		settingsMenu.gameObject.SetActive(true);
	}

	public void ReadHelpMenu(){
		print("reading help menu");
		readingHelp = true;
		helpMenu.gameObject.SetActive(true);
	}

	public void StopReading(){
		readingHighScore = false;
		readingLevelListing = false;
		readingSettings = false;
		readingHelp = false;
		playerAnimator.SetBool("FacingAway", false);
	}

	void ShrinkPlayer(float duration, float newScale){
		Vector3 currentScale = transform.localScale;
		float amountToChange = (Time.deltaTime / duration) * (1 - newScale);
		transform.localScale = new Vector3(currentScale.x - amountToChange, currentScale.y -amountToChange, currentScale.z);
	}

	//rotates the player numSpins times in duration seconds
	void RotatePlayer(float duration, float numSpins){
		float amountToChange = (Time.deltaTime / duration) * (360 * numSpins);
		Vector3 currentAngles = transform.eulerAngles;
		transform.eulerAngles = new Vector3(currentAngles.x, currentAngles.y, currentAngles.z + amountToChange);
	}

	public void TakeDamage(int damageValue){
		if(!immuneToDamage){
			if(currentHealth - damageValue < 1){
				currentHealth = 0;
				PlayerDeath(3f);
			}
			else{
				currentHealth -= damageValue;
				GetComponent<Animator>().SetTrigger("TakingDamage");
				print("taking damage");
				print(currentHealth);
			}
			immuneToDamage = true;
			Invoke("TurnOffDamageImmunity", 2f); //cannot take damage more than once every 2 seconds
			healthDisplay.UpdateHealthDisplay();
		}


	}

	void TurnOffDamageImmunity(){
		immuneToDamage = false;
	}

	public void LifeHeartPickup(int lifeHeartValue){
		currentHealth = Mathf.Min( currentHealth + lifeHeartValue, maxHealth);
		healthDisplay.UpdateHealthDisplay();
	}

	void PlayerDeath(float duration){
		dead = true;
		LoseDetector.lost = true;
		deathPosition = transform.position;
		deathSequenceDuration = duration;
		AudioSource.PlayClipAtPoint(loseSound, transform.position);
		Invoke("PlayerExplosion", duration);
		Invoke("DeactivatePlayer", duration + 2f);
	}

	void DeactivatePlayer(){
		loseDetector.ShowLosePanel(LoseDetector.LoseReason.health);
	}

	void PlayerExplosion(){
		Instantiate(playerExplosion, transform.position, Quaternion.identity);
		AudioSource.PlayClipAtPoint(playerExplosionSound, transform.position);
		gameObject.SetActive(false);
	}

}
