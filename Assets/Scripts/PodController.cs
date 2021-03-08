using UnityEngine;
using System.Collections;

public class PodController : MonoBehaviour {
    public GameObject escapeTarget;
    public GameObject warpEffect;
    public GameObject explosion;
    public GameObject populationController;
    public int civsOnBoard;
    public float health = 100;
    public float podThruster;
    bool turn = true;
    // Use this for initialization
    void Start () {
        //Invoke("EngageTurn", 0);
        populationController = GameObject.FindGameObjectWithTag("PopulationControler");
    }
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            populationController.GetComponent<EsacpePodSpawner>().lostPopulation += civsOnBoard;
            Instantiate(explosion, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation);
            DestroyPod();
        }
        Ray laserRay = new Ray(transform.position, transform.forward);
        Debug.DrawRay(laserRay.origin, laserRay.direction * 10000, Color.yellow, 1, true);
        //Debug.DrawLine(laserRay.origin,escapeTarget.GetComponent<Transform>().position, Color.blue, 10000, true);
        if (turn) { transform.LookAt(escapeTarget.GetComponent<Transform>().position); }
        GetComponent<Rigidbody>().AddForce(transform.forward * podThruster);
    }
    public void Damage(float damage)
    {
        health -= damage;
    }
    void EngageTurn()
    {
        turn = true;
        //print("Pod Turning");
    }
    public void DestroyPod()
    {
        Destroy(gameObject);
        //Instantiate(warpEffect, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PodTarget")
        {
            //DestroyPod();
            //this.transform.localScale+=new Vector3(0f, 0f, .25f);
            Instantiate(warpEffect, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation);//spawn an explosion to hide..
            populationController.GetComponent<EsacpePodSpawner>().safePopulation += civsOnBoard;
            DestroyPod();
        }
        /*if (other.gameObject.tag == "Player")
        {
            playerShip.GetComponent<PlayerControler>().LaserHit(20);
            DestorySelf();
        }*/

    }
}
