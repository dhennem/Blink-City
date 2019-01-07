using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource : MonoBehaviour {

	private Bar resourceBar;
	private Bar[] resourceBars;
	public enum ResourceType {Resource1, Resource2, Resource3};
	public ResourceType resourceType;
	public float resourceValue;
	public int scoreValue;
	public ScoreKeeper scoreKeeper;
	public AudioClip pickupSound;

	private PlayerController player;
	private bool pickedUp;

	// Use this for initialization
	void Start () {
		resourceBars = FindObjectsOfType<Bar>();
		switch(resourceType){
			case Resource.ResourceType.Resource1:
				foreach (Bar bar in resourceBars){
					if(bar.gameObject.tag == "resourceBar1") resourceBar = bar;
				}
				break;
			case Resource.ResourceType.Resource2:
				foreach (Bar bar in resourceBars){
					if(bar.gameObject.tag == "resourceBar2") resourceBar = bar;
				}
				break;
			case Resource.ResourceType.Resource3:
				foreach (Bar bar in resourceBars){
					if(bar.gameObject.tag == "resourceBar3") resourceBar = bar;
				}
				break;
		}
		scoreKeeper = FindObjectOfType<ScoreKeeper>();
		player = FindObjectOfType<PlayerController>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.y > transform.position.y + 30f){
			Destroy(gameObject);
		}
		if(pickedUp){  //fade and expand the resource
			Color currentColor = GetComponent<SpriteRenderer>().color; 
			currentColor.a = currentColor.a - Time.deltaTime;
			GetComponent<SpriteRenderer>().color = currentColor;
			Vector3 currentScale = transform.localScale;
			transform.localScale = new Vector3(currentScale.x += Time.deltaTime, currentScale.y += Time.deltaTime, currentScale.z) ;
		}
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.tag == "Player"){
			print("Resource pickup");
			if(!pickedUp){
				HandleResourcePickups();
				Invoke("DestroyResource", 1f);
			}
		}
	}


	void HandleResourcePickups(){
		print("trying to increase resourcevalue");
		print(resourceBar.persent);
		pickedUp = true;
		resourceBar.persent = resourceValue + resourceBar.persent;
		scoreKeeper.score += scoreValue;
		AudioSource.PlayClipAtPoint(pickupSound, transform.position);
		
	}

	void DestroyResource(){
		Destroy(gameObject);
	}
}
