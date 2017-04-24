using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RottenBananaAI : MonoBehaviour {
    private bool alive = true;
    private int life = 3;
    private float lifeTime = 30.0f;
    private float sightRange = 30.0f;
    private float attackspeed = 2.0f;
    private float attackRange = 1.0f;

    private MoveController moveController;

    private bool attacking = false;
    private GameObject toAttack;
    private float timer;
    private float patrolTimer = 5;
	
	void Start () {
        moveController = GetComponent<MoveController>();
	}
	

	void Update ()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
        {
            Die();
        }
        if (!alive)
        {
            return;
        }


        //Attacking
        if (!attacking)
        {

            toAttack = whatToAttack();
            if (toAttack != null)
            {
                //patrolTimer = 50;
                attacking = true;
                timer = 0;
            }
            else
            {
                patrolTimer -= Time.deltaTime;
                if (patrolTimer <= 0)
                {
                    int randomAngle = (int)Random.Range(0f, 359f);
                    float randomWidth = Random.Range(2, 20);
                    Vector3 vec = Quaternion.AngleAxis(randomAngle, Vector3.back) * (Vector3.up * randomWidth);
                    Vector2 direction = new Vector2(vec.x, vec.y);
                    Vector2 loc = new Vector2(transform.position.x, transform.position.y) + direction;
                    moveController.move(loc);
                    patrolTimer = 10;
                }
            }
        }
        else
        {
            if(toAttack != null && toAttack.tag == "Player")
            {
                toAttack = whatToAttack();

            }
            timer -= Time.deltaTime;
            if (toAttack != null && Vector3.Distance(transform.position, toAttack.transform.position) - 0.1 >= attackRange)
            {
                float distance = Vector3.Distance(transform.position, toAttack.transform.position) - attackRange;
                Vector3 direction = (toAttack.transform.position - transform.position).normalized;
                moveController.move(transform.position + direction * distance);
            }
            else if (timer <= 0)
            {
                moveController.stopMoving();
                bool killed = true;
                if (toAttack != null)
                {
                    Vector3 scale = transform.localScale;
                    if (toAttack.transform.position.x < transform.position.x)
                    {
                        scale.x *= scale.x < 0 ? 1 : -1;
                    }
                    else
                    {
                        scale.x *= scale.x > 0 ? 1 : -1;
                    }
                    transform.localScale = scale;
                    if (toAttack.tag == "Warrior")
                    {
                        GetComponent<Animator>().SetTrigger("Attack");
                        killed = toAttack.GetComponent<BananaWarriorAI>().onHit();
                    }
                    else if (toAttack.tag == "House")
                    {
                        GetComponent<Animator>().SetTrigger("Attack");
                        killed = toAttack.GetComponent<HouseController>().onHit();
                    }
                    else if (toAttack.tag == "Player")
                    {
                        GetComponent<Animator>().SetTrigger("Attack");
                        killed = toAttack.GetComponent<PlayerController>().onHit();
                    }
                }
                if (killed)
                {
                    attacking = false;
                    toAttack = null;
                }
                timer = attackspeed;
            }
            else if (timer > 0 && toAttack == null)
            {
                moveController.stopMoving();
            }
        }
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
        Vector3 diff;
        float curDistance;
        foreach (GameObject house in houses)
        {
            if (!house.GetComponent<HouseController>().isAlive() || house.GetComponent<HouseController>().isIndicator())
            {
                continue;
            }
            diff = house.transform.position - position;
            curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = house;
                distance = curDistance;
            }
        }
        foreach (GameObject warrior in warriors)
        {
            if (!warrior.GetComponent<BananaWarriorAI>().isAlive() || warrior.GetComponent<BananaWarriorAI>().isIndicator())
            {
                continue;
            }
            diff = warrior.transform.position - position;
            curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = warrior;
                distance = curDistance;
            }
        }
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        diff = player.transform.position - position;
        curDistance = diff.sqrMagnitude;
        if (closest == null || distance > sightRange)
        {
            closest = player;
            distance = curDistance;
        }
        if (distance <= sightRange)
            return closest;
        return null;
    }

    //returns if the unit was killed
    public bool onHit()
    {
        AudioController.Play("attack");
        life -= 1;
        if(life <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    private void Die()
    {
        alive = false;
        moveController.stopMoving();
        AudioController.Play("nDeath");
        GetComponent<SortingGroup>().sortingOrder = -9998;
        GetComponent<Animator>().SetBool("Dead", true);
        Destroy(gameObject, 3);
    }

    public bool isAlive()
    {
        return alive;
    }

}
