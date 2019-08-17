using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject target;
	public Vector3 offset;

	public Transform ct; 

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player");
		ct = GetComponent<Transform>();
		getOffset ();
	}


	void LateUpdate () {
		ct.position = target.transform.position + offset;
	}

	//sets the offset between the Camera and the Target.
	void getOffset(){
		offset = transform.position - target.transform.position;
	}


}
