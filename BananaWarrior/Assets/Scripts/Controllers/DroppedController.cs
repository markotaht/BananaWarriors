using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedController : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    private float maxLifeTime = 40.0f;
    private float lifeTime;

	// Use this for initialization
	void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        lifeTime = maxLifeTime;
    }
	
	// Update is called once per frame
	void Update () {
        lifeTime -= Time.deltaTime;

        //Color
        if (lifeTime / maxLifeTime > 0.5)
        {
            spriteRenderer.color = Color.Lerp(Color.yellow, Color.green, (lifeTime / maxLifeTime - 0.5f) * 2);
        }
        else
        {
            spriteRenderer.color = Color.Lerp(new Color(0.55f, 0.27f, 0.07f, 1), Color.yellow, (lifeTime / maxLifeTime) * 2);
        }

        if(lifeTime / maxLifeTime < 0.6)
        {
            gameObject.tag = "YellowBanana";
        }

        //Death
        if (lifeTime <= 0.0)
        {
            Rot();
        }
    }

    private void Rot()
    {

        GameObject newRottenBanana = (GameObject)Instantiate(Resources.Load("RottenBanana/RottenBanana 1"),
                transform.position,
                 Quaternion.identity);
        Destroy(gameObject);
    }
}
