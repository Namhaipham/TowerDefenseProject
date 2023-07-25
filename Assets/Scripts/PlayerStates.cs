using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStates : MonoBehaviour
{
    public static int Money;
    public int startMoney = 100;
    
    public static float Health;
    public int maxHealth ;
    public static int rounds;

    public Image healthbar;

    Enemy e;
    private void Start()
    {
        Money = startMoney;
        Health = maxHealth;
        rounds = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            DamageTaken(e.damage);
        }
    }
    public void DamageTaken(float amount)
    {
        
        Health -= amount;
        healthbar.fillAmount = Health / maxHealth;
        if (Health <= 0)
        {
            Health = 0;
        }
    }
}
