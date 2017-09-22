using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
	static public int score = 1000;

	void Awake () {
		//If the ApplePickerHighScore already exists, read it
		if (PlayerPrefs.HasKey ("ApplePickerHighScore")) {
			score = PlayerPrefs.GetInt ("ApplePickerHighScore");
		}
		//Assign the high score to ApplePickerHighScore
		PlayerPrefs.SetInt("ApplePickerHighScore", score);
	}
	
	// Update is called once per frame
	void Update () {
		Text HSText = this.gameObject.GetComponent<Text>();
		HSText.text = "High Score: " + score;
		//Update ApplePickerHighScore in PlayerPrefs if necessary
		if (score > PlayerPrefs.GetInt ("ApplePickerHighScore")) {
			PlayerPrefs.SetInt ("ApplePickerHighScore", score);
		}
	}
}
