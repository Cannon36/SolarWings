using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TopHUD : MonoBehaviour {
    Text topHUD;
    GameObject[] enemys;
    // Use this for initialization
    void Start () {
        topHUD = GetComponent<Text>();
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        topHUD.text = enemys.Length.ToString();
	}
}
