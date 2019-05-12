using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAttempt : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (player1.activeSelf == true)
        {
            this.transform.position = player1.transform.position;
        }
        else if (player2.activeSelf == true)
        {
            this.transform.position = player2.transform.position;
        }
    }
}
