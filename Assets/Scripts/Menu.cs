using UnityEngine;
using System.Collections;

[System.Serializable]
public class GUIButton{
	public Rect rect;
	public Texture2D img;
	public string name;
	public string func;
	
}

public class Menu : MonoBehaviour {

	public GUIButton[] bttns;//The array of buttons for the menu
	public GUIStyle style;//Makes the Buttons look goooooood!
	
	public Texture2D imageBG;//The BackGround image for the menu
	public Texture2D imageBttnBG;//The BackGround image for the menu
	float imageBttnX = 220; 
	
	public AudioClip sfx1;//end of line beep
	public AudioClip sfx2;//the pick a choise bang
	public AudioClip sfx3;//the switch choise boop
	
	int index=0;//the index of the button Array
	bool keyboardReady = true;//is the keyboard ready? You betcha! oh hold on nope
	
	bool menuActive = true;//is the menu active, as in woking

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!menuActive)return;//if the menu is not active bail out!
		
		float vert = -Input.GetAxisRaw ("Horizontal");//gets whole number of the horizontal axis
		
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
		
		
	}
	void ActivateButton(){//selcets the button that is currently Higlighted
		if (menuActive == true) {//makes sure you can select things
			menuActive =false;//now that you picked somthing there is no going back
			AudioSource.PlayClipAtPoint (sfx2, transform.position);//Playes the selecting bang sound
		}
		SendMessage(bttns[index].func);//picks from one of the lovely options below....
	}
	void PressPlay1(){//sellecting button for level 1
		Application.LoadLevel (1);//sends you to level 1
	}
	void PressPlay2(){//sellecting button for level 2
		Application.LoadLevel (2);//sends you to level 2
	}
	void PressPlay3(){//sellecting button for level 3
		Application.LoadLevel (3);//sends you to level 3
	}
	void PressCredits(){//sellecting button for Credits
		Application.LoadLevel (5);//sends you to the credits
	}
	
	void OnGUI(){
		
		GUI.Label (new Rect (0, 0, 1600, 900), imageBG);//draws the background image
		
		GUI.Label (new Rect (imageBttnX,600 , 480, 270), imageBttnBG);//actualy draws the button highlight
		
		foreach (GUIButton bttn in bttns) {//the foreach loop for selecting the buttons
			GUI.SetNextControlName(bttn.name);//sets the name for the button
			GUI.Button(bttn.rect,bttn.img,style);//Draws the button
		}
		
		GUI.FocusControl (bttns [index].name);//Makes the game highlight the button
	}
}
