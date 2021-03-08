using UnityEngine;
using System.Collections;

public class EsacpePodSpawner : MonoBehaviour {
    GameObject[] EscapePodSpawners;
    GameObject[] EscapePodTragets;
    public GameObject EscapePod;
    public int population = 100;
    public int safePopulation = 0;
    public int lostPopulation = 0;
    // Use this for initialization
    void Start () {
	    EscapePodSpawners = GameObject.FindGameObjectsWithTag("PodSpawner");
        EscapePodTragets = GameObject.FindGameObjectsWithTag("PodTarget");
        LaunchPod();
    }
	
	// Update is called once per frame
	void Update () {
        if (population > 0)
        {
            if (!IsInvoking("LaunchPod")) { Invoke("LaunchPod", 15f); }
        }
        /*foreach (GameObject spawner in EscapePodSpawners) { 
            Ray laserRay = new Ray(spawner.transform.position, transform.up);
            Debug.DrawRay(laserRay.origin, laserRay.direction * 10000, Color.green, 10000, true);    
        }*/
    }
    void LaunchPod()
    {
        int pop = Mathf.RoundToInt(Random.Range(1, 9));
        GameObject ePod;
        ePod = (GameObject)Instantiate(EscapePod, EscapePodSpawners[Random.Range(0,EscapePodSpawners.Length-1)].GetComponent<Transform>().position, Quaternion.Euler(-90f,0f,0f));
        ePod.GetComponent<PodController>().escapeTarget = EscapePodTragets[ Mathf.RoundToInt(Random.Range(0,EscapePodTragets.Length-1))];
        if (pop < population)
        { 
            ePod.GetComponent<PodController>().civsOnBoard = pop;
            population -= pop;
        }
        else
        {
            ePod.GetComponent<PodController>().civsOnBoard = population;
            population = 0;
        }
        
        
            

        
        //print("Pod Away!!");
    }

}
