using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGUI : MonoBehaviour {

	private Text mText;

	// Use this for initialization
	void Start () {
		mText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

		int score = Score.instance.score;
		string scoreAddZero = score.ToString ("00");
		mText.text = "" + scoreAddZero; 


	}
}
