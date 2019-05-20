using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuditoryFeedback : MonoBehaviour {

    [Header("Auditory Feedback")]

    [Header("On Hit")]
    [SerializeField] AudioClip onHit;
    [SerializeField] [Range(1,0)] float on_hit_volume=1f;

    [Header("On Fire")]
    [SerializeField] AudioClip onFire;
    [SerializeField] [Range(1, 0)] float on_fire_volume=1f;


    public void playOnHitFeedback()
    {
        AudioSource.PlayClipAtPoint(
                onHit,
                Camera.main.transform.position,
                on_hit_volume
            );
    }

    public void playOnFireFeedback()
    {
        AudioSource.PlayClipAtPoint(
                onFire,
                Camera.main.transform.position,
                on_fire_volume
            );
    }
}
