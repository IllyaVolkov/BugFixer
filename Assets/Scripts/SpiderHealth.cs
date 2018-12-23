using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiderHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public int scoreValue = 10;
    public Slider healthSlider;

    Animator anim;
    bool isDead;
    bool isSinking;

    void Awake()
    {
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
        healthSlider.maxValue = currentHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int amount)
    {
        if (!isDead) {
            anim.SetTrigger("Hit");
            currentHealth -= amount;
            healthSlider.value = currentHealth;

            if (currentHealth <= 0)
            {
                Death();
            }
        }
    }

    public void HitTarget()
    {
        isDead = true;
        anim.SetTrigger("Dead");
        Destroy(gameObject, 0.3f);
    }

    void Death()
    {
        isDead = true;
        anim.SetTrigger("Dead");
        ScoreManager.score += scoreValue;
        Destroy(gameObject, 0.3f);
    }
}
