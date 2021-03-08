using UnityEngine;
using System;
using System.Collections;

public class WeaponsController : MonoBehaviour {

	public GameObject Player;
	public GameObject Missle;//Get missle object
	GameObject[] Pods;
	GameObject[] Drones;
    LineRenderer line;
    AudioSource[] sounds;
    //AudioSource laserSound;
    //AudioSource MissileLockSound;
	public RaycastHit rayHit;
    public float laserDamage = 10;
    public float laserRange = 100000;
	bool fireing;
	bool Pod1=true;
	public int lockedMissiles;
	double lockTimer;
	int DroneLockCount=0;
    int DroneFireCount = 0;
    public float missileLockRange = 2000f;
    GameObject OptionsController;
    // Use this for initialization
    void Start () {
		Pods = GameObject.FindGameObjectsWithTag("MissilePod");
		Drones = GameObject.FindGameObjectsWithTag ("Enemy");
        line = gameObject.GetComponent<LineRenderer>();//Grabs the line render component
        //laserSound = gameObject.GetComponent<AudioSource>();
        //MissileLockSound = gameObject.GetComponent<AudioSource>();
        sounds = GetComponents<AudioSource>();
        OptionsController = GameObject.FindGameObjectWithTag("OptionsController");
    }

	// Update is called once per frame
	void FixedUpdate () {
        sounds[0].volume = (1f * OptionsController.GetComponent<OptionsController>().ReadSFXVolume());
        sounds[1].volume = (0.5f * OptionsController.GetComponent<OptionsController>().ReadSFXVolume());
        Drones = GameObject.FindGameObjectsWithTag ("Enemy");
		/*if (Input.GetButtonDown ("Missle")) {
			GameObject m = (GameObject)Instantiate(Missle,Player.GetComponent<Rigidbody>().position,Player.GetComponent<Rigidbody>().rotation);//make a missle
			m.gameObject.GetComponent<Rigidbody>().velocity = Player.gameObject.GetComponent<Rigidbody>().velocity;//add the players velocity
			//print("Fire Missle");
			}*/
		//print (lockedMissiles);
		if ((Input.GetButton ("Missle"))&&(lockedMissiles<=19)&& !IsInvoking("QueMissles")) {
			Invoke("QueMissles",.33f);

			}
		if ((!Input.GetButton("Missle"))&& (lockedMissiles>=1)&& !IsInvoking("FireMissles")){
            Invoke("FireMissles", .125f);
		}
        
        if (Input.GetButtonDown ("Laser")) {
            Ray laserRay = new Ray(gameObject.transform.position, -transform.up);
            if(Physics.Raycast(laserRay,out rayHit))
            {
                Debug.DrawRay(laserRay.origin, laserRay.direction*1000, Color.red, 10000, true);
                //print(hit.collider.GetComponent<Transform>().position);
                Debug.DrawLine(laserRay.origin, rayHit.collider.GetComponent<Transform>().position, Color.blue, 10000, true);
                if(rayHit.collider.gameObject.tag == "Enemy") {
                    line.enabled = true;//Draw that line!!
                    //laserSound.Play();
                    sounds[0].Play();
                    line.SetPosition(0, GetComponent<Transform>().position);//Set the start point of the line at the ship.
                    line.SetPosition(1, rayHit.collider.GetComponent<Rigidbody>().position);//Set the end point of the line at the ship.
                    rayHit.collider.GetComponent<DroneControler>().Hit(laserDamage);
                    Invoke("TurnOffLaser", .25f);          
                 }
            }
        }
    }

    void TurnOffLaser()
    {
        line.enabled = false;
    }



    void QueMissles(){
        //lockedMissiles++;
        bool oneLock = false;
        int loopsaver = 0;
        while (oneLock == false )//Don't leave untill game gets a lock
        {
            if (loopsaver >= Drones.Length)
            {
                oneLock = true;
            }
            if (DroneLockCount >= Drones.Length)//check to see if the loop is about to go out of bounds
            {
                DroneLockCount = 0;//set the loop back to zero
            }
            if (Drones[DroneLockCount] == null) { print("Null"); }
            else if (Drones[DroneLockCount].GetComponent<DroneControler>().onScreen == true && (Drones[DroneLockCount].GetComponent<DroneControler>().playerDistance <= missileLockRange))//Check to see if the drone is on screen and in range (1000)
            {
                Drones[DroneLockCount].GetComponent<DroneControler>().missilesLockedOn++;//Add one missile to that drone
                oneLock = true;//got one lock and can now leave the loop
                lockedMissiles++;
                sounds[1].Play();
            }

            DroneLockCount++;//Step one drone forward
            //MissileLockSound.Play();

            
            
            loopsaver++;
        }
        
	}

	void FireMissles(){
		GameObject m;
      
            bool firedOneMissile = false;
            if (Pod1) {
                m = (GameObject)Instantiate(Missle, Pods[0].GetComponent<Transform>().position, Player.GetComponent<Rigidbody>().rotation);//make a missle from left pod
                Pod1 = false;
            } else {
                m = (GameObject)Instantiate(Missle, Pods[1].GetComponent<Transform>().position, Player.GetComponent<Rigidbody>().rotation);//make a missle from right pod
                Pod1 = true;
            }
            //GameObject m = (GameObject)Instantiate(Missle,Player.GetComponent<Rigidbody>().position,Player.GetComponent<Rigidbody>().rotation);//make a missle
            //DroneFireCount = 0;//set the loop back to zero
        int loopsaver = 0;
        while (firedOneMissile == false)
            {
            if (loopsaver > 40)
            {
                firedOneMissile = true;
            }
            if (DroneFireCount >= Drones.Length)//check to see if the loop is about to go out of bounds
            {
                DroneFireCount = 0;//set the loop back to zero
            }
            if (Drones[DroneFireCount] != null)
            {
                if (Drones[DroneFireCount].GetComponent<DroneControler>().missilesLockedOn >= 1)
                {
                    m.GetComponent<MissileV2>().target = Drones[DroneFireCount];//give it a target
                    Drones[DroneFireCount].GetComponent<DroneControler>().missilesLockedOn--;
                    firedOneMissile = true;
                }
            }
                DroneFireCount++;
            loopsaver++;
            
            }

            m.gameObject.GetComponent<Rigidbody>().velocity = (Player.gameObject.GetComponent<Rigidbody>().velocity) + (m.transform.forward * 200.0f);//add the players velocity
         
        lockedMissiles--;
        
	}
}
