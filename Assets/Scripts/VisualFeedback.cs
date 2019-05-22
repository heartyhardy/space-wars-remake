using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualFeedback : MonoBehaviour {

    [Header("On Hit")]
    [SerializeField] GameObject vfxOnHit;
    [SerializeField][Range(.5f,2f)] float duration = 1.0f;

    public void PlayOnHitFeedback()
    {
        GameObject onHitEffect = Instantiate(
                vfxOnHit,
                transform.position,
                Quaternion.identity
            );
        Destroy(onHitEffect, duration);
    }
}
