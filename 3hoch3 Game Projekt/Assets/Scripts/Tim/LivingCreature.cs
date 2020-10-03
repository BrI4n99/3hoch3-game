using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivingCreature : MonoBehaviour, IDamageable
{
    public float startingHealth;
    protected float health;
    protected bool dead;

    //WinLogic
    public GameObject winLogic;

    [Header("Unity Stuff")]
    public Image healthBar;

    public virtual void Start()
    {
        health = startingHealth;
    }

    public void TakeHit(float damage)
    {
        health -= damage;

        healthBar.fillAmount = health / startingHealth;

        //Punkte
        ib_StaticVar._score += 50;

        if (health <= 0 && !dead)
        {
            Die();
        }
    }

    public void Die()
    {
        dead = true;
        ib_StaticVar._score += 1000;
        winLogic.SetActive(true);
        Destroy(gameObject);
    }
}
