using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public GameObject hitEffect;
	public float fireSpeed = 50f;

	private GameObject target;


	public void Seek(GameObject _target)
	{
		target = _target;
	}
	
	// Update is called once per frame
	void Update () {
		if(target == null)
		{
			Destroy(gameObject);
			return;
		}


		Vector3 dir = target.transform.position - transform.position;
		float disThisFrame = fireSpeed * Time.deltaTime;

		if(dir.magnitude <= disThisFrame)
		{
			HitEnemy();
			return;
		}

		transform.Translate(dir.normalized * disThisFrame, Space.World);
	}

    private void HitEnemy()	
    {
		GameObject effect = (GameObject) Instantiate(hitEffect, transform.position, transform.rotation);

        Destroy(gameObject);
		Destroy(effect, 2f);
		Destroy(target);
		//TODO: blood loss for enemy

    }

    void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Enemy")
		{
			Destroy(gameObject);
		}
	}
}
