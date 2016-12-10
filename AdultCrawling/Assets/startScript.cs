using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class startScript : MonoBehaviour {

	// Use this for initialization
	void Start () {


		gameObject.GetComponent<Button> ().onClick.AddListener (TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void TaskOnClick() {
		GameObject.Find ("/Canvas/Timer").GetComponent<Timer> ().startTimimg ();
		GameObject.Find ("Player").GetComponent<playerMovement> ().StartPlaying ();
		Destroy (gameObject);
	}

}
