using UnityEngine;
using System.Collections;

public class MissileLock : MonoBehaviour {
	public GameObject target;//set up the target
	float timer;//set up a timer
	public Object explosion;//Pull in the explosion

	// Use this for initialization
	void Start () {
		timer = Time.time;//get the time
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void FixedUpdate () {					
		//float distance = Vector3.Distance (target.rigidbody.position, rigidbody.position);
		GetComponent<Rigidbody>().AddForce (transform.forward * 50);//add force to get closer to the target
		//rigidbody.AddTorque (transform.up * 25);
		//if (!target == null)transform.LookAt (target.rigidbody.position);
		if (target == null) {//if the target is gone..
			Destroy (gameObject);//kill the missle
		}
		else {
			transform.LookAt (target.GetComponent<Rigidbody>().position);//makes the missle look at the target
		};
		//print(Time.time-timer);
		if(Time.time-timer > 10){//the missle lives for 10 secounds
			//print("TimedOut");
			Destroy (gameObject);//if it dose not hit any thing before that destroy it's self
		}
	}
	void OnTriggerEnter(Collider other){//has anything entered the collider?
		if (other.gameObject.tag == "Enemy") {//was it an enemy?
			Instantiate(explosion,GetComponent<Rigidbody>().position,GetComponent<Rigidbody>().rotation);//spawn an explosion to hide..
			Destroy(other.gameObject);// the ship dissapering
			Destroy(gameObject);//the missle dissapering
		}
	}
}
