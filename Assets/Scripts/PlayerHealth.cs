using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public Image currentHealth;
    public int playerHealth;
    private float healthPoints = 100;
    private float maxHealthPoints = 100;

    private Rigidbody2D rb;
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

    }
    private void DamageTaken(float dmg)
    {
        healthPoints -= dmg;
            if (healthPoints < 0)
        {
            healthPoints = 0;
        }
        UpdateHealth();

    }
    private void HealDamageTaken(float heal)
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
        //Debug.Log("Enemy hits player");
        //dazedTime = startDazedTime;
        healthPoints -= dmg;
        if (healthPoints < 0)
        {
            healthPoints = 0;
        }
        UpdateHealth();
        //playerHealth -= dmg;
        Debug.Log("Enemy hits player");
        //Instantiate(powPrefab, transform.position,transform.rotation);
    }


    // Update is called once per frame
    void Update () {
		
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
