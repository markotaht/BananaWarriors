using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RottenBananaAI : MonoBehaviour {
    private int life = 3;
    private float sightRange = 30.0f;
    private float attackspeed = 2.0f;
    private float attackRange = 1.0f;

    private MoveController moveController;

    private bool attacking = false;
    private GameObject toAttack;
    private float timer;
    
	
	void Start () {
        moveController = GetComponent<MoveController>();
	}
	
	
	void Update () {
        
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
                float distance = Vector3.Distance(transform.position, toAttack.transform.position) - attackRange;
                Vector3 direction = (toAttack.transform.position - transform.position).normalized;
                moveController.move(transform.position + direction*distance);
            }
            else if (timer <= 0)
            {
                moveController.stopMoving();
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
            else if (timer > 0 && toAttack == null)
            {
                moveController.stopMoving();
            }
        }
	}

    //returns if the unit was killed
    public bool onHit()
    {
        life -= 1;
        if(life <= 0)
        {
            Destroy(gameObject);
            return true;
        }
        return false;
    }

    //Chooses the next target
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
