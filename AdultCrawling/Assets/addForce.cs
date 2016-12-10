using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addForce : MonoBehaviour {
	public float thrust;
	void Start () {

	}   

	// Update is called once per frame
	void Update () {

	}   
	void OnTriggerEnter() {
		GameObject.Find ("Player").GetComponent<Rigidbody> ().AddForce (transform.forward * thrust);
	}   

}
