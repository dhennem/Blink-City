using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseDetector : MonoBehaviour {

	public static bool lost = false;

	public enum LoseReason {falling, health, resource};

	public LoseReason loseReason;
	public Image losePanel;

	public Text loseReasonMessage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void UpdateLoseReasonMessage(){
		switch(loseReason){
			case LoseDetector.LoseReason.falling:
				loseReasonMessage.text = "You fell to your death!";
				break;
			case LoseDetector.LoseReason.health:
				loseReasonMessage.text = "You ran out of health!";
				break;
			case LoseDetector.LoseReason.resource:
				loseReasonMessage.text = "One of your resources is depleted!";
				break;
		}
	}

	public void ShowLosePanel(LoseReason reason){
		loseReason = reason;
		UpdateLoseReasonMessage();
		losePanel.gameObject.SetActive(true);
	}
}
