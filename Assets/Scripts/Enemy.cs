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
    private PlayerHealth player;
    public int dmgOfEnemy;
    private EnemyFollowing enemy;
    private GameObject instanceTwo;
    public GameObject dropItem;

    public float knockbackDuration;
    public float knockbackAmount;
    public bool Dazed = false;
    //private EnemyFollowing spd;

    // Use this for initialization
    void Start () {
       ParticleSystem ps = GetComponent<ParticleSystem>();
       player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
      //  spd = gameObject.GetComponent<EnemyFollowing>() as EnemyFollowing;
    }
	
	// Update is called once per frame
	void Update ()
    {
       // spd.speed = speed;
        if (dazedTime <= 0)
        {
            speed = 5;
            Dazed = false;
        }
        else
        {
           // GetComponent<Enemy>();
            speed = 0;
            Dazed = true;
            dazedTime -= Time.deltaTime;
        }
        if (health <= 0)
        {
            instance = Instantiate(powPrefab, transform.position, transform.rotation) as GameObject;
            //instanceTwo = Instantiate(dropItem, transform.position, transform.rotation);

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
     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            player.PlayerTakesDamage(dmgOfEnemy);

            StartCoroutine(player.Knockback(knockbackDuration, knockbackAmount, player.transform.position));
        }
    }



}
