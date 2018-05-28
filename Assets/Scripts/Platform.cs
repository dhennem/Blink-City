using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	public float jumpVelocity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.relativeVelocity.y <= 0f){ //only bounce player up if they are coming from above
			Rigidbody2D playerRigidbody = collision.collider.GetComponent<Rigidbody2D>();
			Vector2 newPlayerVelocity = playerRigidbody.velocity;
			newPlayerVelocity.y = jumpVelocity;
			playerRigidbody.velocity = newPlayerVelocity;
		}
	}

}
