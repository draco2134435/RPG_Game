using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour {
    public AudioClip[] allClips;
    public float[] clipChance;
    public AudioSource aSource;

    public float minPitch = 1.05f;
    public float maxPitch = .95f;
    public float minVolume = .90f;
    public float maxVolume = 1.00f;

    int currentClip = 0;

    void Start()
    {
        if (aSource == null)
        {
            aSource = GetComponent<AudioSource>();
        }
        
        if (allClips.Length != clipChance.Length)
        {
            float[] temp = new float[allClips.Length];
            for (int i = 0; i < Mathf.Min(allClips.Length, clipChance.Length); i++)
            {
                temp[i] = clipChance[i];
            }
        }
    }

    public void setClip(int clipNumber)
    {
        currentClip = clipNumber % allClips.Length;
    }

    public void setPitch (float pitch)
    {
        aSource.pitch = pitch;
    }

    public void setVolume(float volume)
    {
        aSource.volume = volume;
    }

    public void setRandomClip()
    {
        currentClip = Random.Range(0, allClips.Length);
    }

    public void setRandomPitch()
    {
        aSource.pitch = Random.Range(minPitch, maxPitch);
    }

    public void setRandomVolume()
    {
        aSource.volume = Random.Range(minVolume, maxVolume);
    }

    public void playSound()
    {
        aSource.Stop();
        aSource.clip = allClips[currentClip];
        aSource.Play();
    }



    public void playSoundRandom()
    {
        setRandomClip();
        setRandomPitch();
        setRandomVolume();

        playSound();
    }
}
