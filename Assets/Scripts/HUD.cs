using UnityEngine;
using System.Collections;
	


public class HUD : MonoBehaviour {

    public GameObject PauseCanvas;
    public GameObject OptionsHolder;
    public GUIButton[] bttns;//The array of buttons for the menu
	public GUIStyle stylePause;	//the GUI Style for the pause menu
    public GUIStyle civTextstyle; //the GUI Style for the pause menu
    public Texture2D imageBG;//pause menu background
	public Texture2D imageBttnBG;//Button selection background
	//float imageBttnX = 220;	
	//public AudioClip sfx1;//end of line beep 
	//public AudioClip sfx2;//the pick a choise bang
	//public AudioClip sfx3;//the switch choise boop

	
	//int index=0;
	//bool keyboardReady = true;//is the keyboard ready? You betcha! oh hold on nope
	
	//bool menuActive = true;//is the menu active, as in woking


	public GameObject player;////grabs the player ship to get it's info
    
	public Texture HudRight;//the texture for the right hud eliment
	public Texture HudLeft;//the texture for the left hud eliment
	int playerHealth;//stores the players health
	public bool paused =false;//is the game paused
	//bool dead =false;//is the player dead

	//Vector2 textureScale;//scale the texeures to look ok in diffrent resoultions

    public GameObject[] EscapePods;



    public Texture tracker;
    public Texture targeted;
    public Texture lockOn;
    public Texture alrtTracker;
    public Texture alrtTargeted;
    public Texture alrtLockOn;
    public Texture warnTracker;
    public Texture warnTargeted;
    public Texture warnLockOn;
    public Texture civLogo;
    GameObject[] enemys;
    AudioSource mainMusic;

	public GUIStyle trackingStyle;//the style for the HUD

