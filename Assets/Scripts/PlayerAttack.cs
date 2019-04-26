using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerAttack : MonoBehaviour {

    private float atkCooldown;
    public float startAtkCooldown;


    public Transform atkPos;
    public float atkRange;

    public LayerMask placeEnemyLayer;

    public int damage;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (atkCooldown <= 0)
        {
            if (Input.GetKeyDown(KeyCode.F) || CrossPlatformInputManager.GetButtonDown ("Fire1"))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(atkPos.position,atkRange,placeEnemyLayer);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                    atkCooldown = startAtkCooldown;
                }
            }
           // atkCooldown = startAtkCooldown;
        }
        else
        {
            atkCooldown -= Time.deltaTime;
        }

	}
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(atkPos.position, atkRange);
    }
}
