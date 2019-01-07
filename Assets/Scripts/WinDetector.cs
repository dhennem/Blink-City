using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDetector : MonoBehaviour {

	public int numBarsFilled = 0;

	private bool winMessageDisplayed = false;
	private GUIMessageManager messager;

	// Use this for initialization
	void Start () {
		messager = FindObjectOfType<GUIMessageManager>();
	}
	
	// Update is called once per frame
	void Update () {

		if(!winMessageDisplayed && numBarsFilled == 3 && !messager.displayingMessage){
			DisplayWinMessage();
		}
		
	}

	void DisplayWinMessage(){
		winMessageDisplayed = true;
		messager.displayNewMessage("All the resources are collected! Proceed upwards to the portal!");
		Invoke("DeleteWinMessage", 5f);
	}

	void DeleteWinMessage(){
		messager.deleteMessage();
	}
}
