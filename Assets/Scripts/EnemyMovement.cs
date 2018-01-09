using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float speed = 10f;

	public float dis = 0.05f;

	private Transform target;

	private int waypointIndex = 0;


	// Use this for initialization
	void Start () {
		target = waypoints.points [waypointIndex + 1];
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = target.position - transform.position;

		transform.Translate (dir.normalized * speed * Time.deltaTime, Space.World);

		if ((transform.position - target.position).magnitude <= dis) {
			NextWayPoint ();
		}
	}

	private void NextWayPoint(){
		if (waypointIndex + 2 >= waypoints.points.Length) {
			Destroy (gameObject);
			scoreScript.score++;
			return;
		}
			
		waypointIndex++;
		target = waypoints.points [waypointIndex + 1]; 
	}
}
