using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
   
    public float speed = 5f;
    private Transform target;
    private int wavepointIndex = 0;

    public int value = 50;

    public GameObject deathEffect;

    public float healthStart;
    [HideInInspector]
    public float health;

    [Header("UnityStuff")]
    public Image healthBar;

    private bool isDead = false;

    [HideInInspector]
    public float damage = 10f;
    public PlayerStates player;
    private void Start()
    {
        target = Waypoints.points[0];
        health = healthStart;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / healthStart;
        
        if(health <= 0 && !isDead)
        {
            Die();
        }
        
    }
    

    public void Die()
    {
        isDead = true;
        PlayerStates.Money += value;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }


    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        transform.LookAt(target);
        
        if (Vector3.Distance(transform.position, target.position) <= 0.5f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if(wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
       
    }


    public void EndPath()
    {
        player.DamageTaken(damage);
        Debug.Log(PlayerStates.Health);
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
        
    }
}
