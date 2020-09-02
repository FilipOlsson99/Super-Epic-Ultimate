
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 50f;
    public GameObject healthboost;
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
        FindObjectOfType<AudioManager>().Play("robot death");
        Destroy(gameObject);
        AudioManagerDemo.instance.PlaySound(AudioClipss.robotdeath);
    }


}
