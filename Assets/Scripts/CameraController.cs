using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	float camRotH;
	float camRotV;
	Quaternion camRotation;
    Vector3 camShake = new Vector3(0,-1,0);
	// Use this for initialization
	void Start () {
		camRotH = Input.GetAxis ("CameraHorizontal") *180;
		camRotV = Input.GetAxis ("CameraVertical") *180;
		camRotation  = Quaternion.Euler(camRotH, camRotV, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
		camRotH = Input.GetAxis ("CameraHorizontal") *180;
		camRotV = Input.GetAxis ("CameraVertical") *180;
		camRotation  = Quaternion.Euler(camRotV, camRotH , 0);
       // if (Input.GetButton("Laser"))
        //{
        //    ShakeCamera();
        //}
       // else { camShake = new Vector3(0,0,0); }
        
        transform.localRotation =camRotation;
        
        transform.localPosition = camShake;
	}
    public void ShakeCamera()
    {
        camRotation *= Quaternion.Euler(Random.Range(-.2f, .2f), Random.Range(-.2f, .2f), Random.Range(-.2f, .2f));
        camShake = new Vector3(Random.Range(-.2f, .2f), Random.Range(-1.2f, -.2f), Random.Range(-.2f, .2f));
        camRotation = Quaternion.Euler(camRotH, camRotV, 0);
        transform.localPosition = camShake;
        //camShake = new Vector3(0, -1, 0);
    }
}