using UnityEngine;
using System.Collections;

public class ThrusterMod : MonoBehaviour {
    ParticleSystem thruster;
	// Use this for initialization
	void Start () {
        thruster = gameObject.GetComponent<ParticleSystem>();
	}
	public void SetThrusterSpeed(float speed)
    {
        thruster.startSpeed = speed;
    }
	// Update is called once per frame
	void Update () {
	    
	}
}
