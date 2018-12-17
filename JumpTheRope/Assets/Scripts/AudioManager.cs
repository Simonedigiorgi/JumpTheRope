using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    [HideInInspector] public AudioSource source;
    [HideInInspector] public AudioSource musicSource;

    public AudioClip[] clip;

	void Start () {
        source = GetComponent<AudioSource>();
        musicSource = transform.GetChild(0).GetComponent<AudioSource>();
	}
	
    public void PlayAudio(int a)
    {
        source.PlayOneShot(clip[a]);
    }

    public void PlayMusic()
    {
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void IncreasePitch()
    {
        source.pitch = source.pitch + 0.02f;
    }
}
