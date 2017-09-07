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
	public GameObject [] objectsToStop;

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
			ResetPositionForAll ();
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

	void ResetPositionForAll(){
		foreach (GameObject g in objectsToStop) {
			g.GetComponent<ResetPosition>().ResPos();
		}

	}
}
