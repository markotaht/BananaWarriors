﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour {
    private float lifeTime;
    private float maxLifeTime = 60.0f;

    private SpriteRenderer spriteRenderer;

    
    void Start () {
        lifeTime = maxLifeTime;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	
	void Update () {
        lifeTime -= Time.deltaTime;

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
            spriteRenderer.color = Color.red;
            Die();
        }
    }

    //returns if the unit was killed
    public bool onHit()
    {
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
        Destroy(gameObject);
    }

}
