﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    private const float GOLDENBANANA_HEAL = 0.1f; // 10%

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(this.gameObject.tag == "GreenBanana")
            {
                other.gameObject.GetComponent<InventoryController>().GreenBanana++;
            }
            else if(this.gameObject.tag == "YellowBanana")
            {
                other.gameObject.GetComponent<InventoryController>().YellowBanana++;
            }
            else if (this.gameObject.tag == "GoldenBanana")
            {

           //     if(other.gameObject.GetComponent<InventoryController>().CurrentHP <= 0.9f)
          //      {
          //          other.gameObject.GetComponent<InventoryController>().CurrentHP += GOLDENBANANA_HEAL;
          //      }
         //       Debug.Log("GoldenBanana korjati üles, aga vist implementatsiooni ei ole et elusid suurendada");
            }
            Destroy(this.gameObject);

        }
        //Count


    }

}
