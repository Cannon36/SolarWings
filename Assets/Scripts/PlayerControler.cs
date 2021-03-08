using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class PlayerControler : MonoBehaviour {

	// Use this for initialization

	public float speed = 5000;//the players speed
	float rotateSpeed = 1000;//the speed the player rotates
	public GameObject[] enemys;//set up an array of enimys
	public float Health = 100;//set the players health
	public GameObject explosion;//Pull in the explosion
	public bool dead = false;//is the player dead?
    public float gravity = 0f;
    GameObject[] mainThursters;
    public GameObject cameraHolder;
    GameObject mainCamera;
    AudioSource[] sounds;
    GameObject[] hud_IMGs;
    GameObject[] hud_TXTs;
    GameObject OptionsController;

    Animator animator;
	
	void Start () {
		animator = GetComponent<Animator>();//Grab the animator
        sounds = gameObject.GetComponents<AudioSource>();
        mainThursters = GameObject.FindGameObjectsWithTag("ShipThrusters");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        hud_IMGs = GameObject.FindGameObjectsWithTag("HUD_IMG");
        hud_TXTs = GameObject.FindGameObjectsWithTag("HUD_TXT");
        Physics.gravity = new Vector3(0, -gravity, 0);
        OptionsController = GameObject.FindGameObjectWithTag("OptionsController");
        //enemys= GameObject.FindGameObjectsWithTag("Enemy");
        //print (animator);
    }
	void Update(){
		enemys= GameObject.FindGameObjectsWithTag("Enemy");//fill the enimeys array
		if (enemys.Length <= 0) {//if the array is empty I.E. all of them are dead..
			//Application.LoadLevel (4);//Go to the win level
		}
		//Pauseing/UnPausing the Game


		}

	void FixedUpdate () {
        sounds[0].volume = (0.5f * OptionsController.GetComponent<OptionsController>().ReadSFXVolume());
        sounds[1].volume = (0.5f * OptionsController.GetComponent<OptionsController>().ReadSFXVolume());
        sounds[2].volume = (0.5f * OptionsController.GetComponent<OptionsController>().ReadSFXVolume());
        //print (Health);
        if (Health <= 0 )dead=true;//if the player has no health left....check the method
		//foreach (GameObject enemy in enemys) {
			//Physics.Raycast(rigidbody.position,enemy.gameObject.rigidbody.position,1000);
			//Debug.DrawRay(rigidbody.position,enemy.gameObject.rigidbody.position,Color.red);

		//};

		float moveH = -Input.GetAxis ("Horizontal") * rotateSpeed * Time.deltaTime;//pitch up and down
		float moveV = Input.GetAxis ("Vertical")* rotateSpeed * Time.deltaTime;//yaw right and left
		float thrust = -Input.GetAxis ("Thrust") *speed*Time.deltaTime;//thrust forword
        foreach (GameObject thruster in mainThursters)
        {
            thruster.GetComponent<ThrusterMod>().SetThrusterSpeed(((-Input.GetAxis("Thrust"))*8)+3);
        }
        
        if (-Input.GetAxis("Thrust")>=.75)
        {
            if(mainCamera.GetComponent<Camera>().fieldOfView < 100f)
            {
                mainCamera.GetComponent<Camera>().fieldOfView+=.25f;
            }
            if (mainCamera.GetComponent<Camera>().fieldOfView > 100f && !Input.GetButton("Boost"))
            {
                mainCamera.GetComponent<Camera>().fieldOfView -= .5f;
            }
            if (sounds[2].isPlaying != true)
            { 
                sounds[2].Play();
            }
            sounds[2].pitch = .125f;
        }
        if (Input.GetButton("Boost") && -Input.GetAxis("Thrust") >= .75)
        {
            thrust *= 2f;
            sounds[2].pitch = .25f;

            if (mainCamera.GetComponent<Camera>().fieldOfView < 120f)
            {
                mainCamera.GetComponent<Camera>().fieldOfView += .5f;
            }
            foreach (GameObject thruster in mainThursters)
            {
                thruster.GetComponent<ThrusterMod>().SetThrusterSpeed(((-Input.GetAxis("Thrust")) * 20) + 3);
            }
        }
        if (-Input.GetAxis("Thrust") <= .75 )
        {
            if (mainCamera.GetComponent<Camera>().fieldOfView > 90f)
            {
                mainCamera.GetComponent<Camera>().fieldOfView-=.5f;
            }
            sounds[2].Stop();
        }

        //print(-Input.GetAxis("Thrust"));
        //transform.position=
        //rigidBody.position=

        //Vector3 p = rigidbody.position;
        //print (thrust);



        //p += new Vector3 (moveH, 0, moveV)* speed * Time.deltaTime;

        

		if (Input.GetAxis ("Thrust") < 0f) {//if thrust is less than zero, it's backwords
			GetComponent<Rigidbody>().AddForce (transform.forward * thrust);//apply the thrust
			GetComponent<Rigidbody>().angularDrag = 0.9f;//increase the angular drag
		}
		if (Input.GetAxis ("Thrust") > 0f) {//if thrust is more than zero, it's backwords
			GetComponent<Rigidbody>().drag = 0f;//turn off all drag
			GetComponent<Rigidbody>().angularDrag = 0.5f;
		};
		if (Input.GetAxis ("Thrust") == 0f) {//if thrust is zero
			//rigidbody.AddForce (transform.forward * -thrust);
			GetComponent<Rigidbody>().drag = 0.5f;//Set "normal" drag
			GetComponent<Rigidbody>().angularDrag = 0.5f;//Set "normal" drag
		};
		if (Input.GetAxisRaw ("CutRot")==1) {//if the left thumb is pressed
			GetComponent<Rigidbody>().angularDrag = 2f;//Kill all of the spin
		};


        if (Input.GetButton("Boost") && -Input.GetAxis("Thrust") >= .75)
        {
            animator.SetFloat("Roll", 0);
            animator.SetFloat("Pitch", 0);
            animator.SetFloat("Yaw", 0);
        }
        else
        {
            GetComponent<Rigidbody>().AddTorque(transform.forward * moveH);//apply the pitch
            animator.SetFloat("Roll", moveH);//tell the animation controler
                                             //print (moveH);
            GetComponent<Rigidbody>().AddTorque(transform.right * moveV);//apply the roll
            animator.SetFloat("Pitch", moveV);//tell the animation controler
                                              //print (moveV);
            if (Input.GetButton("YawRight"))
            {//Right yaw pressed
                GetComponent<Rigidbody>().AddTorque(transform.up * rotateSpeed * Time.deltaTime);//apply the Torque
                animator.SetFloat("Yaw", 1);//tell the animation controler
            };
            if (Input.GetButton("YawLeft"))
            {//Leftt yaw pressed
                GetComponent<Rigidbody>().AddTorque(transform.up * -rotateSpeed * Time.deltaTime);//apply the Torque
                animator.SetFloat("Yaw", -1);//tell the animation controler
            };
            if (!Input.GetButton("YawLeft") && !Input.GetButton("YawRight"))
            {//no yaw buttons pressed reset to "normal"
                animator.SetFloat("Yaw", 0);//tell the animation controler
            };
        }
        
		if (Input.GetAxis ("Laser") == 1) {//Leftover dose nothing.....

		};

		//print (Input.GetAxisRaw ("YawLeft") + " , " + Input.GetAxisRaw ("YawRight"));
		//print (rigidbody.position);

	}
	public void LaserHit(float damage){//Handles damage done to the player
		Health -= damage;//damages health
        cameraHolder.gameObject.GetComponent<CameraController>().ShakeCamera();
        FlashHUDRed();
	}
    public void LaserhitSound()
    {
        if (sounds[1].isPlaying != true)
        {
            sounds[1].Play();
        }
    }
	void DestorySelf(){
		dead = true;//set dead to true
		Instantiate(explosion,GetComponent<Rigidbody>().position,GetComponent<Rigidbody>().rotation);//spawn an explosion to hide..
		foreach (Transform childTransform in gameObject.transform) {//loop though all of the child objects....
			//print(childTransform.gameObject);
			if(childTransform.gameObject.name != "Main Camera"){//leave the camera out...
			Destroy(childTransform.gameObject);//Destroy the rest...
			}
		}
		
	}
    void OnCollisionEnter(Collision col)
    {
        //print("test");
        //print(col.relativeVelocity.magnitude);
        LaserHit(col.relativeVelocity.magnitude / 100);
        sounds[0].Play();
    }
    void FlashHUDRed()
    {
        foreach (GameObject hud_img in hud_IMGs)
        {
            hud_img.gameObject.GetComponent<Image>().color = new Color(1f, 0f, 0f, 1f);
        }
        foreach(GameObject hud_txt in hud_TXTs)
        {
            hud_txt.gameObject.GetComponent<Text>().color = new Color(1f, 0f, 0f, 1f);
        }
        if (!IsInvoking("FlashHUDGreen"))
        {
            Invoke("FlashHUDGreen", .75f);
        }
    }
    void FlashHUDGreen()
    {
        foreach (GameObject hud_img in hud_IMGs)
        {
            hud_img.gameObject.GetComponent<Image>().color = new Color(.106f, .86f, .05f, .75f);
        }
        foreach (GameObject hud_txt in hud_TXTs)
        {
            hud_txt.gameObject.GetComponent<Text>().color = new Color(.106f, .86f, .05f, .75f);
        }
    }

}
