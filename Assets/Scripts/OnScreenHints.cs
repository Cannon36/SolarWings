using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnScreenHints : MonoBehaviour {
    public int hintSteps = 0;
    public string[] Hints;
   Text hintBox;
	// Use this for initialization
	void Start () {
        hintBox = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (hintSteps == 17) hintSteps = 14;

        hintBox.text = Hints[hintSteps];

        if (hintSteps == 0 && -Input.GetAxis("Thrust") > 0.5f && !IsInvoking("moreHintStep")) Invoke("moreHintStep", 2);
        if (hintSteps == 1 && Input.GetAxis("Vertical") < -.75 && !IsInvoking("moreHintStep")) Invoke("moreHintStep", 2);
        if (hintSteps == 2 && Input.GetAxis("Vertical") > .75 && !IsInvoking("moreHintStep")) Invoke("moreHintStep", 2);
        if (hintSteps == 3 && Input.GetAxis("Horizontal") > .75 && !IsInvoking("moreHintStep")) Invoke("moreHintStep", 2);
        if (hintSteps == 4 && Input.GetAxis("Horizontal") < -.75 && !IsInvoking("moreHintStep")) Invoke("moreHintStep", 2);
        if (hintSteps == 5 && Input.GetButton("YawLeft") && !IsInvoking("moreHintStep")) Invoke("moreHintStep", 2);
        if (hintSteps == 6 && Input.GetButton("YawRight") && !IsInvoking("moreHintStep")) Invoke("moreHintStep", 2);
        if (hintSteps == 7 && -Input.GetAxis("Thrust") < -0.5f && !IsInvoking("moreHintStep")) Invoke("moreHintStep", 2);
        if (hintSteps == 8 && -Input.GetAxis("Thrust") > 0.5f && Input.GetButton("Boost") && !IsInvoking("moreHintStep")) Invoke("moreHintStep", 2);
        if (hintSteps == 9  && !IsInvoking("moreHintStep")) Invoke("moreHintStep", 6);
        if (hintSteps == 10 && !IsInvoking("moreHintStep")) Invoke("moreHintStep", 6);
        if (hintSteps == 11 && !IsInvoking("moreHintStep")) Invoke("moreHintStep", 6);
        if (hintSteps == 12 && !IsInvoking("moreHintStep")) Invoke("moreHintStep", 6);
        if (hintSteps == 13 && !IsInvoking("moreHintStep")) Invoke("moreHintStep", 6);
        if (hintSteps == 14 && !IsInvoking("moreHintStep")) Invoke("moreHintStep", 6);
        if (hintSteps == 15 && !IsInvoking("moreHintStep")) Invoke("moreHintStep", 6);
        if (hintSteps == 16 && !IsInvoking("moreHintStep")) Invoke("moreHintStep", 6);



    }
    void moreHintStep()
    {
        hintSteps++;
    }
}
