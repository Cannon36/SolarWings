using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinScreenControllerAS : MonoBehaviour {
    public GameObject population;
    public GameObject droneSpwanCount;
    public GameObject[] dronesAlive;
    public Text Civ;
    public Text Drone;

    // Use this for initialization
    void Start () {
        Civ = gameObject.GetComponent<RectTransform>().GetChild(0).GetComponent<Text>();
        Drone = gameObject.GetComponent<RectTransform>().GetChild(1).GetComponent<Text>();
        dronesAlive = GameObject.FindGameObjectsWithTag("Enemy");
        Time.timeScale = 0;

    }
	
	// Update is called once per frame
	void Update () {
        dronesAlive = GameObject.FindGameObjectsWithTag("Enemy");
        Civ.text = (100 - population.GetComponent<EsacpePodSpawner>().lostPopulation) + "";
        Drone.text = (droneSpwanCount.GetComponent<ShipSpawner>().spawnNumber - dronesAlive.Length + "/" + droneSpwanCount.GetComponent<ShipSpawner>().spawnNumber);

    }
}
