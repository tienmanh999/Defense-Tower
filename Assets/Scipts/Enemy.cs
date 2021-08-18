using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;
    public int worth = 50;

    public float startHealth = 100;
    private float health;
    public Image healthBar;
    public bool isDead = false;
    void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }
    public void TakeDamge(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;
        if(health <=0 && !isDead)
        {
            Die();
        }
    }
    void Die()
    {
        PlayerStart.Money += worth;
        WaveSpawner.EnemyAlives--;
        Destroy(gameObject);
    }
    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

}
