using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD_POP : MonoBehaviour {


    GameObject populationController;
    Text popHUD;

    // Use this for initialization
    void Start () {
        popHUD = GetComponent<Text>();
        populationController = GameObject.FindGameObjectWithTag("PopulationControler");

    }
	
	// Update is called once per frame
	void Update () {
        popHUD.text = populationController.GetComponent<EsacpePodSpawner>().safePopulation+ " :Safe\n"+populationController.GetComponent<EsacpePodSpawner>().population + " :Station";
    }
}
