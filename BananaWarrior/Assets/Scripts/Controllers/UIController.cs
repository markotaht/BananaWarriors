using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour {
    [SerializeField]
    private Image hp;

    [SerializeField]
    private Text yellowBananaText;

    [SerializeField]
    private Text greenBananaText;

    [SerializeField]
    private Text goldenBananaText;

    public Text survivalTimer;

    public Button yellowButton;
    public Button greenButton;
    public Button goldenButton;


    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        survivalTimer.text = "Time survived: " + PlayerPrefs.GetFloat("Time");
	}

    public void updateHealth(float life)
    {
        hp.fillAmount = life / 100.0f;
    }

    public void updateYellowBanana(int count, int max, bool active)
    {
        yellowBananaText.text = count + "/" + max;
        yellowButton.interactable = active;
    }

    public void updateGreenBanana(int count, int max, bool active)
    {
        greenBananaText.text = count + "/" + max;
        greenButton.interactable = active;
    }

    public void updateGoldenBanana(int count, int max, bool active)
    {
        goldenBananaText.text = count + "/" + max;
        goldenButton.interactable = active;
    }
}
