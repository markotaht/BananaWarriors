using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour {

    private const float RATE_GOLDEN = 0.01f;
    private const float RATE_NORMAL = 0.5f;
    private const int ONE_DROP_MAX = 10;
    public float DROP_COOLDOWN = 10;
    public const float MAX_RANGE_FROM_TREE = 7.0f;
    private bool isOnCoolDown;

    private int level = 1;

    Vector2 bananaTreeLocation;

    // Use this for initialization
    void Start () {
        bananaTreeLocation = GameObject.FindGameObjectWithTag("bTree").transform.position + Vector3.up * GameObject.FindGameObjectWithTag("bTree").GetComponent<SpriteRenderer>().size.y / 2;
    }

    private void Awake()
    {
        bananaTreeLocation = GameObject.FindGameObjectWithTag("bTree").transform.position + Vector3.up * GameObject.FindGameObjectWithTag("bTree").GetComponent<SpriteRenderer>().size.y / 2;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time / 30 > level)
        {
            level++;
            DROP_COOLDOWN *= 0.9f;
        }
        if (!isOnCoolDown)
        {
            for (int i = 0; i < ONE_DROP_MAX; i++)
            {
                float randomNumber = Random.Range(0f, 1f);
                float randomWidth = Random.Range(0, MAX_RANGE_FROM_TREE*2) * ((Random.Range(0f,1f) > 0.5)?1:-1);
                float randomheight = Random.Range(0, MAX_RANGE_FROM_TREE) * ((Random.Range(0f, 1f) > 0.5) ? 1 : -1);
                Vector2 direction = new Vector2(randomWidth, randomheight);
                Vector2 loc = bananaTreeLocation + direction;
                loc.y -= GameObject.FindGameObjectWithTag("bTree").GetComponent<SpriteRenderer>().size.y / 2;

                //     Debug.Log(randomWidth + " " + randomHeight);
                if (randomNumber < RATE_GOLDEN)
                {

                    GameObject goldenBanana =
                        (GameObject)Instantiate(Resources.Load("Collectible/goldenbanana"),
                        bananaTreeLocation,
                        Quaternion.identity);
                    GameObject.FindGameObjectWithTag("bTree").GetComponent<Animator>().SetTrigger("Spawn");

                    goldenBanana.GetComponent<DroppingController>().setTarget(loc);
                    //Instantiate(greenbanana, new Vector2(0, 0), Quaternion.identity);
                }
                else if (randomNumber < RATE_NORMAL)
                {
                    GameObject greenBanana =
                        (GameObject)Instantiate(Resources.Load("Collectible/greenbanana"),
                        bananaTreeLocation,
                        Quaternion.identity);
                    GameObject.FindGameObjectWithTag("bTree").GetComponent<Animator>().SetTrigger("Spawn");
                    greenBanana.GetComponent<DroppingController>().setTarget(loc);
                }
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
