using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;
    private float dazedTime;
    public float startDazedTime;
    public float speed;
    public GameObject powPrefab;
    private GameObject instance;

    // Use this for initialization
    void Start () {
       // ParticleSystem ps = GetComponent<ParticleSystem>();
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
            instance = Instantiate(powPrefab, transform.position, transform.rotation) as GameObject;
            //DestroyImmediate(powPrefab, true);
            //Destroy(this.gameObject);
            //Destroy(gameObject);
            //DestroyImmediate(powPrefab, true);
            //ParticleSystem ps = GetComponent<ParticleSystem>();
            Destroy(this.gameObject);
            Destroy(gameObject);


            //Play Particle
            //ps.Play();
        }
 
	}
    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        health -= damage;
        Debug.Log("Player hits enemy");
        //Instantiate(powPrefab, transform.position,transform.rotation);
    }
}
