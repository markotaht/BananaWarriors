using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BananaWarriorAI : MonoBehaviour {

    public Vector3 patrolPlace;

    private float fullLife = 40.0f;
    private float lifeforce;
    private bool alive = true;
    private bool indicator = true;

    private MoveController moveController;
    private SpriteRenderer spriteRenderer;

    private float sightRange = 20.0f;
    private bool attacking = false;
    private float attackspeed = 2.0f;
    private float attackRange = 1.0f;

    private bool middleOfAttacking = false;
    private float attackAnimDuration = 0.45f;
    private float attackAnimCounter;

    private GameObject toAttack;
    private float timer;
    
    
    void Start () {
        lifeforce = fullLife;
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveController = GetComponent<MoveController>();
        patrolPlace = transform.position;
	}
	
	
	void Update () {
        if (isNearaHouse())
        {
            lifeforce -= Time.deltaTime/3;
        }
        else
        {
            lifeforce -= Time.deltaTime;
        }
        if (!alive || indicator)
        {
            return;
        }

        //Color
        spriteRenderer.color = Color.Lerp(new Color(0.5f, 0.26f, 0, 1), Color.white, lifeforce / fullLife);

        //Death
        if (lifeforce <= 0.0)
        {
            Die();
            return;
        }

        //Attacking
        if (middleOfAttacking)
        {
            attackAnimCounter -= Time.deltaTime;
            if (attackAnimCounter <= 0)
            {
                bool killed = true;
                killed = toAttack.GetComponent<RottenBananaAI>().onHit();
                if (killed)
                {
                    attacking = false;
                    toAttack = null;
                }
                timer = attackspeed;
                middleOfAttacking = false;
            }
        }
        else
        {
            if (!attacking)
            {
                toAttack = whatToAttack();
                if (toAttack != null)
                {
                    moveController.stopMoving();
                    attacking = true;
                    timer = 0;
                }
                else if (Vector3.Distance(transform.position, patrolPlace) > 0.01)
                {
                    moveController.move(patrolPlace);
                }
            }
            else
            {
                timer -= Time.deltaTime;
                if (toAttack != null && Vector2.Distance(transform.position, toAttack.transform.position) - 0.1 >= attackRange)
                {
                    float distance = Vector3.Distance(transform.position, toAttack.transform.position) - attackRange;
                    Vector3 direction = (toAttack.transform.position - transform.position).normalized;
                    moveController.move(transform.position + direction * distance);
                }
                else if (timer <= 0)
                {
                    moveController.stopMoving();
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
                        GetComponent<Animator>().SetTrigger("Attack");
                        middleOfAttacking = true;
                        attackAnimCounter = attackAnimDuration;
                    }
                }
                else if (timer > 0 && toAttack == null)
                {
                    moveController.stopMoving();
                }
            }
        }
    }

    private GameObject whatToAttack()
    {
        GameObject[] rottens;
        rottens = GameObject.FindGameObjectsWithTag("Rotten");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject rot in rottens)
        {
            if (!rot.GetComponent<RottenBananaAI>().isAlive())
            {
                continue;
            }
            Vector3 diff = rot.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = rot;
                distance = curDistance;
            }
        }
        if (distance <= sightRange)
            return closest;
        return null;
    }

    //returns if the unit was killed
    public bool onHit()
    {
        AudioController.Play("attack");
        lifeforce -= 5;
        if (lifeforce <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    private void Die()
    {
        AudioController.Play("nDeath");
        alive = false;
        GetComponent<Animator>().SetBool("Dead", true);
        moveController.stopMoving();
        GetComponent<SortingGroup>().sortingOrder = -9998;
        Destroy(gameObject, 3);
    }

    public bool isAlive()
    {
        return alive;
    }
    
    public void changePatrolPlace(Vector3 newPlace)
    {
        patrolPlace = new Vector3(newPlace.x, newPlace.y, 0);
    }

    public bool isIndicator()
    {
        return indicator;
    }

    public void setIndicator(bool isIndicator)
    {
        indicator = isIndicator;
    }

    public bool isNearaHouse()
    {
        GameObject[] houses = GameObject.FindGameObjectsWithTag("House");
        foreach (GameObject house in houses)
        {
            if (house.GetComponent<HouseController>().isAlive() && !house.GetComponent<HouseController>().isIndicator())
            {
                if ((house.transform.position - transform.position).sqrMagnitude <= sightRange)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
