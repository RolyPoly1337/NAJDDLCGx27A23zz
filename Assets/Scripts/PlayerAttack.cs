using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerAttack : MonoBehaviour {

    private float atkCooldown;
    public float startAtkCooldown;
    public Animator anim;

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
    //public int extraDmgAmount1;
    public int extraDmg;

    public GameObject player1;
    public GameObject player2;
    public bool isAttacking = false;

  //  private bool buttonAppears = false;
   // public GameObject buttonContinue;
    // Use this for initialization
    void Start () {
       
	}

    // Update is called once per frame
    void Update()
    {
        
        if (atkCooldown <= 0)
        {
            if (Input.GetKeyDown(KeyCode.F) || CrossPlatformInputManager.GetButtonDown("Fire1"))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(atkPos.position, atkRange, placeEnemyLayer);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                    atkCooldown = startAtkCooldown;
                    //comboTime = startComboTime;

                }
                //comboTime = startComboTime;
                comboTime = startComboTime;
                extraDmgAmount++;
                   isAttacking = true;
    //  extraDmgAmount1++;

    //  buttonContinue.SetActive(false);
}
            // atkCooldown = startAtkCooldown;
        }
        
       

        if (extraDmgAmount >= 3)
        {
            isAttacking = true;
            anim.SetBool("isAttacking", true);
            anim.SetInteger("extraDmgAmount", 4);
            extraDmgAmount = 2;
            comboTime = 0;
            atkRange = 1;
        }
        if (extraDmgAmount == 1)
        {
            isAttacking = true;
            anim.SetBool("isAttacking", true);
            anim.SetInteger("extraDmgAmount", 2);
            damage = 10;
            atkRange = 1;
        }

        if (extraDmgAmount == 2)
        {
            isAttacking = true;
            anim.SetBool("isAttacking", true);
            anim.SetInteger("extraDmgAmount", 3);
            damage = 15;
            atkRange = 3;
        }

        if (extraDmgAmount == 0)
        {
            isAttacking = true;
            anim.SetBool("isAttacking", true);
            anim.SetInteger("extraDmgAmount", 1);
            damage = defaultDamage;

        }

        if (comboTime <= 0)
        {
            isAttacking = false;
            anim.SetBool("isAttacking", false);
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
        /*
        if (atkCooldown <= 0 && extraDmgAmount1 == 3)
        {
            if (Input.GetKeyDown(KeyCode.F) || CrossPlatformInputManager.GetButtonDown("Fire1"))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(atkPos1.position, atkRange, placeEnemyLayer);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                    atkCooldown = startAtkCooldown;
                    comboTime = startComboTime;

                }
                //comboTime = startComboTime;

                Debug.Log("ax");

                //  buttonContinue.SetActive(false);
            }
            // atkCooldown = startAtkCooldown;
        }

        if (extraDmgAmount1 >= 3)
        {
            extraDmgAmount1 = 0;
            comboTime = 0;
            Debug.Log("bx");

        }
        
        if (extraDmgAmount1 == 1)
        {
            damage = 10;
            Debug.Log("cx");
        }

        if (extraDmgAmount1 == 2)
        {
            damage = 15;
            Debug.Log("dx");

        }

        if (extraDmgAmount1 == 0)
        {
            damage = defaultDamage;


        }

        if (comboTime <= 0)
        {

            Combo = false;
            extraDmgAmount1 = 0;
            comboTime = 0;
           // Debug.Log("ex");
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
        */
        Debug.Log(damage);
    }
    public void damageReduction()
    {
        if (damage >= 15)
        {
            damage = 15;
        }
    }
            void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(atkPos.position, atkRange);
        Gizmos.DrawWireSphere(atkPos1.position, atkRange);
    }
}
