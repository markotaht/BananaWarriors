using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private Image hp;

    [SerializeField]
    private Text yellowBananaText;

    [SerializeField]
    private Text greenBananaText;

    private int counter = 0;

    private int counter2 = 0;

	// Use this for initialization
	void Start () {
        fillAmount = 1.0f;	
	}
	
	// Update is called once per frame
	void Update () {
        handleHP();
        handleText();

	}

    void handleHP()
    {
        hp.fillAmount = fillAmount;
    }

    void handleText()
    {
        handleYellowText();
        handleGreenText();
    }

    void handleYellowText()
    {
        yellowBananaText.text = counter++ + "/" + counter++;
    }
    
    void handleGreenText()
    {
        greenBananaText.text = counter-- + "/" + counter++;
    }
}
