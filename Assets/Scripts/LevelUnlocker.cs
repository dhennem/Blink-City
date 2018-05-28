using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlocker : MonoBehaviour {

	public Button level1Button;
	public Button level2Button;
	public Button level3Button;
	public Button level4Button;
	public Button level5Button;
	

	// Use this for initialization
	void Start () {
		PlayerPrefsManager.SetLevel1Lock(1);
		if(PlayerPrefsManager.getLevel1Lock()==1) level1Button.gameObject.SetActive(true);
		if(PlayerPrefsManager.getLevel2Lock()==1) level2Button.gameObject.SetActive(true);
		if(PlayerPrefsManager.getLevel3Lock()==1) level3Button.gameObject.SetActive(true);
		if(PlayerPrefsManager.getLevel4Lock()==1) level4Button.gameObject.SetActive(true);
		if(PlayerPrefsManager.getLevel5Lock()==1) level5Button.gameObject.SetActive(true);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
