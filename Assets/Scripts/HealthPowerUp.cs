using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{

    public float healthBoost = 20f;
    public GameObject parent;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().Healplayer(healthBoost);
            Debug.Log("picked it up");
            Destroy(gameObject);
            //FindObjectOfType<AudioManager>().Play("Health pickup");
            AudioManagerDemo.instance.PlaySound(AudioClipss.health);
        }
    }


   


}
