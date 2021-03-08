using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreditsController : MonoBehaviour {
    int titleStep;
    int rightBoxStep;
    int leftBoxStep;
	// Use this for initialization
	void Start () {
        titleStep = transform.GetChild(2).gameObject.GetComponent<CreditsArray>().creditStep;
        rightBoxStep = transform.GetChild(3).gameObject.GetComponent<CreditsArray>().creditStep;
        leftBoxStep = transform.GetChild(4).gameObject.GetComponent<CreditsArray>().creditStep;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Laser"))
        {
            if (transform.GetChild(2).gameObject.GetComponent<CreditsArray>().creditStep >= 7)
            {
                Application.LoadLevel(0);
            }
            print(titleStep);
            transform.GetChild(2).gameObject.GetComponent<CreditsArray>().CreditStepUp();
            transform.GetChild(3).gameObject.GetComponent<CreditsArray>().CreditStepUp();
            transform.GetChild(4).gameObject.GetComponent<CreditsArray>().CreditStepUp();
            //titleStep++;
            //rightBoxStep++;
            //leftBoxStep++;
        }
        if (Input.GetButtonDown("Missle"))
        {
            transform.GetChild(2).gameObject.GetComponent<CreditsArray>().CreditStepDown();
            transform.GetChild(3).gameObject.GetComponent<CreditsArray>().CreditStepDown();
            transform.GetChild(4).gameObject.GetComponent<CreditsArray>().CreditStepDown();
        }
	
	}
}
