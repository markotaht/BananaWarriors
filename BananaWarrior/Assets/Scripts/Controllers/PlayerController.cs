using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(MoveController))]
[RequireComponent (typeof(InventoryController))]
public class PlayerController : MonoBehaviour {

    private float life = 100.0f;
    private bool isWaiting = false;

    public float Life
    {
        get { return life; }
        set { life = value; }
    }

    [SerializeField]
    private UIController uic;
    public UIController uiController
    {
        get { return uic; }
        set { uic = value; }
    }

    [SerializeField]
    private MoveController mc;
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
        ic.UIController = uic;
	}
	
	
	void Update () {
       
	}



    //returns if the unit was killed
    public bool onHit()
    {
        AudioController.Play("attack");
        life -= 5;
        uic.updateHealth(life);
        StartCoroutine(Flash());
        if (life <= 0)
        {
            PlayerPrefs.SetFloat("Time", Time.timeSinceLevelLoad);
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

        //Application.LoadLevel("Scenes/DeathScreen");
        SceneManager.LoadScene("Scenes/DeathScreen");
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

    IEnumerator Flash()
    {
        Image hit = GameObject.FindGameObjectWithTag("Hit").GetComponent<Image>();
        hit.enabled = true;
        yield return new WaitForSeconds(0.2f);
        hit.enabled = false;
    }



}
