using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {
    GameObject player;
    public GameObject win;
    public GameObject lose;
    public GameObject[] dronesAlive;
    public GameObject[] escapePods;
    public GameObject population;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        //win = GameObject.FindGameObjectWithTag("win");
        //lose = GameObject.FindGameObjectWithTag("Loss");
        Time.timeScale = 0;
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
        dronesAlive = GameObject.FindGameObjectsWithTag("Enemy");
        escapePods = GameObject.FindGameObjectsWithTag("EscapePod");
        if (player.GetComponent<PlayerControler>().dead)
        {
            lose.SetActive(true);
            player.SetActive(false);
        }
        if(dronesAlive.Length <= 0)
        {
            win.SetActive(true);
            player.SetActive(false);
        }
        if (escapePods.Length <= 0 && population.GetComponent<EsacpePodSpawner>().population <=0)
        {
            win.SetActive(true);
            player.SetActive(false);
        }
	}
    public void LoadMenu()
    {
        Application.LoadLevel(0);
    }
}
