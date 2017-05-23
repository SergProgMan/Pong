using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    public float speed = 30;

	private GameManager gameManager;

	void Start() {
		PushOnStart ();
		GameObject gameManagerObject = GameObject.Find ("GameManager");
	
			if(gameManagerObject != null){
				gameManager = gameManagerObject.GetComponent<GameManager>();
			}
			if(gameManagerObject == null){
				Debug.Log ("Cannot find 'GameManager' script");
			}
		

    }

	void PushOnStart() // Initial Velocity
	{
		GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
	}
    
    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                    float racketHeight) {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.x - racketPos.x) / racketHeight;
    }

    void OnCollisionEnter2D(Collision2D col) {
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider
        
        // Hit the left Racket?
        if (col.gameObject.name == "Racket") {
            // Calculate hit Factor
            float x = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.x);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        // Hit the right Racket?
        if (col.gameObject.name == "RacketAI") {
            // Calculate hit Factor
            float x = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.x);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(x, -1).normalized;
            
            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

		if (col.gameObject.name == "BorderAI") {
			gameManager.AddScoreAI();
			WaitAndResetPos ();
		}

		if (col.gameObject.name == "BorderPlayer") {
			gameManager.AddScorePlayer ();
			WaitAndResetPos ();
		}
    }

	void WaitAndResetPos()
	{
		gameManager.MoveControle ();
		Invoke ("ResetPos", 1.0f);

	}

	void ResetPos(){
		transform.position = new Vector2 (0, 0);
		gameManager.MoveControle ();
		PushOnStart ();
	}
}
