using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerMovement : MonoBehaviour {

	bool isPlaying = false;


	void Update()
	{
		if (isPlaying) {
			var x = Input.GetAxis ("Horizontal") * Time.deltaTime * 3.0f;
			var z = Input.GetAxis ("Vertical") * Time.deltaTime * 1.0f;

			transform.Translate (x, 0, z);
		}
	}

	public void StartPlaying() {
		isPlaying = true;
	}
}
