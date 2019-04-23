using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public Image currentHealth;
    public int playerHealth;
    private float healthPoints = 100;
    private float maxHealthPoints = 100;

    // Use this for initialization
    private void Start() {
        UpdateHealth();
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
}
