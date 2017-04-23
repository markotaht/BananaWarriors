using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

[RequireComponent (typeof(MoveController))]
[RequireComponent (typeof(InventoryController))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private MoveController mc;
    private float life = 100.0f;
    private bool isWaiting = false;
    public float Life
    {
        get { return life; }
        set { life = value; }
    }

    public MoveController movementController
    {
        get { return mc; }
        set { mc = value; }
    }

    [SerializeField]
    private InventoryController ic;
    public InventoryController inventoryController
    {
        get { return ic; }
        set { ic = value; }
    }

	
	void Start () {

    //    mc = GetComponent<MoveController>();
    //    ic = GetComponent<InventoryController>();
	}
	
	
	void Update () {

	}



    //returns if the unit was killed
    public bool onHit()
    {
        AudioController.Play("attack");
        life -= 5;
        if (life <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    private void Die()
    {
        //End of game

        StartCoroutine(FadeToBlackOverSeconds(4.0f));
        AudioController.Play("gameover");

        movementController.stopMoving();
        GetComponent<SortingGroup>().sortingOrder = -9997;
        GetComponent<Animator>().SetBool("Dead", true);
        StartCoroutine(WaitSeconds(5.0f));


    }
    IEnumerator WaitSeconds(float amount)
    {
        isWaiting = true;
        yield return new WaitForSeconds(5.0f);
        isWaiting = false;

        Application.LoadLevel("Scenes/DeathScreen");
    }
    IEnumerator FadeToBlackOverSeconds(float amountOfSeconds)
    {
        Image blackRect = GameObject.FindGameObjectWithTag("deathScreen").GetComponent<Image>();

        float current = 0.0f;
      //  float speed = 1.0f / (amountOfSeconds);


        // setalpha + crossfadealpha + while loop on VAJALIKUD et asi toimiks:))
        blackRect.canvasRenderer.SetAlpha(0f);
        blackRect.CrossFadeAlpha(1f, amountOfSeconds, false);
        while (current < 1f)

        {
            var color = blackRect.color;
            color.a = current;
   //         Debug.Log(color.a);
            blackRect.color = color;
            current += 0.01f ;

        }
        yield return null;

    }



}
