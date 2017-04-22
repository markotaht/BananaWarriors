﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RottenBananaAI : MonoBehaviour {
    private int life;
    private bool attacking;
    private float sightRange;

	// Use this for initialization
	void Start () {
        life = 3;
        attacking = false;
        sightRange = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (!attacking)
        {
            GameObject toAttack = whatToAttack();
            Debug.Log(toAttack);
        }
	}

    public void onHit()
    {
        life -= 1;
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private GameObject whatToAttack()
    {
        GameObject[] houses;
        GameObject[] warriors;
        houses = GameObject.FindGameObjectsWithTag("House");
        warriors = GameObject.FindGameObjectsWithTag("Warrior");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject house in houses)
        {
            Vector3 diff = house.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = house;
                distance = curDistance;
            }
        }
        foreach (GameObject warrior in warriors)
        {
            if(!warrior.GetComponent<BananaWarriorAI>().isAlive())
            {
                continue;
            }
            Vector3 diff = warrior.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = warrior;
                distance = curDistance;
            }
        }
        if(distance <= sightRange)
            return closest;
        return null;
    }
}
