using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour {
    private float lifeTime;
    private float maxLifeTime = 20.0f;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {
        lifeTime = maxLifeTime;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        lifeTime -= Time.deltaTime;
        Debug.Log(lifeTime / maxLifeTime);
        if(lifeTime / maxLifeTime > 0.5)
        {
            spriteRenderer.color = Color.Lerp(Color.yellow, Color.green, (lifeTime / maxLifeTime - 0.5f) * 2);
        }
        else
        {
            spriteRenderer.color = Color.Lerp(Color.red, Color.yellow, (lifeTime / maxLifeTime)*2);
        }
        if (lifeTime <= 0.0)
        {
            spriteRenderer.color = Color.red;
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}
