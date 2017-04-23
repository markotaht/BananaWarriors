using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour {

    private const float RATE_GOLDEN = 0.01f;
    private const float RATE_NORMAL = 0.5f;
    public const int DROP_COOLDOWN = 10;
    public const float MAX_RANGE_FROM_TREE = 10.0f;
    private bool isOnCoolDown;



    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (!isOnCoolDown)
        {
            Vector2 bananaTreeLocation = GameObject.FindGameObjectWithTag("bTree").transform.position;
            int randomAngle = (int) Random.Range(0f, 359f);
     

            float randomNumber = Random.Range(0f, 1f);
            float randomWidth = Random.Range(2, MAX_RANGE_FROM_TREE);
            float randomHeight = Random.Range(2, MAX_RANGE_FROM_TREE);
            Vector3 vec = Quaternion.AngleAxis(randomAngle, Vector3.back) * (Vector3.up * randomWidth);
            Vector2 direction = new Vector2(vec.x, vec.y);
            Vector2 loc = bananaTreeLocation + direction;

            //     Debug.Log(randomWidth + " " + randomHeight);
            if (randomNumber < RATE_GOLDEN)
            {

                GameObject goldenBanana = 
                    (GameObject)Instantiate(Resources.Load("Collectible/goldenbanana"), 
                    loc,
                    Quaternion.identity);
                //Instantiate(greenbanana, new Vector2(0, 0), Quaternion.identity);
            }
            else if (randomNumber < RATE_NORMAL)
            {
                GameObject greenBanana = 
                    (GameObject)Instantiate(Resources.Load("Collectible/greenbanana"),
                    loc,
                    Quaternion.identity);
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
