using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

	private PlayerController player;

	// Use this for initialization
	void Start () {
		gameObject.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
        if(player==null){
            player = FindObjectOfType<PlayerController>();
        }
	}

	public void viewMenu(){
		gameObject.SetActive(true);
	}

	public void exitMenu(){
		gameObject.SetActive(false);
		player.StopReading();
	}
}
