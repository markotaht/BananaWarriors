using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("COLL");
        if(other.gameObject.tag == "Player")
        {
            if(this.gameObject.tag == "GreenBanana" )
            {

             //   Debug.Log("GoldenBanana korjati üles, aga vist implementatsiooni ei ole et elusid suurendada :/");
            }
            Destroy(this.gameObject);

        }
        //Count


    }

}
