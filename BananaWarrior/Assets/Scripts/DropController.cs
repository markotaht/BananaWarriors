﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleDrop : MonoBehaviour {

    private const float RATE_GOLDEN = 0.01f;
    private const float RATE_NORMAL = 0.5f;
    public const int DROP_COOLDOWN = 10;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float randomNumber = Random.Range(0f, 1f);

        if(randomNumber < RATE_GOLDEN)
        {
            GameObject goldenBanana = (GameObject)Instantiate(Resources.Load("goldenbanana"),new Vector2(10,10),Quaternion.identity);
            //Instantiate(greenbanana, new Vector2(0, 0), Quaternion.identity);
        }
        else if(randomNumber < RATE_NORMAL)
        {
            GameObject goldenBanana = (GameObject)Instantiate(Resources.Load("greenbanana"));
        }
        StartCoroutine(coolDown());
	}

    IEnumerator coolDown()
    {
        yield return new WaitForSeconds(DROP_COOLDOWN);
    }
}