	// Use this for initialization
	void Start () {
		paused =false;//Set paused to false
		//bool dead =false;//Set paused to false
		//textureScale = new Vector2 ((float)Screen.width / 1920, (float)Screen.height / 1080);//figure out the amount of txture scale
		//print (textureScale);
		//trackingStyle.fontSize = (int)(190*textureScale.x);//scale the fount too
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        EscapePods = GameObject.FindGameObjectsWithTag("EscapePod");
        mainMusic = GetComponent<AudioSource>();
        //print(enemys.Length);
        
    }
	void OnGUI(){
        EscapePods = GameObject.FindGameObjectsWithTag("EscapePod");
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        mainMusic.volume = (OptionsHolder.GetComponent<OptionsController>().ReadMusicVolume());
        /*
        //player.GetComponent<PlayerControler> ().enemys.Length.ToString ();//How many enemys are alive?
        player.transform.GetChild(0).GetComponent<WeaponsController>().lockedMissiles.ToString();
		playerHealth = Mathf.RoundToInt(player.GetComponent<PlayerControler> ().Health);//update the health from the player
		if (playerHealth <= 0)//is the player dead?
						dead = true;//then make it true
		GUI.DrawTexture (new Rect (Screen.width * HudRPosX, Screen.height * HudRPosY, textureScale.x * HudLeft.width, textureScale.y * HudLeft.height), HudLeft);//postion and draw the left hud eliment
		GUI.DrawTexture (new Rect (Screen.width * HudLPosX, Screen.height * HudLPosY, textureScale.x * HudRight.width, textureScale.y * HudRight.height), HudRight);//postion and draw the right hud eliment
        GUI.Label (new Rect (Screen.width * HudRPosX, Screen.height * HudRPosY, textureScale.x * HudLeft.width, textureScale.y * HudLeft.height), playerHealth.ToString (), style);//postion and draw the Health
        //GUI.Label(new Rect(Screen.width * HudRPosX, Screen.height * HudRPosY, textureScale.x * HudLeft.width, textureScale.y * HudLeft.height), player.transform.GetChild(0).GetComponent<WeaponsController>().lockedMissiles.ToString(), style);
        GUI.Label (new Rect (Screen.width * HudLPosX, Screen.height * HudLPosY, textureScale.x * HudRight.width, textureScale.y * HudRight.height), player.GetComponent<PlayerControler>().enemys.Length.ToString (), style);//postion and draw the number of bag guys left
        */
        if (!paused)
        {
            foreach (GameObject enemy in enemys)
            {

                if (enemy != null)
                {
                    //Vector3 screenpos = GetComponent<Camera>().WorldToScreenPoint(enemy.GetComponent<Transform>().position);
                    Vector3 screenpos = GetComponent<Camera>().WorldToViewportPoint(enemy.GetComponent<Transform>().position);
                    if (screenpos.z > 0 && screenpos.x > 0 && screenpos.x < Screen.width && screenpos.y > 0 && screenpos.y < Screen.height)
                    {
                        enemy.GetComponent<DroneControler>().onScreen = true;

                        //print(screenpos.x+","+screenpos.y+","+screenpos.z);
                        screenpos = new Vector3((screenpos.x * Screen.width), (((screenpos.y - 0) / (1 - 0) * (0 - 1) + 1) * Screen.height), screenpos.z);
                        Rect indicator = new Rect(screenpos.x - 15f, screenpos.y - 15f, 30f, 30f);
                        Rect distance = new Rect(screenpos.x - 20, screenpos.y + 20, 40f, 40f);
                        Rect lockNumber = new Rect(screenpos.x + 15, screenpos.y - 15, 30f, 30f);
                        //Rect indicator = new Rect(20,40, 100f, 100f);
                        ////Alert Hud 
                        if (enemy.GetComponent<DroneControler>().missilesLockedOn > 0 && enemy.GetComponent<DroneControler>().onAlert == true)
                        {
                            GUI.DrawTexture(indicator, alrtLockOn);
                        }
                        else if (enemy.GetComponent<DroneControler>().playerDistance <= player.transform.GetChild(0).GetComponent<WeaponsController>().missileLockRange && enemy.GetComponent<DroneControler>().onAlert == true)
                        {
                            GUI.DrawTexture(indicator, alrtTargeted);
                            enemy.GetComponent<DroneControler>().inRange = true;
                        }
                        else if (enemy.GetComponent<DroneControler>().onAlert == true)
                        {
                            GUI.DrawTexture(indicator, alrtTracker);
                            enemy.GetComponent<DroneControler>().inRange = false;
                        }
                        ////Warning Hud 
                        else if (enemy.GetComponent<DroneControler>().missilesLockedOn > 0 && enemy.GetComponent<DroneControler>().podAlert == true)
                        {
                            GUI.DrawTexture(indicator, warnLockOn);
                        }
                        else if (enemy.GetComponent<DroneControler>().playerDistance <= player.transform.GetChild(0).GetComponent<WeaponsController>().missileLockRange && enemy.GetComponent<DroneControler>().podAlert == true)
                        {
                            GUI.DrawTexture(indicator, warnTargeted);
                            enemy.GetComponent<DroneControler>().inRange = true;
                        }
                        else if (enemy.GetComponent<DroneControler>().podAlert == true)
                        {
                            GUI.DrawTexture(indicator, warnTracker);
                            enemy.GetComponent<DroneControler>().inRange = false;
                        }
                        ////Normal HUD
                        else if (enemy.GetComponent<DroneControler>().missilesLockedOn > 0)
                        {
                            GUI.DrawTexture(indicator, lockOn);
                        }
                        else if (enemy.GetComponent<DroneControler>().playerDistance <= player.transform.GetChild(0).GetComponent<WeaponsController>().missileLockRange)
                        {
                            GUI.DrawTexture(indicator, targeted);
                            enemy.GetComponent<DroneControler>().inRange = true;
                        }
                        else
                        {
                            GUI.DrawTexture(indicator, tracker);
                            enemy.GetComponent<DroneControler>().inRange = false;

                        }
                        GUI.Label(distance, ("" + Mathf.RoundToInt(enemy.GetComponent<DroneControler>().playerDistance)) + "m", trackingStyle);
                        if (enemy.GetComponent<DroneControler>().missilesLockedOn > 1)
                        {
                            GUI.Label(lockNumber, ("" + Mathf.RoundToInt(enemy.GetComponent<DroneControler>().missilesLockedOn)), trackingStyle);
                        }
                    }
                    else { enemy.GetComponent<DroneControler>().onScreen = false; }
                }

            }
            foreach (GameObject escapePod in EscapePods)
            {
                Vector3 screenpos = GetComponent<Camera>().WorldToViewportPoint(escapePod.GetComponent<Transform>().position);

                if (screenpos.z > 0 && screenpos.x > 0 && screenpos.x < Screen.width && screenpos.y > 0 && screenpos.y < Screen.height)
                {
                    screenpos = new Vector3((screenpos.x * Screen.width), (((screenpos.y - 0) / (1 - 0) * (0 - 1) + 1) * Screen.height), screenpos.z);
                    Rect CivIndicator = new Rect(screenpos.x - 10f, screenpos.y - 18f, 20f, 36f);
                    Rect CivCount = new Rect(screenpos.x - 5, screenpos.y, 20f, 36f);
                    Rect CivHealth = new Rect(screenpos.x - 15, screenpos.y - 35, 20f, 36f);
                    GUI.color = new Color(.106f, .88f, .05f, 1f);
                    GUI.DrawTexture(CivIndicator, civLogo);
                    GUI.color = new Color(1f, 1f, 1f, 1f);
                    GUI.Label(CivCount, escapePod.GetComponent<PodController>().civsOnBoard + "", civTextstyle);
                    GUI.Label(CivHealth, "" + Mathf.RoundToInt(escapePod.GetComponent<PodController>().health) + "%", civTextstyle);
                }
            }
        }

        /*
        if (paused || dead) {//if player paused the game or died
						GUI.Label (new Rect (0, 0, 1600, 900), imageBG);//draw the pause background
		
						GUI.Label (new Rect (imageBttnX, 600, 480, 270), imageBttnBG);//draw the pause buttom highlight
		
						foreach (GUIButton bttn in bttns) {//the foreach loop for selecting the buttons
								GUI.SetNextControlName (bttn.name);//sets the name for the button
								GUI.Button (bttn.rect, bttn.img, stylePause);//Draws the button
						}
		
						GUI.FocusControl (bttns [index].name);//Makes the game highlight the button
				}*/
	}
	// Update is called once per frame
	void Update () {
        //print(OptionsScript.TestFunction());
		if (Input.GetButtonDown ("Start")) {//gets "start" or "esc" key press
						//print("Pressed Start");
			if (!paused) {//if unpaused
				Time.timeScale = 0;//pause the game
                PauseCanvas.SetActive(true);
				paused = true;//set pause to true
			} else {//if paused
				Time.timeScale = 1;//unpause the game
                PauseCanvas.SetActive(false);
				paused = false;//set pause to false
			}
		}
        

		//////////////Menu
		/*if(paused || dead){//if paused or dead
		if (!menuActive)return;//and the menu is active
		
			float vert = -Input.GetAxisRaw ("Horizontal");//gets whole numbers of the horizontalaxis
		
			if (vert == 0) {//makes sure that the button is selected before.....
				keyboardReady = true;//letting you change the selection
		} else {
				if (keyboardReady) {//now that we checked the buttons we can change selections
				
					int pre = index;//stores the old selection
				if (vert > 0)
						index--;//selects the previous button
				if (vert < 0)
						index++;//selects the next button
				
					index = Mathf.Clamp (index, 0, bttns.Length-1);//Won't let you select buttons that are not there
				
					AudioSource.PlayClipAtPoint(index == pre ? sfx1:sfx3 ,transform.position);//Play a beep/boop depending on if the selection can or can't change
					keyboardReady = false;//staggers the input so you can actualy cottrol the menu with out it jumping all over the place
			}
		}
			imageBttnX += (bttns[index].rect.x-imageBttnX)*.25f;//makes sure that you can tell what you have sellected by giveing it a highlight
		
			if(Input.GetButtonDown("Laser"))ActivateButton();//Laser ismy "select" button "A" on gamepad / "Space" on keybord 
		
		
	}*/

	}
	/*void ActivateButton(){
		if (menuActive == true) {
			menuActive =false;
			AudioSource.PlayClipAtPoint (sfx2, transform.position);
		}
		SendMessage(bttns[index].func);
	}
	void PressMenu(){
		Application.LoadLevel (0);
	}*/
}
