using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerMovement : MonoBehaviour {

	bool isPlaying = false;
	Animator anim;

	void Update()
	{
		if (isPlaying) {
			var x = Input.GetAxis ("Horizontal") * Time.deltaTime * 5.0f;
			var z = Input.GetAxis ("Vertical") * Time.deltaTime * 2.0f;

			transform.Translate (x, 0, z);
		}

		anim = gameObject.GetComponent<Animator> ();
		if (Input.anyKey) {
			anim.SetBool ("walking", true);
			anim.CrossFade ("Walk", 0f);
		} else {
			anim.SetBool ("walking", false);
		}
		Debug.Log (anim.GetBool ("walking"));
	}

	public void StartPlaying() {
		isPlaying = true;
	}

}
