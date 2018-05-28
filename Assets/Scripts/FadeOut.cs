﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {

	static public string nextLevelName;
	public float fadeOutTime;
	static public bool fadingOut;

	private Image panel;
	private Color panelColor;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
		panel = GetComponent<Image>();
		panelColor = Color.black;
		panelColor.a = 0f;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(fadingOut){
			float panelAlphaChange = Mathf.Clamp(Time.deltaTime/fadeOutTime, 0f, 1f);
			panelColor.a += panelAlphaChange;
			panel.color = panelColor;
			if(panelColor.a >= 1f){
				fadingOut = false;
				levelManager.LoadLevel(nextLevelName);
			}
		}
		
	}
}
