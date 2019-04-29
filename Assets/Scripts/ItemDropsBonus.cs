using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropsBonus : MonoBehaviour {
    private PlayerHealth player;
    public int healthRecover;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            player.HealDamageTaken(healthRecover);


        }
    }
}
