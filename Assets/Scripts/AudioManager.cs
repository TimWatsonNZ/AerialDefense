using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioClip gunSound;
    static AudioSource audioSrc;

	// Use this for initialization
	void Start () {
        audioSrc = GetComponent<AudioSource>();
        gunSound = Resources.Load<AudioClip>("gunSound");
    }	
	// Update is called once per frame
	void Update () {
		
	}

    public static void PlayFireSound()
    {
        audioSrc.PlayOneShot(gunSound);
    }
}
