using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaWarriorAI : MonoBehaviour {

    private float fullLife = 10.0f;
    private float lifeforce;
    private bool alive = true;
    private SpriteRenderer spriteRenderer;
    private float sightRange = 5.0f;
    private bool attacking = false;

	// Use this for initialization
	void Start () {
        lifeforce = fullLife;
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        lifeforce -= Time.deltaTime;

        if (lifeforce <= 0.0)
        {
            StartCoroutine(Die());
        }

        spriteRenderer.color = Color.Lerp(Color.red, Color.yellow, lifeforce / fullLife);
        if (!attacking)
        {
            GameObject toAttack = whatToAttack();
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

    public bool isAlive()
    {
        return alive;
    }

    private IEnumerator Die()
    {
        alive = false;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(fullLife * 0.15f);
        Destroy(gameObject);
    }
}
