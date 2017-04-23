using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowScript : MonoBehaviour {

    [SerializeField]
    private float maxGlow = 2f;

    [SerializeField]
    private float minGlow = 0.3f;

    [SerializeField]
    private float glowStep = 0.01f;
    private bool isGrowing;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float currentHaloStrength = GetComponent<Light>().range;

        if (isGrowing)
        {
            if(currentHaloStrength >= maxGlow)
            {
                isGrowing = !isGrowing;
            }
            else
            {
                GetComponent<Light>().range += glowStep;
            }
        }
        else
        {
            if(currentHaloStrength <= minGlow)
            {
                isGrowing = !isGrowing;
            }
            else
            {
                GetComponent<Light>().range -= glowStep;
            }
        }
        //RenderSettings.haloStrength += 0.01f;

	}
}
