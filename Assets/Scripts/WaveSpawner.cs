using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

	[Header("Paramaters")]
	//Total time of lever. If time out, the out point will destroy!
	public float TimeTotal = 100f;

	//Period per waves
	public float timePerWave = 25f;

	//Period spawner
	public float timeSpawnerDis = 2f;

	//Begin show enemys
	public float begin = 5f;

	//Number of enemys per wave
	public int waveNumber = 5;

	[Space]

	[Header("Enemies")]
	public GameObject[] enemies;


	private int timeSpawn = 0;

	private float countdown = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= begin && countdown <= 0) {
			StartCoroutine (SpawnWave ());
			countdown = timePerWave;
			//TODO: Change enemy per wave
			//TODO: Time out

		}
		countdown -= Time.deltaTime;
	}

	IEnumerator SpawnWave(){
		for (int i = 0; i < waveNumber; i++) {
			Spawner (timeSpawn);
			yield return new WaitForSeconds (timeSpawnerDis); 
		}
		CountinueWave ();
	}


	private void Spawner(int timeSpawn){
		Instantiate (enemies [timeSpawn], transform.position, transform.rotation);
	}


	private void CountinueWave(){
		if (timeSpawn + 1 >= enemies.Length) {
			//TODO: Win
			return;
		}

		timeSpawn++;
	}
}
