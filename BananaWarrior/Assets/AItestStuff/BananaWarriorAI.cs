using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaWarriorAI : MonoBehaviour {

    private Vector3 patrolPlace;

    private float fullLife = 20.0f;
    private float lifeforce;
    private bool alive = true;

    private MoveController moveController;
    private SpriteRenderer spriteRenderer;

    private float sightRange = 20.0f;
    private bool attacking = false;
    private float attackspeed = 2.0f;
    private float attackRange = 1.0f;

    private GameObject toAttack;
    private float timer;
    
    
    void Start () {
        lifeforce = fullLife;
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveController = GetComponent<MoveController>();
        patrolPlace = transform.position;
	}
	
	
	void Update () {
        lifeforce -= Time.deltaTime;
        if (!alive)
        {
            return;
        }
        //Color
        spriteRenderer.color = Color.Lerp(new Color(0.5f, 0.26f, 0, 1), Color.white, lifeforce / fullLife);

        //Death
        if (lifeforce <= 0.0)
        {
            Die();
        }

        //Attacking
        if (!attacking)
        {
            toAttack = whatToAttack();
            if (toAttack != null)
            {
                moveController.stopMoving();
                attacking = true;
                timer = 0;
            }
            else if(patrolPlace != transform.position)
            {
                moveController.move(patrolPlace);
            }
        }
        else
        {
            timer -= Time.deltaTime;
            if (toAttack != null && Vector2.Distance(transform.position, toAttack.transform.position) > attackRange)
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
                    killed = toAttack.GetComponent<RottenBananaAI>().onHit();
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

    private GameObject whatToAttack()
    {
        GameObject[] rottens;
        rottens = GameObject.FindGameObjectsWithTag("Rotten");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject rot in rottens)
        {
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
        lifeforce -= 5;
        if (lifeforce <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    public bool isAlive()
    {
        return alive;
    }

    private void Die()
    {
        alive = false;
        GetComponent<Animator>().SetBool("Dead", true);
        Destroy(gameObject, 3);
    }

    public void changePatrolPlace(Vector3 newPlace)
    {
        patrolPlace = newPlace;
    }
}
