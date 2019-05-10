using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerHealth : MonoBehaviour {
    public Image currentHealth;
    public Image currentEnergy;

    private Rigidbody2D rb;
    [SerializeField]
    private float healthPoints = 100;
    [SerializeField]
    private float maxHealthPoints = 100;
    [SerializeField]
    private float energyPoints = 100;
    [SerializeField]
    private float maxEnergyPoints = 100;

    public int health;
    public int numOfHeartBlocks;

    public Image[] hearts;
    public Sprite fullHeartBlock;
    public Sprite emptyHeartBlock;

    //[SerializeField]
    //private float healthUpgrade = 100;
    //public float knockbackDuration;
    //public float knockbackAmount;

    // Use this for initialization
    private void Start() {
    
        UpdateHealth();
        rb = GetComponent<Rigidbody2D>();
    }
    private void UpdateHealth()
    {
      
        float ratio = healthPoints / maxHealthPoints;
    

        
        currentHealth.rectTransform.localScale = new Vector3(ratio, 1, 1);
        float ratio1 = energyPoints / maxEnergyPoints;
        
        currentEnergy.rectTransform.localScale = new Vector3(ratio1, 1, 1);
    

    }
    
    
    public void HealDamageTaken(float heal)
    {
        healthPoints += heal;
        if (healthPoints > maxHealthPoints)
        {
            healthPoints = maxHealthPoints;
        }
        UpdateHealth();

    }
    
    public void PlayerTakesDamage(int dmg)
    {
        healthPoints -= dmg;
        if (healthPoints < 0)
        {
            healthPoints = 0;
        }
        UpdateHealth();
        Debug.Log("Enemy hits player");
    }


    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.G) && energyPoints >= 50 || CrossPlatformInputManager.GetButtonDown("Fire2") && energyPoints >= 50)
        {
            energyPoints -= 100;
        }
        if ( energyPoints < maxEnergyPoints)
        {
            energyPoints += 0.5f +(Mathf.Round(Time.deltaTime)) ;

        }
        if (energyPoints < 0)
        {
            energyPoints = 0;

        }
        else if (energyPoints >= maxEnergyPoints)
        {

            energyPoints = 100;
        }
        UpdateHealth();
    }
    public IEnumerator Knockback(float knockbackDuration, float knockbackAmount, Vector3 knockbackPosition)
    {
        float timer = 0;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        while (knockbackDuration > timer)
        {
            timer += Time.deltaTime;

            rb.AddForce(new Vector3(knockbackPosition.x * -400 * transform.localScale.x, knockbackPosition.y + knockbackAmount, transform.position.z));
        }
        yield return 0;
    }

}
