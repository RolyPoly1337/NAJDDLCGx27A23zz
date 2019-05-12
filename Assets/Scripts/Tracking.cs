using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour {
    private Transform whoIsBeingFollowed;
    // Use this for initialization

    void Start()
    {
        whoIsBeingFollowed = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
      
        //speed = daze.speed;
    }

    // Update is called once per frame
    void LateUpdate () {
        gameObject.transform.position = whoIsBeingFollowed.transform.position;


    
    
	}
}
