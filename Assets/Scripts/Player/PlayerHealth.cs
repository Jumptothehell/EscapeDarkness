using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 120;
    public int currentHealth;

    public HealthBarScript healthBar;

    private Animator animator;
    bool Grounded;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Game over");
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            currentHealth -= 20;
            healthBar.SetHealth(currentHealth);
            Destroy(collision.gameObject);
        }
    }
}
