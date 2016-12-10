using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
	
	float timer;
	bool isPlaying;

	void Start() {
		isPlaying = true;
	}


	
	// Update is called once per frame
	void Update () {
		if (isPlaying) {
			timer += Time.deltaTime;
			GetComponent<Text> ().text = timer.ToString ("F2");
		}
	}

	public void stopTiming() {
		isPlaying = false;
	}
}
