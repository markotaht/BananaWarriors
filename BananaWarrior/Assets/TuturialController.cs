using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TuturialController : MonoBehaviour {

    int currentTut = 0;
    public Texture2D tut1;
    public Texture2D tut2;
    public Texture2D tut3;
    public Texture2D tut4;
    public Texture2D tut5;
    public Texture2D tut6;

    List<Texture2D> tuts;
    // Use this for initialization
    void Start () {
        tuts = new List<Texture2D>();
        tuts.Add(tut1);
        tuts.Add(tut2);
        tuts.Add(tut3);
        tuts.Add(tut4);
        tuts.Add(tut5);
        tuts.Add(tut6);

    }
	
	// Update is called once per frame
	void Update () {
        //gameObject.GetComponent<Image>().material = tuts[currentTut];
	}

    public void nextButton()
    {
        if (currentTut < 5) currentTut++;
    }

    public void previousButton()
    {
        if (currentTut > 0) currentTut--;
    }
}
