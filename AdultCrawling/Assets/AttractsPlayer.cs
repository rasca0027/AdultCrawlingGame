using UnityEngine;
using System.Collections;

public class AttractsPlayer : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (player.transform.position, gameObject.transform.position);
		if (distance < 7.0f) {
			Debug.Log ("approaching");
			Vector3 direction = gameObject.transform.position - player.transform.position;
			player.GetComponent<Rigidbody> ().AddForce (direction * 3.0f);
		}
	}	
}
