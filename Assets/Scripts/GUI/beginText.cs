using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class beginText : MonoBehaviour {

	public GameObject score;
	private float timeRemain = 3f;

	private Text timeUI;

	void Start () {
		timeUI = GetComponent<Text> ();
		timeUI.text = timeRemain.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		timeRemain -= Time.deltaTime;
		timeUI.text = Mathf.RoundToInt (timeRemain).ToString();
		if (timeRemain <= 0) {
			gameObject.SetActive (false);
			score.SetActive (true);
			return;
		}
	}
}
