
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 50f;
   
    public void TakeDamage (float amount)
    {
        AudioManagerDemo.instance.PlaySound(AudioClipss.robothit);
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        AudioManagerDemo.instance.PlaySound(AudioClipss.robotdeath);
    }


}
