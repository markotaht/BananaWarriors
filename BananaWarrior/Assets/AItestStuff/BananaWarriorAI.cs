using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaWarriorAI : MonoBehaviour {

    private float fullLife = 20;
    private float lifeforce;
    private bool alive;
    private SpriteRenderer spriteRenderer;
    private float sightRange;

	// Use this for initialization
	void Start () {
        lifeforce = 20.0f;
        alive = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        sightRange = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
        lifeforce -= Time.deltaTime;
        if(lifeforce < fullLife * -0.15)
        {
            Destroy(gameObject);
        }
        else if(lifeforce <= 0.0)
        {
            spriteRenderer.color = Color.red;
            alive = false;
        }
        else if (lifeforce < fullLife * 0.25)
        {
            spriteRenderer.color = new Color(1, 0.25f, 0, 1);
        }
        else if (lifeforce < fullLife * 0.5)
        {
            spriteRenderer.color = new Color(1, 0.5f, 0, 1);
        }
        else if (lifeforce < fullLife * 0.75)
        {
            spriteRenderer.color = new Color(1, 0.75f, 0, 1);
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
}
