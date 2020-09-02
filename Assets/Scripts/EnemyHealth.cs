
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 50f;
    public GameObject healthboost;
    public ParticleSystem DeathParticles;
    public Transform deathposition;
    public void TakeDamage (float amount)
    {
        AudioManagerDemo.instance.PlaySound(AudioClipss.robothit);
        health -= amount;
        if(health <= 0f)
        {
            Die();
            
            Instantiate(healthboost, transform.position, Quaternion.identity);
        }
    }

    void Die()
    {
        AudioManagerDemo.instance.PlaySound(AudioClipss.robotdeath);
        Instantiate(DeathParticles, deathposition.position, Quaternion.identity);
        Destroy(gameObject);
       
    }


}
