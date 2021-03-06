﻿using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float currentHealth;
	public float maxHealth;
	public float damageReductionPercent; // goes from 0-1. 1 being 100% damage reduction
	public bool dead = false;
	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Ground")
						return;
		if(!dead)
		if (collision.relativeVelocity.magnitude > 2) {
			print (collision.relativeVelocity.magnitude);
			Damage (collision.relativeVelocity.magnitude/5f);
		}
		
	}

	public float GetPercentHealth(){
		return currentHealth / maxHealth;
	}

	public void Die(){	
		string top = "";
		string bottom = name;
		if (name == "Player2") {
						top = "Player1";
				} else if (name == "Player4") {
			top = "Player3";
				}
		if (top != "") {
			GetComponent<BottomControls>().DisableRobot();
			if(GameObject.Find(top)!=null)
			GameObject.Find (top).GetComponent<TopController>().DisableRobot();
		}
		if (tag == "DetachedTop1") {
			GameObject.FindGameObjectWithTag("DetachedTop1").BroadcastMessage("DisableRobot");
		} else if (tag == "DetachedTop3") {
			GameObject.FindGameObjectWithTag("DetachedTop3").BroadcastMessage("DisableRobot");
		}
		
		if (tag == "LeftBase") {
			GameObject.FindGameObjectWithTag("LeftBase").BroadcastMessage("ExplodeBase");
		} else if (tag == "RightBase") {
			GameObject.FindGameObjectWithTag("RightBase").BroadcastMessage("ExplodeBase");
		}

		if (tag == "Building") {
			BroadcastMessage("blowUp");
		}


	}

	void OnTriggerEnter(Collider other){
		print ("HERE");
	}

	public void IncreaseHealth(float amount){
		currentHealth += amount;
		maxHealth += amount;
	}
	public void Damage(float damage){
		currentHealth-=(damage*(1-damageReductionPercent));
		if (!dead) {
						dead = currentHealth <= 0;
						if (dead)
								Die ();
				}
	}
}
