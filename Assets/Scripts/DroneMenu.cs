using UnityEngine;
using System.Collections;

public class DroneMenu : MonoBehaviour {

    GameObject[] nodes;
    int nodeNumber;
    float randomThrust;

    void Start()
    {
        randomThrust = Random.Range(10, 50);//gives each of the ships a little bit of random speed
        nodes = GameObject.FindGameObjectsWithTag("Node");
        nodeNumber = Mathf.RoundToInt(Random.Range(0, nodes.Length - 1));
    }
    void FixedUpdate()
    {
        float distance = Vector3.Distance(nodes[nodeNumber].GetComponent<Transform>().position, GetComponent<Rigidbody>().position);

            //Finds out how far away form the  the ship is
            transform.LookAt(nodes[nodeNumber].GetComponent<Transform>().position);//Turns the ship to the player
            GetComponent<Rigidbody>().AddForce(transform.forward * ((distance) + randomThrust) * Time.deltaTime);//Starts the ship shooting to the player.


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Node")
        {
            nodeNumber = Mathf.RoundToInt(Random.Range(0, nodes.Length - 1));
        }

    }

}
