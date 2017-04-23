using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveController : MonoBehaviour {

    public Camera camera;

    public float speed = 0.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = camera.transform.position;
		if(Input.mousePosition.y >= Screen.height * 0.95)
        {
            pos.y += speed;
        }
        else if(Input.mousePosition.y <= Screen.height * 0.05)
        {
            pos.y -= speed;
        }

        if (Input.mousePosition.x >= Screen.width * 0.95)
        {
            pos.x += speed;
        }
        else if (Input.mousePosition.x <= Screen.width * 0.05)
        {
            pos.x -= speed;
        }

        camera.transform.position = pos;
    }
}
