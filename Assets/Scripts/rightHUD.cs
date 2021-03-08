using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class rightHUD : MonoBehaviour {
    Text textRight;
    GameObject player;
	// Use this for initialization
	void Start () {
        textRight = GetComponent<Text>();
       player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        textRight.text = player.GetComponent<PlayerControler>().Health.ToString();
	}
}
