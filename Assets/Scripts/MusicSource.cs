using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSource : MonoBehaviour {

    public AudioSource GetAudioSource()
    {
        AudioSource audioTrack = GetComponent<AudioSource>();
        return audioTrack;
    }
}
