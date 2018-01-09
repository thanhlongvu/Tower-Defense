using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour {

	public static int score = 0;
	// Use this for initialization

	private Text text;

	void Start () {
		text = GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () {
		text.text = "SCORES: " + score;
	}
}
