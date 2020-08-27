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
    public GameObject hitindication;

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

    public void Healplayer(float health)
    {
        currentHealth += health;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;

        }
        myhealthbar.value = currentHealth;
      
    }


    



    public void DamagePlayer(float damage)
    {
        if(currentHealth > 0)
        {
            currentHealth -= damage;
            myhealthbar.value -= damage;
            StartCoroutine(Hitindication());
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

    IEnumerator Hitindication()
    {
        hitindication.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        hitindication.SetActive(false);
    }


    private void  Dead()
    {
        currentHealth = 0;
        Debug.Log("Player is Dead");
        isDead = true;
        
    }

}
