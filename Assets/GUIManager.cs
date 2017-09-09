using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GUIManager : MonoBehaviour {

	public Button pauseButton;
	public Button exitButton;

	bool pause;


	// Use this for initialization
	void Start () {
		Button btnPause = pauseButton.GetComponent<Button> (); 
		Button btnExit = exitButton.GetComponent<Button> (); 

		btnPause.onClick.AddListener (ClickPause);
		btnExit.onClick.AddListener (ClickExit);
	}
	

	void ClickPause () {
		if (pause == false) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	void ClickExit(){
		Application.Quit ();
	}
}
