using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChange : MonoBehaviour
{
    private AudioSource audioSour;
    private float musicVolume=1f;
    void Start()
    {
        audioSour = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSour.volume = musicVolume;
    }
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
