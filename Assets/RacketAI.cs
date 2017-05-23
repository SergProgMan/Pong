﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketAI : MonoBehaviour {

	public float speed = 30;
	public Transform ball;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void FixedUpdate () {
		float x = ball.transform.position.x - transform.position.x;
		if ( x > 4) {
			GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
		}
		if ( x < -4) {
			GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
		}
	}
}
