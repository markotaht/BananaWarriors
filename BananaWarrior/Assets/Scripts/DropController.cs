using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour {

    private const float RATE_GOLDEN = 0.01f;
    private const float RATE_NORMAL = 0.5f;
    public const int DROP_COOLDOWN = 10;
    private bool isOnCoolDown;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (!isOnCoolDown)
        {
            float randomNumber = Random.Range(0f, 1f);
            float randomWidth = Random.Range(10, Screen.width);
            float randomHeight = Random.Range(10, Screen.height);
            if (randomNumber < RATE_GOLDEN)
            {

                GameObject goldenBanana = (GameObject)Instantiate(Resources.Load("goldenbanana"), new Vector2(randomWidth, randomHeight), Quaternion.identity);
                //Instantiate(greenbanana, new Vector2(0, 0), Quaternion.identity);
            }
            else if (randomNumber < RATE_NORMAL)
            {
                GameObject goldenBanana = (GameObject)Instantiate(Resources.Load("greenbanana"), new Vector2(randomWidth,randomHeight),Quaternion.identity);
            }
            StartCoroutine(coolDown());
        }


    }  

    IEnumerator coolDown()
    {
        isOnCoolDown = true;
        yield return new WaitForSeconds(DROP_COOLDOWN);
        isOnCoolDown = false;
    }
}
