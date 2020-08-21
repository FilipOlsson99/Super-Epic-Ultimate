using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnEnemy", spawnTime, spawnDelay);
    }

    private void spawnEnemy()
    {
        
        GameObject enemy = Instantiate(Enemy, transform.position, transform.rotation);

        if (enemy.GetComponent<EnemyRanger>())
        {
            enemy.GetComponent<EnemyRanger>().target = player;
        }
        if (stopSpawning)
        {
            CancelInvoke("spawnEnemy");
        }
    }

}