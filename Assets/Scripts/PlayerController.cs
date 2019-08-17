using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*Controlls players movement via physics.
 * applies force in the direction of key press
 * applies breakforce when keypress is the oposite direciton of movement
*/
public class PlayerController : MonoBehaviour {

	public float forceApplied = 20f;
	public float jumpMult = 10f;
	public float boostMult = 5f;
	public Rigidbody rbody;

	private bool grounded = true;
	private float breakForce = 1f;
	private float boost = 1f;
	private float distToGround;



	public void Start (){
		

	}

	//applies forces to the ridged body in the direction of keypress
	void FixedUpdate() {

		//forward & backward
		if (Input.GetKey ("w")) {
			rbody.AddForce (0, 0, ((forceApplied * applyBreak() * boost) * Time.deltaTime));
		} else if (Input.GetKey ("s")) {
			rbody.AddForce (0, 0, ((-forceApplied * applyBreak() * boost) * Time.deltaTime));
		} 

		//right & left
		if (Input.GetKey ("d")) {
			rbody.AddForce ((forceApplied * applyBreak() * boost) * Time.deltaTime, 0, 0);
		} else if (Input.GetKey ("a")) {
			rbody.AddForce ((-forceApplied * applyBreak() * boost) * Time.deltaTime, 0, 0);
		} 

		//jump
		if (Input.GetKey ("space") && isGrounded()) {
			rbody.AddForce (0, (forceApplied * jumpMult) * Time.deltaTime, 0);
		}

		//boost
		if (Input.GetKey (KeyCode.LeftShift)){
			boost = boostMult;
			//Debug.Log ("Boosting!");
		} else {
			boost = 1f;
		}

	}

	/*returns a float to mulitply the force in the oposite direction until moving in intended direction.
	Example: if already moving forward and press the "s" key to move backwards, the breakforce is increased until the velocity is increasing
	in the intended direction.*/
	private float applyBreak() {
		if (rbody.velocity.z < 0 && Input.GetKey("w")) {
			//Debug.Log ("Applying forward break force, Velocity Z is less than 0: " + rbody.velocity.z);
			breakForce = 2f;
			return breakForce;
		} else if (rbody.velocity.z > 0 && Input.GetKey("s")) {
			//Debug.Log ("Applying backward break force, Velocity Z is greater than 0: " + rbody.velocity.z);
			breakForce = 2f;
			return breakForce;
		} else if(rbody.velocity.x < 0 && Input.GetKey("d")){
			//Debug.Log ("Applying rightward break force, Velocity x is less than 0: " + rbody.velocity.x);
			breakForce = 1f;
			return breakForce;
		} else if (rbody.velocity.x > 0 && Input.GetKey("a")){
			//Debug.Log ("Applying leftward break force, Velocity x is greater than 0: " + rbody.velocity.x);
			breakForce = 2f;
			return breakForce;
		} else {
			//resets breakforce
			breakForce = 1f;
			//Debug.Log ("No Breakforce applied: " + rbody.velocity.x + " , " + rbody.velocity.z);
			return breakForce;
		}
	}

	//checks to see if ball is on the ground using a raycast.
	private bool isGrounded (){
		distToGround = GetComponent<Collider> ().bounds.extents.y;
		grounded = Physics.Raycast (transform.position, Vector3.down, distToGround + 0.2f);
		return grounded;
	}
}
