using UnityEngine;
using System.Collections;

public class LaserFire : MonoBehaviour {
	LineRenderer line;
	bool inRange = false;
	GameObject target;
	// Use this for initialization
	void Start () {
		line = gameObject.GetComponent<LineRenderer> ();//Grabs the line render component
		line.enabled = false;//turns off the line
	}
	
	void FixedUpdate () {

		if(Input.GetButtonDown("Laser")&& inRange &&target != null){//are the targts in range
			line.enabled = true;//turn on the line
			line.SetPosition (0, transform.position);//set the point in frount of the ship
			line.SetPosition (1, target.GetComponent<Rigidbody>().position);//set the end in the target
			GetComponent<AudioSource>().Play();//play laser sound
			target.GetComponent<DroneControler>().Hit(5);//dammage the target
		} 
		else {
			line.enabled = false;//turn off the line render
		}
	}
	void OnTriggerEnter(Collider other){//has anything entered the collider?
		if (other.gameObject.tag == "Enemy") {//is it an enemy?
			inRange=true;//set in range to true
			target = other.gameObject;//set enemy to target
			//print("Enter");
		}
	}
	void OnTriggerExit(Collider other){//has anything exited the collider?
		if (other.gameObject.tag == "Enemy") {//was it an enemy?
			inRange = false;//set in range to false
			target = null;//clear the target
						//print("Left");
				}
		}
}