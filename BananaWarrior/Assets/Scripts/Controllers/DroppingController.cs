using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingController : MonoBehaviour {

    private Vector3 target;
    private Vector3 start;

    public float speed = 2.5f;
    private float startTime;

    private float duration = 1;
	// Use this for initialization
	void Start () {
        start = transform.position;
        startTime = Time.time;
	}

    private void Awake()
    {
        start = transform.position;
        startTime = Time.time;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update () {
        Vector3 center = (start + target) * 0.5f - new Vector3(0,2,0);

        Vector3 startRelC = start - center;
        Vector3 endRelC = target - center;

        float frac = (Time.time - startTime) / duration;
        transform.position = Vector3.Slerp(startRelC, endRelC, frac)+center;

        if(Vector3.Distance(target, transform.position) < 0.1)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
	}

    public void setTarget(Vector3 end)
    {
        target = end;
        duration = Vector3.Distance(start, target) / speed;
    }
}
