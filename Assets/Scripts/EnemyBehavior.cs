using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

	public enum EnemyState {GroundEnemy, FlyingEnemy};
	public EnemyState currentEnemyState;
	public PlayerController player;
	public float speedMultiplier;
	public float playerJumpVelocity;
	public int playerDamage;
	public ScoreKeeper scoreKeeper;
	public int scoreValue;
	public GameObject enemyExplosionPrefab;
	public AudioClip enemyExplosionSound;

	private bool movingRight;
	private float leftBoundary, rightBoundary;
	private bool falling = false;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
		scoreKeeper = FindObjectOfType<ScoreKeeper>();
		if(currentEnemyState == EnemyBehavior.EnemyState.FlyingEnemy){
			if(Random.Range(0,2) == 1){
				movingRight = true;
				GetComponent<Animator>().SetBool("movingRight", true);
			}
			else{
				GetComponent<Animator>().SetBool("movingRight", false);
			}
			leftBoundary = Random.Range(1f,4f);
			rightBoundary = Random.Range(6f,9f);
		}
		else{
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if(currentEnemyState == EnemyBehavior.EnemyState.FlyingEnemy){
			HandleFlyingMovement();
		}
		else{
		}
		HandleTurning();
	}

	void HandleFlyingMovement(){
		if(!falling) transform.rotation = Quaternion.identity;
		if(movingRight && transform.position.x > rightBoundary){
			movingRight = false;
			GetComponent<Animator>().SetBool("movingRight", false);
			leftBoundary = Random.Range(1f, 4f);
		}
		else if(!movingRight && transform.position.x < leftBoundary){
			movingRight = true;
			GetComponent<Animator>().SetBool("movingRight", true);
			rightBoundary = Random.Range(6f, 9f);
		}
		if(movingRight){
			GetComponent<Rigidbody2D>().velocity = new Vector2(speedMultiplier, 0f);
		}
		else{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-speedMultiplier, 0f);
		}
		
	}

	void HandleTurning(){
		if(movingRight){
			GetComponent<SpriteRenderer>().flipX = false;
		}
		else{
			GetComponent<SpriteRenderer>().flipX = true;
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.collider.gameObject.tag == "Player"){
			if(collision.relativeVelocity.y < 0f){
				collision.collider.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, playerJumpVelocity);
				if(currentEnemyState == EnemyBehavior.EnemyState.FlyingEnemy){
					falling = true;
					GetComponent<Animator>().SetTrigger("Falling");
					Invoke("EnemyDeath", 0.75f);
					scoreKeeper.score += scoreValue;
				}
			}
			else{
				player.TakeDamage(playerDamage);
			}
			
		}
	}

	void EnemyDeath(){
		Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
		AudioSource.PlayClipAtPoint(enemyExplosionSound, transform.position);
		Destroy(gameObject);
	}
}
