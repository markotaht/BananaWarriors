using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour {
    private PlayerController playerController;
    private SpriteRenderer spriteRenderer;
    
	
	void Start () {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	
	void Update () {

        //Color
        float life = playerController.Life;
        if (life > 50)
        {
            spriteRenderer.color = Color.Lerp(new Color(1, 1, 0, 1), Color.white, (life - 50) / 100 * 2);
        }
        else
        {
            spriteRenderer.color = Color.Lerp(new Color(1, 0.4f, 0, 1), new Color(1, 1, 0, 1), life / 100 * 2);
        }
    }
}
