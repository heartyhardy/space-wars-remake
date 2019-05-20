using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimation : MonoBehaviour {
    [Header("VFX")]
    [SerializeField] GameObject vfx;
    [SerializeField] float duration = 1f;

    [Header("SFX")]
    [SerializeField] AudioClip sfx;
    [SerializeField] [Range(0f, 1f)] float volume = 1f;

    public GameObject getVFX()
    {
        return vfx;
    }

    public float getDuration()
    {
        return duration;
    }

    public AudioClip getSFX()
    {
        return sfx;
    }

    public float getSfxVolume()
    {
        return volume;
    }
}
