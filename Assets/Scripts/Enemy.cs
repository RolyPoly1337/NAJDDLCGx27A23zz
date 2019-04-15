using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;
    private float dazedTime;
    public float startDazedTime;
    public float speed;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (dazedTime <= 0)
        {
            speed = 5;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
 
	}
    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        health -= damage;
        Debug.Log("Player hits enemy");
    }
}
