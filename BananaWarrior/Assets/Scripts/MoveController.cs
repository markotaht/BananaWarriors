using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {

    public Vector3 target;

    private Animator anim;
    int idleHash = Animator.StringToHash("idle");
    int moveHash = Animator.StringToHash("Move");

    private SpriteRenderer spriteRenderer;

    public int sortingOrder = 0;
    [SerializeField]
    private float speed = 2.5f;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        target = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Vector3.Distance(transform.position, target) > 0.01)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            Debug.Log(speed * Time.deltaTime);
            anim.SetFloat("Speed", speed * Time.deltaTime);
        }
        else
        {
            anim.SetFloat("Speed", 0.0f);
        }
        spriteRenderer.sortingOrder = (int)((transform.position.y- spriteRenderer.bounds.size.y) * -10);
	}

    public void move(Vector3 destination)
    {
        target = destination;
        target.z = 0;
        Vector3 scale = transform.localScale;
        if (target.x < transform.position.x)
        {
            scale.x *= scale.x < 0 ? 1 : -1;
        }
        else
        {
            scale.x *= scale.x > 0 ? 1 : -1;
        }
        transform.localScale = scale;
    }

    public void stopMoving()
    {
        target = transform.position;
    }
}
