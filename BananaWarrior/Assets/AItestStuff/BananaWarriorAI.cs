using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaWarriorAI : MonoBehaviour {

    private float fullLife = 20;
    private float lifeforce;
    private bool alive;
    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        lifeforce = 20.0F;

        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        lifeforce -= Time.deltaTime;
        if(lifeforce < fullLife * -0.15)
        {
            Destroy(gameObject);
        }
        else if(lifeforce < 0.0)
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
}
