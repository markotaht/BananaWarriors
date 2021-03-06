﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class HouseController : MonoBehaviour {
    private bool alive = true;
    private float lifeTime;
    private float maxLifeTime = 60.0f;

    private SpriteRenderer spriteRenderer;

    private bool indicator = true;
    
    void Start () {
        lifeTime = maxLifeTime;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	
	void Update () {
        lifeTime -= Time.deltaTime;
        if (!alive)
        {
            return;
        }

        //Color
        if(lifeTime / maxLifeTime > 0.5)
        {
            spriteRenderer.color = Color.Lerp(new Color(1, 1, 0, 1), Color.green, (lifeTime / maxLifeTime - 0.5f) * 2);
        }
        else
        {
            spriteRenderer.color = Color.Lerp(new Color(1, 0.4f, 0, 1), new Color(1, 1, 0, 1), (lifeTime / maxLifeTime)*2);
        }

        //Death
        if (lifeTime <= 0.0)
        {
            Die();
        }
    }

    //returns if the unit was killed
    public bool onHit()
    {
        AudioController.Play("attack");
        lifeTime -= 5;
        if (lifeTime <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    private void Die()
    {
        alive = false;

        AudioController.Play("nDeath");
        GetComponent<Animator>().SetBool("Dead", true);
        GetComponent<SortingGroup>().sortingOrder = -9999;
        Destroy(gameObject, 4);
    }

    public bool isAlive()
    {
        return alive;
    }

    public bool isIndicator()
    {
        return indicator;
    }

    public void setIndicator(bool isIndicator)
    {
        indicator = isIndicator;
    }

}
