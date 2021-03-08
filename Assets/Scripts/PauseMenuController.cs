using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour {
    public Text txtMusicVolume;
    public Text txtSFXVolume;
	// Use this for initialization
	void Start () {
        txtMusicVolume = this.gameObject.GetComponent<RectTransform>().GetChild(1).GetComponent<Text>();
        txtSFXVolume = this.gameObject.GetComponent<RectTransform>().GetChild(2).GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        txtMusicVolume.text = ""+this.transform.parent.GetComponent<OptionsController>().volume_Music+"%";
        txtSFXVolume.text = "" + this.transform.parent.GetComponent<OptionsController>().volume_SFX + "%";
    }
}
