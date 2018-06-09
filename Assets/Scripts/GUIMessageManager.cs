using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIMessageManager : MonoBehaviour {

	public enum MessageType {Default, IntroSequence};

	public MessageType messageType;

	public bool displayingMessage;
	private string messageText;
	public Color messageColor;
	public bool blinkingMessage;

	public GUIStyle Style1; //normal text
	public GUIStyle Style2; //intro sequence text

	// Use this for initialization
	void Start () {
		if(blinkingMessage){
			InvokeRepeating("ToggleFadeOutMessageColor", 0.5f, 0.5f);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		Style1.normal.textColor = messageColor;
		Style2.normal.textColor = messageColor;

		
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
			if(messageType == GUIMessageManager.MessageType.Default){
				GUI.Label(new Rect(Screen.width/2 - 125, Screen.height/2 + 125, 250f, 50f), messageText, Style1);
			}
			else if(messageType == GUIMessageManager.MessageType.IntroSequence){
				GUI.Label(new Rect(Screen.width/2 - 100, Screen.height/2 - 100, 200f, 200f), messageText, Style2);
			}
		}
	}
}
