using UnityEngine;
using System.Collections;

public class DroneControler : MonoBehaviour
{
    public float distanceToShoot = 250;//the distince that the drone is allowed to shoot at the player
    GameObject playerShip;//grabs the player ship to get it's postion and do damage to it
    public GameObject target;
    GameObject[] nodes;
    int nodeNumber;
    public GameObject explosion;//grabs the explosion to hide the ships being destroyed
    public GameObject playerTarget;
    //float randomThrust;
    public bool onAlert = false;
    public bool podAlert = false;
    public bool warning = false;
    GameObject[] escapePods;
    public float podEngageRange = 10000;
    GameObject populationController;

    LineRenderer line;
    public float Health = 100;
    public int missilesLockedOn = 0;
    public bool onScreen = false;
    public bool inRange = false;
    public float playerDistance;
    public float laserDamage = 5f;
    public float podLaserDamage = 3f;
    public float podDistanceToShoot = 300f;
    bool drawLaser = false;
    // Use this for initialization
    void Start()
    {
        populationController = GameObject.FindGameObjectWithTag("PopulationControler");
        //randomThrust = Random.Range(10, 50);//gives each of the ships a little bit of random speed
        playerShip = GameObject.FindWithTag("Player");//Actualy grabs the player in the world..
        playerTarget = GameObject.FindGameObjectWithTag("PlayerTarget");
        nodes = GameObject.FindGameObjectsWithTag("Node");
        escapePods = GameObject.FindGameObjectsWithTag("EscapePod");
        line = gameObject.GetComponent<LineRenderer>();//Grabs the line render component
        line.enabled = false;//turns off the line
        nodeNumber = Mathf.RoundToInt(Random.Range(0, nodes.Length - 1));
    }

    // Update is called once per frame
    public void Hit(float damage)
    {//when the Drone gets shot this deals with the damage;
        Health -= damage;//Actualy damages the ship
        onAlert = true;
    }
    void DestorySelf()
    {//Makes the ship kill it's self, what a world.....
        Instantiate(explosion, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation);//Spawn the explosion to hide....
        Destroy(gameObject);//The Ship disapering 

    }
    void FixedUpdate()
    {
        if (populationController.GetComponent<EsacpePodSpawner>().population <= 0) podEngageRange = 100000;
        drawLaser = false;
        escapePods = GameObject.FindGameObjectsWithTag("EscapePod");
        if (Health <= 0) DestorySelf();//Checks to see if the ship is dead
        if (playerShip != null)playerDistance = Vector3.Distance(playerShip.GetComponent<Transform>().position, GetComponent<Transform>().position);
        float distance = Vector3.Distance(nodes[nodeNumber].GetComponent<Transform>().position, GetComponent<Rigidbody>().position);
        foreach(GameObject escapePod in escapePods)
        {
            float podDistance = Vector3.Distance(escapePod.GetComponent<Transform>().position, GetComponent<Transform>().position);
            if ( podDistance <= podEngageRange)
            {
                //print("inRangeOfPod");
                podAlert = true;
                target = escapePod;
            }
            if(podDistance <= podDistanceToShoot)
            {
                //print("Fireing Laser");
                drawLaser = true;
                line.enabled = true;//Draw that line!!
                line.SetPosition(0, GetComponent<Rigidbody>().position);//Set the start point of the line at the ship.
                line.SetPosition(1, escapePod.GetComponent<Rigidbody>().position);//Set the end point of the line at the ship.
                escapePod.GetComponent<PodController>().Damage(podLaserDamage * Time.deltaTime);
            }
        }
        if (onAlert == true &&playerShip!=null) {
           //Finds out how far away form the player the ship is
            GetComponent<Rigidbody>().AddForce (transform.forward * ((distance*7))*Time.deltaTime);//Starts the ship shooting to the player.
            //transform.LookAt (playerShip.GetComponent<Rigidbody>().position);//Turns the ship to the player
            transform.LookAt(playerTarget.GetComponent<Transform>().position);
            //print(playerTarget.GetComponent<Transform>().position);
        }
        if (target == null) {
            podAlert = false;
        }
        if(playerShip==null)
        {
            onAlert = false;
        }
        else { 
            if(podAlert==true && onAlert == false)
            {
                GetComponent<Rigidbody>().AddForce(transform.forward * ((distance * 10)) * Time.deltaTime);
                transform.LookAt(target.gameObject.transform.GetChild(0).GetComponent<Transform>().position);
            }
        }
        if (playerDistance >= 10000 && onAlert == true){
            onAlert = false;
            warning = true;}
        if (missilesLockedOn > 0 && playerDistance < 500) onAlert = true;
        if (missilesLockedOn > 0 && playerDistance < 1500 && warning==true) onAlert = true;
        if (onAlert == false && podAlert == false)
        {
            //Finds out how far away form the  the ship is
            transform.LookAt(nodes[nodeNumber].GetComponent<Transform>().position);//Turns the ship to the player
            GetComponent<Rigidbody>().AddForce(transform.forward * ((distance * 8)) * Time.deltaTime);//Starts the ship shooting to the player.
        }
        if (playerDistance <= distanceToShoot)
        {//is the player within shooting range?
            drawLaser = true;
            line.enabled = true;//Draw that line!!
            line.SetPosition(0, GetComponent<Rigidbody>().position);//Set the start point of the line at the ship.
            line.SetPosition(1, playerShip.GetComponent<Rigidbody>().position);//Set the end point of the line at the ship.
            playerShip.GetComponent<PlayerControler>().LaserHit(laserDamage * Time.deltaTime);//Figures out the amount of damage to send to the player class
            playerShip.GetComponent<PlayerControler>().LaserhitSound();
        }
        if(drawLaser == false)
        {
            line.enabled = false;//Turn off the line when done ding damge
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Node")
        {
            nodeNumber = Mathf.RoundToInt(Random.Range(0, nodes.Length - 1));
        }
        /*if (other.gameObject.tag == "Player")
        {
            playerShip.GetComponent<PlayerControler>().LaserHit(20);
            DestorySelf();
        }*/

    }
    void OnCollisionEnter(Collision col)
    {
        //print("test");
        //print(col.relativeVelocity.magnitude);
        Hit(col.relativeVelocity.magnitude / 100);
    }

}
