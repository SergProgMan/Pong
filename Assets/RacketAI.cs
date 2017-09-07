using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketAI : MonoBehaviour {

	public float speed = 20;
	public float lerpSpeed = 1f;

	public Transform ball;

	private Rigidbody2D rigidBody;



	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();

	}

	// Update is called once per frame
	void FixedUpdate () {
		float x = ball.transform.position.x - transform.position.x;
		if (x > 1) {
			if (rigidBody.velocity.y < 0) {
				rigidBody.velocity = Vector2.zero;
			}
			rigidBody.velocity = Vector2.Lerp (rigidBody.velocity, Vector2.right * speed, lerpSpeed * Time.deltaTime);
		}
		else if (x < -1) {
			if (rigidBody.velocity.y > 0) {
				rigidBody.velocity = Vector2.zero;
			}
			rigidBody.velocity = Vector2.Lerp (rigidBody.velocity, Vector2.left * speed, lerpSpeed * Time.deltaTime);
		}
	}

}
