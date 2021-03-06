﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MoveController : MonoBehaviour {

    public Vector3 target;
    private bool stopped = false;
    
    [SerializeField]
    private Animator anim;

    private SpriteRenderer spriteRenderer;
    private SortingGroup sg;

    public int sortingOrder = 0;
    [SerializeField]
    private float speed = 2.5f;

    private float walk_cd = 0.350f;
    private bool onWalkCD;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        target = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        sg = GetComponent<SortingGroup>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!stopped && Vector3.Distance(transform.position, target) > 0.01)
        {
            if (!onWalkCD)
            {
                AudioController.Play("walk");
                StartCoroutine(coolDown());
            }

            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            anim.SetFloat("Speed", 1);
        }
        else
        {
            anim.SetFloat("Speed", 0.0f);
        }
        if(sg.sortingOrder > -9000)
        { 
            sg.sortingOrder = (int)((transform.position.y- spriteRenderer.bounds.size.y) * -10) + sortingOrder;
        }
    }

    IEnumerator coolDown()
    {
        onWalkCD = true;
        yield return new WaitForSeconds(walk_cd);
        onWalkCD = false;
    }

    public void move(Vector3 destination)
    {
        stopped = false;
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
        stopped = true;
        target = transform.position;
    }
}
