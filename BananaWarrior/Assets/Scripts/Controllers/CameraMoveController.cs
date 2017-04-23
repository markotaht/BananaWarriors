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
            if (pos.y > 10) pos.y = 10;
        }
        else if(Input.mousePosition.y <= Screen.height * 0.05)
        {
            pos.y -= speed;
            if (pos.y < -10) pos.y = -10;
        }

        if (Input.mousePosition.x >= Screen.width * 0.95)
        {
            pos.x += speed;
            if (pos.x > 10) pos.x = 10;
        }
        else if (Input.mousePosition.x <= Screen.width * 0.05)
        {
            pos.x -= speed;
            if (pos.x < -10) pos.x = -10;
        }

        camera.transform.position = pos;
    }
}
