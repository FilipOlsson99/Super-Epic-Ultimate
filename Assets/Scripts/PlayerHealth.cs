using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth singleton;
    public float currentHealth;
    public float maxHealth = 100f;
    public bool isDead = false;
    public Slider myhealthbar;


    private void Awake()
    {
        singleton = this;
    }
    // Start is called before the first frame update
    void Start()
    {
    
        currentHealth = maxHealth;
        myhealthbar.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
      
      

    }

    public void DamagePlayer(float damage)
    {
        if(currentHealth > 0)
        {
            currentHealth -= damage;
            myhealthbar.value -= damage;

            if(currentHealth <= 0)
            {
                Dead();
                myhealthbar.value = 0;
            }
        }
        else
        {
            Dead();
        }
      
    }

    private void  Dead()
    {
        currentHealth = 0;
        Debug.Log("Player is Dead");
        isDead = true;
        
    }

}
