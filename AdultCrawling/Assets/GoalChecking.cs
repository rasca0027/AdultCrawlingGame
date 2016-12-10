using UnityEngine;
using System.Collections;

public class GoalChecking : MonoBehaviour {
	public GameObject timer;

	void OnTriggerEnter(Collider thing) {
		if (thing.name == "Player") {
			// win
			timer.GetComponent<Timer>().stopTiming();
		}
	}
}
