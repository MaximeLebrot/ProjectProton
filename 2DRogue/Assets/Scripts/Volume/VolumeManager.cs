using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    public VolumeController[] vcObjects;

    public float CurrentVolumeLevel;
    public float MaxVolumeLevel = 1f;

    void Start()
    {
        vcObjects = FindObjectsOfType<VolumeController>();
        if (CurrentVolumeLevel > MaxVolumeLevel)
        {
            CurrentVolumeLevel = MaxVolumeLevel;
        }

        for (int i = 0; i < vcObjects.Length; i++)
        {
            vcObjects[i].SetAudioLevel(CurrentVolumeLevel);
        }
    }
}
