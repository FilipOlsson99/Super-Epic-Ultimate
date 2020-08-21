using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyRanger : MonoBehaviour
{
    public enum state { chasing, attacking, playerDead }
    public state aiState;
    public GameObject target;
    NavMeshAgent agent;
    public float CloseDistance = 2f;
    [Range(0,1)]
    public float turnspeed = 0.5f;
    public float DamageAmount = 35f;
    public float attackSpeed = 2f;
    public bool canAttack = true;
    public GameObject weaponEnd;
    public ParticleSystem muzzleflash;

    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if(distance > CloseDistance)
        {
            aiState = state.chasing;
        }
        else if(!PlayerHealth.singleton.isDead)
        {
            aiState = state.attacking;
        }
        else if (PlayerHealth.singleton.isDead)
        {
            aiState = state.playerDead;
        }

        switch (aiState)
        {
            case state.chasing:
                Chaseplayer();
                break;
            case state.attacking:
                Attacking();
                Debug.Log("I'm attacking");
                break;
            case state.playerDead:
                DisableEnemy();
                break;
        }


    }
    void Chaseplayer()
    {
        agent.updateRotation = true;
        agent.updatePosition = true;
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
        //walking animation here  example code anim.SetBool("iswalking, true);
        //anim.SetBool(isAttacking", false);
    }

    void Attacking()
    {
        agent.isStopped = true;
        agent.updateRotation = false;
        Vector3 direction = target.transform.position - transform.position;
        direction.y = 0; //Vector3.SmoothDamp()
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnspeed );
        agent.updatePosition = false;
        if (canAttack)
        {
            StartCoroutine(AttackTime());
        }
        
       
        
        
        
        //anim.SetBool("iswalking, false);
        //anim.SetBool(isAttacking", true);

        // tick the loop box because at the moment it will only ainmate once
    }

    private void DisableEnemy()
    {
        canAttack = false;
        //Ani.setBool("iswalking", false);  turning off Animations and attacks when the game is done.
        //Ani.setBool("iswalking", false);
    }


    IEnumerator AttackTime()
    {
        canAttack = false;
        yield return new WaitForSeconds(0.5f);
        RaycastHit hitinfo;
        if (Physics.Raycast(weaponEnd.transform.position, weaponEnd.transform.forward, out hitinfo, CloseDistance))          
        {
            Debug.Log(hitinfo.transform.name);
            PlayerHealth target = hitinfo.transform.GetComponent<PlayerHealth>();

            if (target != null)
            {
                muzzleflash.Play();
                target.DamagePlayer(DamageAmount);
                yield return new WaitForSeconds(attackSpeed);
                canAttack = true;
            }
            
        }
        else
        {
            Debug.Log("Can't find player");
            //Attacking();
        }
    
    }

}
