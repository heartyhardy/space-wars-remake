using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackdropScroller : MonoBehaviour {

    [Header("Scrolling Attributes")]
    [SerializeField] float yOffsetSpeed = .01f;

    Material offsetSource;

    private Vector2 offsetVector;

	// Use this for initialization
	void Start () {
        offsetSource = GetComponent<Renderer>().material;
        offsetVector = new Vector2(
                0,
                yOffsetSpeed
            );
	}
	
	// Update is called once per frame
	void Update () {
        offsetSource.mainTextureOffset += offsetVector * Time.deltaTime;
    }
}
