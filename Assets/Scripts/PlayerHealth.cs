using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth singleton;
    public float currentHealth;
    public float maxHealth = 100f;
    public bool isDead = false;
    public LockMouse Lock;
    public Slider myhealthbar;
    public GameObject hitindication;
    public Camera cam;
    public Animator anim;
    



    private void Awake()
    {
        currentHealth = maxHealth;
        singleton = this;
    }
    // Start is called before the first frame update
    void Start()
    {
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
            if (currentHealth <= 0)
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
        AudioManagerDemo.instance.PlaySound(AudioClipss.bodyhit);

        hitindication.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        hitindication.SetActive(false);
        


        if (currentHealth <= 0)
        {
            hitindication.SetActive(true);
           
        }
        
    }

  

    private void Loadscene()
    {
        GetComponent<LockMouse>().LockCursor(true);
        SceneManager.LoadScene("GameOver");
    }


    private void  Dead()
    {
        currentHealth = 0;
        anim.SetBool("Isdead", true);
        Debug.Log("Player is Dead");
        isDead = true;
        TimerController.instance.EndTimer();   
        Invoke("Loadscene", 3.0f);
    }

}
