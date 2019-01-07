using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour {

	private PlayerController player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(player == null){
			player = FindObjectOfType<PlayerController>();
			UpdateHealthDisplay();
		}

		
	}

	public void UpdateHealthDisplay(){
		for(int i = 0; i < transform.childCount; i++){
			if(i < player.currentHealth){
				transform.GetChild(i).gameObject.SetActive(true);
			}
			else{
				transform.GetChild(i).gameObject.SetActive(false);
			}
		}
		
	}
}
