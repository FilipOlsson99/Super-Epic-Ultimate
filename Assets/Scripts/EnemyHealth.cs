﻿
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 50f;
    public GameObject healthboost;
    public void TakeDamage (float amount)
    {
       
        health -= amount;
        if(health <= 0f)
        {
            Die();
            Instantiate(healthboost, transform.localPosition, Quaternion.identity);
        }
    }

    void Die()
    {
        FindObjectOfType<AudioManager>().Play("robot death");
        Destroy(gameObject);
        
    }


}
