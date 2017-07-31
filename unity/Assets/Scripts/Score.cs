using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text text;
	int score;

	// Use this for initialization
	void Start () {
		score = 0;	
	}

	public void AddScore(int score)
	{
		this.score += score;
		text.text = this.score.ToString();
	}

}
