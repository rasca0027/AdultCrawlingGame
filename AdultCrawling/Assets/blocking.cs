using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class blocking : MonoBehaviour {

	bool isMove = true;
	float speed = 1;
	Vector3 targetPosition;
	Vector3 currentPosition;
	Vector3 directionOfTravel ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		targetPosition = GameObject.Find("Player").transform.position; // Get position of object B
		currentPosition = this.transform.position; // Get position of object A
		directionOfTravel = targetPosition - currentPosition;

		if (Vector3.Distance(currentPosition, targetPosition) < 5f && targetPosition.x > currentPosition.x){
			block();
		}

}

	private void block(){
		this.transform.Translate(
			(directionOfTravel.x * speed * Time.deltaTime),
			(directionOfTravel.y * speed * Time.deltaTime),
			(directionOfTravel.z * speed * Time.deltaTime),
			Space.World);
	}
}
