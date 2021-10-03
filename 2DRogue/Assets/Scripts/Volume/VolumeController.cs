using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    private AudioSource theAudio;

    private float audioLevel;
    public float defaultAudio;

    void Start()
    {
        theAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        theAudio.volume = audioLevel;
    }

    public void SetAudioLevel(float volume)
    {
        if (theAudio == null)
        {
            theAudio = GetComponent<AudioSource>();
        }
        audioLevel = defaultAudio * volume;
        theAudio.volume = audioLevel;
    }
}
