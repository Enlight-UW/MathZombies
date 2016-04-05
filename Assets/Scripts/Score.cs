using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	// score of the game
	private int score;
	private Text text;

	// Use this for initialization
	void Start () {
		score = 0;
		text = this.gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Score: " + score;
	}

	// use this to update the score
	public void UpdateScore (int incrementScore) {
		score += incrementScore;
	}
}
