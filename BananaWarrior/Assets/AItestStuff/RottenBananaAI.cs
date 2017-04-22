using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RottenBananaAI : MonoBehaviour {
    private int life = 3;
    private bool attacking = false;
    private GameObject toAttack;
    private float sightRange = 30.0f;
    private float attackspeed = 2.0f;
    private float timer;
    private float attackRange = 1.0f;
    private MoveController moveController;

	// Use this for initialization
	void Start () {
        moveController = GetComponent<MoveController>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(toAttack);

        //Attacking
        if (!attacking)
        {
            toAttack = whatToAttack();
            if (toAttack != null)
            {
                attacking = true;
                timer = 0;
            }
        }
        else
        {
            
            timer -= Time.deltaTime;
            if(toAttack != null && Vector3.Distance(transform.position, toAttack.transform.position) > attackRange)
            {
                moveController.move(toAttack.transform.position);
            }
            else if (timer <= 0)
            {
                bool killed = true;
                if (toAttack != null)
                {
                    if (toAttack.tag == "Warrior")
                    {
                        killed = toAttack.GetComponent<BananaWarriorAI>().onHit();
                    }
                    else if (toAttack.tag == "House")
                    {
                        killed = toAttack.GetComponent<HouseController>().onHit();
                    }
                }
                if (killed)
                {
                    attacking = false;
                }
                timer = attackspeed;
            }
        }
        
	}

    //returns if it killed the unit
    public bool onHit()
    {
        life -= 1;
        if(life <= 0)
        {
            Destroy(gameObject);
            Debug.Log("killed");
            return true;
        }
        return false;
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
        Debug.Log(distance);
        if(distance <= sightRange)
            return closest;
        return null;
    }
}
