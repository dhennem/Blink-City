using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIMessageManager : MonoBehaviour {

	public bool displayingMessage;
	private string messageText;
	public Color messageColor;
	public bool blinkingMessage;

	public GUIStyle messageStyle;

	// Use this for initialization
	void Start () {
		if(blinkingMessage){
			InvokeRepeating("ToggleFadeOutMessageColor", 0.5f, 0.5f);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if(displayingMessage) print("displaying message");
		messageStyle.normal.textColor = messageColor;

		
	}

	public void displayNewMessage(string message){
		print("trying to display new message");
		displayingMessage = true;
		messageText = message;
	}

	public void deleteMessage(){
		displayingMessage = false;
	}

	void ToggleFadeOutMessageColor(){  //makes the message have a blinking effect
		if(messageColor.a > 0.5f){
			messageColor.a = 0f;
		}
		else{
			messageColor.a = 1f;
		} 
	}

	void OnGUI(){
		if(displayingMessage){
			print("ongui trying to display message");
			GUI.Label(new Rect(Screen.width/2 - 125, Screen.height/2 + 125, 250f, 50f), messageText, messageStyle);
		}
	}
}
