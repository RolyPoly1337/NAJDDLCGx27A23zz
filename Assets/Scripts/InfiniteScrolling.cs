using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScrolling : MonoBehaviour {
    public float speed;
    Vector2 startPos;
    public float newPosition;
    public float scrollOffset;
	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
       //transform.
        newPosition = Mathf.Repeat(Time.time * speed, scrollOffset);
        transform.position = startPos + Vector2.right * newPosition;
        if (newPosition <= 0)
            transform.position = startPos;
	}
}
