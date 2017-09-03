using UnityEngine;
using System.Collections;

public class MoveRacket : MonoBehaviour {
    public float speed = 30;

	public Vector2 startPosition;

	void Start(){
		startPosition = transform.position;
	}



    void FixedUpdate () {
        float v = Input.GetAxisRaw("Horizontal");
        
		if (Input.touchCount > 0) {
			Touch touch = Input.touches [0];
			if (touch.position.x < Screen.width / 2) {
				v = -1;
			}
			if (touch.position.x > Screen.width / 2) {
				v = 1;
			}
		}
		Move (v);
    }

	void Move(float v){
		GetComponent<Rigidbody2D>().velocity = new Vector2(v, 0) * speed;
	}

}
