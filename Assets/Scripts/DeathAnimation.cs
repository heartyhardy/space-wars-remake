using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimation : MonoBehaviour {
    [Header("Animations")]
    [SerializeField] GameObject effect;
    [SerializeField] float duration = 1f;

    public GameObject getEffect()
    {
        return effect;
    }

    public float getDuration()
    {
        return duration;
    }
}
