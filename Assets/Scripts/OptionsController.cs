using UnityEngine;
using System.Collections;

public class OptionsController : MonoBehaviour {
    public float volume_Music = 75.0f;
    public float volume_SFX = 100f;
    public bool tutorial = true;
	// Use this for initialization
	void Start () {
        volume_Music = 75.0f;
        volume_SFX = 100.0f;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void MainMenu()
    {
        Application.LoadLevel(0);
    }
    public float ReadMusicVolume()
    {
        float outPut = (volume_Music / 100.0f);
        //print(volume_Music + "");
        return outPut;
    }
    public void MusicVolUp()
    {
        if (volume_Music < 105f) volume_Music += 5;
    }
    public void MusicVolDown()
    {
        if (volume_Music > 0f) volume_Music -= 5;
    }

    public float ReadSFXVolume()
    {
        float outPut = (volume_SFX / 100.0f);
        //print(volume_Music + "");
        return outPut;
    }
    public void SFXVolUp()
    {
        if (volume_SFX < 100f) volume_SFX += 5;
    }
    public void SFXVolDown()
    {
        if (volume_SFX > 0f) volume_SFX -= 5;
    }
}
