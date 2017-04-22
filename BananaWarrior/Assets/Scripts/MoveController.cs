using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {

    public Vector3 target;

    private SpriteRenderer renderer;

    public int sortingOrder = 0;
    [SerializeField]
    private float speed = 1.0f;

	// Use this for initialization
	void Start () {
        target = transform.position;
        renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);
        renderer.sortingOrder = (int)((transform.position.y-renderer.bounds.size.y) * -10);
	}

    public void move(Vector3 destination)
    {
        target = destination;
        target.z = 0;
    }
}
