using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TreeController : MonoBehaviour {
    private PlayerController playerController;
    private SpriteRenderer spriteRenderer;
    
	
	void Start () {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	
	void Update ()
    {
        float life = playerController.Life;

        //Death
        if (life <= 0)
        {
            Die();
            return;
        }
        //Color
        if (life > 50)
        {
            spriteRenderer.color = Color.Lerp(new Color(1, 1, 0, 1), Color.white, (life - 50) / 100 * 2);
        }
        else
        {
            spriteRenderer.color = Color.Lerp(new Color(1, 0.4f, 0, 1), new Color(1, 1, 0, 1), life / 100 * 2);
        }
    }

    private void Die()
    {
        GetComponent<SortingGroup>().sortingOrder = -9999;
        GetComponent<Animator>().SetBool("Dead", true);
    }
}
