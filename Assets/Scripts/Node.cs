using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	public GameObject weapon;

	private MeshRenderer rend;
	private Color startColor;


	void Start () {
		rend = GetComponent<MeshRenderer>();
		startColor = rend.material.color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseEnter()
	{
		rend.material.color = Color.green;
	}

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}

	void OnMouseDown()
	{
		Instantiate(weapon, transform.position, transform.rotation);
	}

}
