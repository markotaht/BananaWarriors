using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {

    public Vector3 target;

    private Vector3 velocity = Vector3.zero;

    [SerializeField]
    private float speed = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);
	}

    public void move(Vector3 destination)
    {
        target = destination;
        target.z = 0;
    }
}
