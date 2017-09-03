using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Text scoreTextAI;
	public Text scoreTextPlayer;

	public float waitTime;

	private int scoreAI;
	private int scorePlayer;

	bool canMove = true;
	GameObject [] objectsToStop;

	void Start () {
		
		scoreAI = 0;
		scorePlayer = 0;
		UpdateScore ();

		objectsToStop = GameObject.FindGameObjectsWithTag ("toStop");
	}
	
	public void AddScoreAI ()
	{
		scoreAI++;
		UpdateScore ();
	}

	public void AddScorePlayer ()
	{
		scorePlayer++;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreTextAI.text = "" + scoreAI;
		scoreTextPlayer.text = "" + scorePlayer;
	}

	public void MoveControle(){
		if (canMove) {
			canMove = false;
			ResetPosition ();
		} else {
			canMove = true;
		}
		foreach (GameObject g in objectsToStop)
		{
			g.GetComponent<Rigidbody2D> ().simulated = canMove;
		}
	}

	public void WaitAndResetPosition()
	{
		MoveControle ();
		Invoke ("MoveControle", 1f);
	}

	void ResetPosition(){
		foreach (GameObject g in objectsToStop) {
			g.transform.position = g.GetComponent<startPosition>;
		}

	}
}
