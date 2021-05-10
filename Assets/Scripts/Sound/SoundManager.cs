using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
public static SoundManager snd;
private AudioSource audioSrc;
private AudioClip[] vaseSounds;
private int randomSounds;

  
    void Start()
    {
        snd = this;
        audioSrc = GetComponent <AudioSource>();
        vaseSounds = Resources.LoadAll<AudioClip>("vaseSounds");
        
    }

    public void PlayVaseSounds()
    {
        randomSounds = Random.Range(0,2);
        audioSrc.PlayOneShot(vaseSounds[randomSounds]);
    }
}
