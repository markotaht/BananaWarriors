using System;
using UnityEngine;
using UnityEngine.UI;

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
        updateYellowBanana(0, 10, false);
        updateGreenBanana(0, 10, false);
        updateGoldenBanana(0, false);
	}
	
	// Update is called once per frame
	void Update () {
        survivalTimer.text = "Time survived: " + Math.Round(Time.timeSinceLevelLoad,1);
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

    public void updateGoldenBanana(int count, bool active)
    {
        goldenBananaText.text = count.ToString();
        goldenButton.interactable = active;
    }
}
