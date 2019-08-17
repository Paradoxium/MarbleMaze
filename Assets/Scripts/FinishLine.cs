using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour {

	ChangeLevel cl = new ChangeLevel ();

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player")){
			Debug.Log ("YOU WIN");
			cl.changeLevel ("StartScreen");
		}
	}
}
