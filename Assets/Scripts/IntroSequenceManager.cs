using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSequenceManager : MonoBehaviour {

	private GUIMessageManager messager;
	private PlayerController player;
	private string nextText;
	private string[] introSequence = {"3", "2", "1", "Go!", "--"};
	private int introIndex;
	private float currentMessageTimePassed = 0;
	private bool introHappening;
	private bool timeToShowNextMessage;

	static public bool introFinished;

	public AudioClip startSound;
	public GameObject playerArrivalExplosion;

	// Use this for initialization
	void Start () {
		messager = FindObjectOfType<GUIMessageManager>();
		introIndex = 0;
		messager.messageType = GUIMessageManager.MessageType.IntroSequence;
		Platform.winPortalSpawned = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(player == null){
			player = FindObjectOfType<PlayerController>();
			player.GetComponent<SpriteRenderer>().enabled = false;
		}
		if(introHappening && !timeToShowNextMessage){
			currentMessageTimePassed += Time.deltaTime;
			if(currentMessageTimePassed > 1.0f){
				timeToShowNextMessage = true;
			}
		}
		if(introHappening && timeToShowNextMessage){
			UpdateMessager();
		}
		
		
	}

	public void BeginIntroSequence(){
		introHappening = true;
		timeToShowNextMessage = true;


		
	}

	void UpdateMessager(){
		if(introIndex == 3){
			AudioSource.PlayClipAtPoint(startSound, player.transform.position);
		}
		messager.displayNewMessage(introSequence[introIndex]);
		introIndex += 1;
		timeToShowNextMessage = false;
		currentMessageTimePassed = 0.0f;
		if(introIndex >= introSequence.Length){
			EndIntroSequence();
		}
	}

	void ClearMessager(){
		messager.deleteMessage();
	}

	void EndIntroSequence(){
		messager.deleteMessage();
		introHappening = false;
		introFinished = true;
		messager.messageType = GUIMessageManager.MessageType.Default;
		player.GetComponent<SpriteRenderer>().enabled = true;
		Instantiate(playerArrivalExplosion, player.transform.position, Quaternion.identity);
		gameObject.SetActive(false);
		
	}
}
