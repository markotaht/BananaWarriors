using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DeathScreenController : MonoBehaviour {

    public Text time;
    public Text warriors;
    public Text houses;
    public Text bananas;
    public Text golden;
 	// Use this for initialization
	void Start () {
        time.text = time.text + " " + Math.Round((double)PlayerPrefs.GetFloat("Time"), 2);
        warriors.text = warriors.text + " " + PlayerPrefs.GetInt("warriors");
        houses.text = houses.text + " " + PlayerPrefs.GetInt("houses");
        bananas.text = bananas.text + " " + PlayerPrefs.GetInt("bananas");
        golden.text = golden.text + " " + PlayerPrefs.GetInt("Golden");
    }
	
	// Update is called once per frame
	void Update () {
       
    }
}
