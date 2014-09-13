﻿using UnityEngine;
using System.Collections;

public class RobotHealthBar : MonoBehaviour {

	public GameObject healthBar;
	public Health robotHealth;
	// Use this for initialization
	void Start () {
		if (tag == "LeftTeam") {
						healthBar = GameObject.Find ("healthBlue");
						robotHealth = GameObject.Find ("Player2").GetComponent<Health> ();
				} else {
						healthBar = GameObject.Find ("healthRed");
						robotHealth = GameObject.Find ("Player4").GetComponent<Health> ();
				}
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.transform.localScale = new Vector3 (0, robotHealth.GetPercentHealth () * 2f, 1);
	}
}
