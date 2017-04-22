using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    [SerializeField]
    private MoveController currentActor;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hit = Physics2D.OverlapPoint(point);
        //Kuhu klikkisime

        if (Input.GetMouseButton(0))
        {
            if (hit && hit.gameObject.tag == "Player")
            {
                currentActor = hit.gameObject.GetComponent<MoveController>();
            }
            else
            {
                currentActor.move(point);
            }
        }
	}
}
