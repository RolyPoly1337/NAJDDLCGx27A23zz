using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowing : MonoBehaviour {
    public float speed;
    private Transform whoIsBeingFollowed;
    public float stopDistance;
    private Enemy daze;
    // Use this for initialization
    void Start () {
        whoIsBeingFollowed = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        daze = gameObject.GetComponent<Enemy>();
        //speed = daze.speed;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        speed = daze.speed;
        if (Vector2.Distance(transform.position, whoIsBeingFollowed.position) > stopDistance){
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(whoIsBeingFollowed.position.x, transform.position.y, whoIsBeingFollowed.position.z), speed * Time.deltaTime);
            transform.position.Normalize();
            // speed = daze.speed;
            checkPlayerAgain();


        }
        if (daze.Dazed == true)
        {
           speed = 0;

        }
        if (daze.Dazed == false)
        {
            checkPlayerAgain();
            speed = 0;

        }



    }
    public void checkPlayerAgain()
    {
        whoIsBeingFollowed = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

}
