using UnityEngine;
using System.Collections;

public class Station : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(0f, .125f, 0f,Space.World);
	}
}
