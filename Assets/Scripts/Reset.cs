using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {

	public GameObject player;
	public GameObject startPoint;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		startPoint = GameObject.FindGameObjectWithTag ("Start");
	}

	//when entering the trigger reset players position.
	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			Debug.Log ("Try Again");
			player.transform.position = startPoint.transform.position;
		}

	}
}