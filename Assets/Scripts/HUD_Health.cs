using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD_Health : MonoBehaviour
{
    Text healthHUD;
    GameObject player;
    // Use this for initialization
    void Start()
    {
        healthHUD = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        healthHUD.text = Mathf.RoundToInt(player.GetComponent<PlayerControler>().Health).ToString();
    }
}
