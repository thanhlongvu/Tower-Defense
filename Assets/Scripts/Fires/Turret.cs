using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    [Header("References")]
    public GameObject head;

    public Transform firePoint;

    public Transform shotPoint;

    public GameObject bullet;

    public GameObject shotEffect;


    [Header("Attributions")]
    public float range = 0.01f;

    public float speedTurn = 10f;

    public float fireRate = 0.5f;




    private Transform target = null;

    private float fireCountDown = 0f;
    void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

	
	void Update () {
        if(target != null)
        {
            RotateHead();

            if(fireCountDown <= 0){
                Shot();
                fireCountDown = 1 / fireRate;
            }
            else 
            {
                fireCountDown -= Time.deltaTime;
            }

        }
    }

    private void Shot()
    {
        //Effect 
        GameObject effect = Instantiate(shotEffect, shotPoint.position, shotPoint.rotation);
        Destroy(effect, 0.2f);

        //Bullet
        GameObject bulletObject = (GameObject) Instantiate(bullet, firePoint.position, firePoint.rotation);


        //Get bullet object
        Bullet bulletComponent = bulletObject.GetComponent<Bullet>();
        
        //Set target to bullet object
        bulletComponent.Seek(target.gameObject); 
    }

    private void RotateHead()
    {
        Vector3 dir = target.position - head.transform.position;
            
            //LookRotation(Vector3 forward, Vector3 upwards = Vector3.up): Create a rotation with specified forward and upwards directions
            Quaternion lookRotate = Quaternion.LookRotation(dir);

            //Quaterniton.Lerp()
            Vector3 rotation = Quaternion.Lerp(head.transform.rotation, lookRotate, Time.deltaTime * speedTurn).eulerAngles;

            head.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float nearestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (var enemy in enemies)
        {
           
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if(distanceToEnemy < nearestDistance)
            {
                nearestEnemy = enemy;
                nearestDistance = distanceToEnemy;
            }
            
        }

        if(nearestEnemy != null && nearestDistance < range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }


    //Debug
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, range);

    }
}
