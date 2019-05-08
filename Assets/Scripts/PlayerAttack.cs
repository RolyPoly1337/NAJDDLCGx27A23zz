using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerAttack : MonoBehaviour {

    private float atkCooldown;
    public float startAtkCooldown;

    public bool Combo = false;
    public float startComboTime;
    private float comboTime;

    public Transform atkPos;
    public Transform atkPos1;
    public float atkRange;

    public LayerMask placeEnemyLayer;

    public int damage;
    public int defaultDamage;
    public int extraDmgAmount;
    public int extraDmg;

    public GameObject player1;
    public GameObject player2;

  //  private bool buttonAppears = false;
   // public GameObject buttonContinue;
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
                   comboTime = startComboTime;
                    
                }
                //comboTime = startComboTime;
                extraDmgAmount++;

              //  buttonContinue.SetActive(false);
            }
           // atkCooldown = startAtkCooldown;
        }

        if (extraDmgAmount >= 3)
        {
            extraDmgAmount = 2;
            comboTime = 0;
            
        }
        if (extraDmgAmount == 1)
        {
            damage = 10;
        }
       /* if (buttonAppears == true)
        {
            buttonContinue.SetActive(false);
        }
        */
        if (extraDmgAmount == 2 )
        {
            damage = 15;
           
        }
     
        if (extraDmgAmount == 0)
        {
            damage = defaultDamage;

        }

        if (comboTime <= 0)
        {
            
            Combo = false;
            extraDmgAmount = 0;
            comboTime = 0;
        }
        else
        {
            // GetComponent<Enemy>();
            
            Combo = true;

            comboTime -= Time.deltaTime;
        }
       // else
        //{
           // atkCooldown -= Time.deltaTime;
        //}

	}
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(atkPos.position, atkRange);
    }
}
