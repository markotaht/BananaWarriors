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

    [SerializeField]
    private Text goldenBananaText;

    [SerializeField]
    private InventoryController inventoryController;


    public Image yellowButton;
    public Image greenButton;
    public Image goldenButton;


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
       
        hp.fillAmount = GetComponent<PlayerController>().Life / 100.0f;
    }

    void handleText()
    {
        handleYellowText();
        handleGreenText();
        handleGoldenText();
    }

    void handleYellowText()
    {
        yellowBananaText.text = inventoryController.YellowBanana + "/" + inventoryController.YELLOWBANANA_MAX;
    }
    
    void handleGreenText()
    {
        greenBananaText.text = inventoryController.GreenBanana + "/" + inventoryController.GREENBANANA_MAX;
    }

    void handleGoldenText()
    {
        goldenBananaText.text = inventoryController.GoldenBanana + "/" + inventoryController.GOLDENBANANA_MAX;
    }
}
