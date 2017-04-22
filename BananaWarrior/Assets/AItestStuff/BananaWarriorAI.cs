using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaWarriorAI : MonoBehaviour {

    private float fullLife = 40.0f;
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
	}
	
	
	void Update () {
        lifeforce -= Time.deltaTime;

        //Color
        spriteRenderer.color = Color.Lerp(Color.red, Color.yellow, lifeforce / fullLife);

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
                attacking = true;
                timer = 0;
            }
        }
        else
        {
            timer -= Time.deltaTime;
            if (toAttack != null && Vector3.Distance(transform.position, toAttack.transform.position) > attackRange)
            {
                moveController.move(toAttack.transform.position);
            }
            else if (timer <= 0)
            {
                bool killed = true;
                if (toAttack != null)
                {
                    killed = toAttack.GetComponent<RottenBananaAI>().onHit();
                }
                if (killed)
                {
                    attacking = false;
                }
                timer = attackspeed;
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
        Destroy(gameObject);
    }
}
