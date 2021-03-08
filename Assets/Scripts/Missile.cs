using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	public GameObject Missle;//Get missle object
	public GameObject Player;//Get the player
	bool missleLock = false;//do we have a missle lock?
	GameObject target;//get a target


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetButtonDown("Missle")&& missleLock){//if the missle key is pressed and you have a lock
			GameObject m = (GameObject)Instantiate(Missle,Player.GetComponent<Rigidbody>().position,Player.GetComponent<Rigidbody>().rotation);//make a missle
			m.GetComponent<MissileLock>().target = target;//give it a target
			m.gameObject.GetComponent<Rigidbody>().velocity = Player.gameObject.GetComponent<Rigidbody>().velocity;//add the players velocity
			//print("Fire Missle");
		}
	}
	void OnTriggerEnter(Collider other){//has anything entered the collider?
		if (other.gameObject.tag == "Enemy") {//was it an enemy?
			missleLock=true;//set lock to true
			target = other.gameObject;//set enemy to target
			//print("Enter");
		}
	}
	void OntriggrtStay(Collider other){
		if (other.gameObject.tag == "Enemy")print("Stay");
		}
	void OnTriggerExit(Collider other){//has anything exited the collider?
		if (other.gameObject.tag == "Enemy") {//was it an enemy?
			missleLock=false;//set in lock to false
			target = null;//clear the target
			//print("Left");
		}
	}
}
