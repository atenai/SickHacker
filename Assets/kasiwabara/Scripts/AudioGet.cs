using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGet : MonoBehaviour {

    public AudioClip getSE;
    public AudioClip damageSE;
    public AudioClip underSE;
    AudioSource aud;

	// Use this for initialization
	void Start () {
        this.aud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Watch")
        {
            this.aud.PlayOneShot(this.getSE);
        }

        if (other.gameObject.tag == "Teki")
        {
            this.aud.PlayOneShot(this.damageSE);
        }

        if (other.gameObject.tag == "Under")
        {
            this.aud.PlayOneShot(this.underSE);
        }

    }
}
