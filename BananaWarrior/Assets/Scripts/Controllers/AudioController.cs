using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public AudioClip bananaAttack;
    public AudioClip bananaGoneBad;
    public AudioClip bananaDeath;
    public AudioClip bananaWalk;
    public AudioClip bananaFall;
    public AudioClip gameOver;
    public AudioClip kingBananaDeath;

    private static Dictionary<string, AudioClip> audios;

    public static AudioSource player;

    // Use this for initialization
    void Start () {
        audios = new Dictionary<string, AudioClip>();
        audios.Add("attack", bananaAttack);
        audios.Add("gonebad", bananaGoneBad);
        audios.Add("nDeath", bananaDeath);
        audios.Add("kDeath", kingBananaDeath);
        audios.Add("walk", bananaWalk);
        audios.Add("fall", bananaFall);
        audios.Add("gameover", gameOver);

        player = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*
     * STRINGIDE NIMEKIRI
     * attack - banana Attack
     * gonebad - banana Bad
     * nDeath - banana Death
     * kDeath - king banana Death
     * walk - banana Walk
     * fall - banana Fall
     * 
     * gameover - Game Over
     * */
    public static void Play(string clipToPlay)
    {

        player.PlayOneShot(audios[clipToPlay]);
    }
}
