using UnityEngine;
using System.Collections;

public class LaserRayCast : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButtonDown ("Laser")) {
			Vector3 fwd = transform.TransformDirection(Vector3.forward);
			Debug.DrawRay(transform.position,fwd,Color.green);
			if(Physics.Raycast(transform.position,fwd,20)){
				print("Ray Fired and hit somthing");
			}
		}
	}
}
