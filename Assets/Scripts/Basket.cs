using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour {
	public Text scoreGT;
	public int score;
	// Use this for initialization
	void Start () {
		//Find a reference to the ScoreCounter GameObject
		GameObject scoreGO = GameObject.Find("Canvas/ScoreText");
		scoreGT = scoreGO.GetComponent<Text>();
		//Set the starting number of points to 0
		score = 0;
		updateScore ();
	}
	
	// Update is called once per frame
	void Update () {
		//Get the current screen position of the mouse from Input
		Vector3 mousePos2D = Input.mousePosition; //1

		//The Camera's z position sets the how far to push the mouse into 3D
		mousePos2D.z = -Camera.main.transform.position.z; //2

		//Convert the point from 2D screen space into 3D game world space
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D); //3

		//Move the x position of this Basket to the x position of the Mouse
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	}

	void OnCollisionEnter(Collision coll){
		//Find out what hits this basket
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Apple") {
			Destroy (collidedWith);
			//Add points for catching the apple
			score += 100;
			//Convert the score back to a string and display it
			updateScore();

			//Track high score
			if (score > HighScore.score) {
				HighScore.score = score;
			}
		}
	}

	void updateScore(){
		scoreGT.text = "Your Score: " + score.ToString ();
	}
}
