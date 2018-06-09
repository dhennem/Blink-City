using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {


	public float fadeInTime;
	public bool hasIntroSequence;
	public IntroSequenceManager intro;

	private Image panel;
	private Color panelColor = Color.black;


	// Use this for initialization
	void Start () {
		panel = GetComponent<Image>();
		intro = FindObjectOfType<IntroSequenceManager>();
		gameObject.SetActive(true);
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad < fadeInTime){
			float panelAlphaChange = Time.deltaTime/fadeInTime;
			panelColor.a -= panelAlphaChange;
			panel.color = panelColor;
		} else{
			gameObject.SetActive(false);
			if(hasIntroSequence) intro.BeginIntroSequence();
		}
		
	}
}
