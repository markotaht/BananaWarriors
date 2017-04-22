using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {

    public Vector3 target;

    private SpriteRenderer spriteRenderer;

    public int sortingOrder = 0;
    [SerializeField]
    private float speed = 1.0f;

	// Use this for initialization
	void Start () {
        target = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);
        spriteRenderer.sortingOrder = (int)((transform.position.y- spriteRenderer.bounds.size.y) * -10);
	}

    public void move(Vector3 destination)
    {
        target = destination;
        target.z = 0;
    }

    public void stopMoving()
    {
        target = transform.position;
    }
}
