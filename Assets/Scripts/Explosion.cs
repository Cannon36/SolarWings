using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<ParticleSystem>().IsAlive(true) == false) {//Checks to see if the system is still emitting
			Destroy(gameObject);//then it destroys it's self
		};
	}
}
