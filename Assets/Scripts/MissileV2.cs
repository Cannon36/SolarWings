using UnityEngine;
using System.Collections;

public class MissileV2 : MonoBehaviour {
	float timer;//set up a timer
	public float turn_speed = .00001f;
    public int damage = 10;
	public GameObject target;
	public Object explosion;//Pull in the explosion
	// Use this for initialization
	void Start () {
		timer = Time.time;//get the time
	}

    // Update is called once per frame
    void FixedUpdate()
    {

        if (target == null) Destroy(gameObject);

        else{
            rotateTowards(target.GetComponent<Rigidbody>().position);
            GetComponent<Rigidbody>().AddForce(transform.forward * 1000);//add force to get closer to the target
                                                                        //transform.LookAt (target.GetComponent<Rigidbody>().position);

            if (Time.time - timer > 10)
            {//the missle lives for 10 secounds
             //print("TimedOut");
                Destroy(gameObject);//if it dose not hit any thing before that destroy it's self
            }
        }
    }
	protected void rotateTowards(Vector3 to) {
		
		Quaternion _lookRotation = 
			Quaternion.LookRotation((to - transform.position).normalized);
		
		//over time
		transform.rotation = 
			Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * turn_speed);
		
		//instant
		transform.rotation = _lookRotation;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Enemy") {
			Instantiate(explosion,GetComponent<Rigidbody>().position,GetComponent<Rigidbody>().rotation);//spawn an explosion to hide..
			other.GetComponent<DroneControler>().Hit(damage);//dammage the target
			Destroy(gameObject);//the missle dissapering
		}
        else if (other.gameObject.tag == "Stactic")
        {
            Instantiate(explosion, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation);//spawn an explosion to hide..
            Destroy(gameObject);//the missle dissapering
        }
	}
}
