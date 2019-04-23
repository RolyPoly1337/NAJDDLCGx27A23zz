using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowing : MonoBehaviour {
    public float speed;
    private Transform whoIsBeingFollowed;
	// Use this for initialization
	void Start () {
        whoIsBeingFollowed = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
        transform.position = Vector3.MoveTowards(transform.position,new Vector3(whoIsBeingFollowed.position.x, transform.position.y,whoIsBeingFollowed.position.z),speed*Time.deltaTime);
	}
}
