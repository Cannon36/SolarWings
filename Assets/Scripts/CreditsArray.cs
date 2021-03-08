using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreditsArray : MonoBehaviour {
    public string[] text;
    Text textCell;
    public int creditStep = 0;
	// Use this for initialization
	void Start () {
        textCell = GetComponent<Text>();
	    
	}
	
	// Update is called once per frame
	void Update () {
        //print(creditStep);
        if (creditStep >= text.Length) creditStep = text.Length-1;
        if (creditStep < 0) creditStep = 0;
        textCell.text = text[creditStep];
        textCell.text = textCell.text.Replace("\\n", "\n");
	}
    public void CreditStepUp()
    {
        creditStep++;
    }
    public void CreditStepDown()
    {
        creditStep--;
    }
}
