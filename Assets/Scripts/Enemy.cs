using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{

    Transform target;
    NavMeshAgent agent;
    public float CloseDistance = 2f;
    public float turnspeed = 5f;
    public float DamageAmount = 35f;
    public float attackSpeed = 2f;
    public bool canAttack = true;
    public float distance;
    public Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {

       
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
         distance = Vector3.Distance(transform.position, target.position);
        if(distance > CloseDistance)
        {
            Chaseplayer();
        }
        else if(canAttack && !PlayerHealth.singleton.isDead)
        {
            Attacking();
        }
        else if (PlayerHealth.singleton.isDead)
        {
            DisableEnemy();
        }
    }
    void Chaseplayer()
    {
        agent.updateRotation = true;
        agent.updatePosition = true;
        agent.isStopped = false;
        agent.SetDestination(target.position);
        anim.SetBool("Attack", false);
    }

    void Attacking()
    {
        agent.isStopped = true;
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnspeed * Time.deltaTime);
        StartCoroutine(AttackTime());
        anim.SetBool("Attack", true);
        

        // tick the loop box because at the moment it will only ainmate once
    }

    private void DisableEnemy()
    {
        canAttack = false;
        anim.SetBool("Attack", false);
    }


    IEnumerator AttackTime()
    {
        canAttack = false;
        yield return new WaitForSeconds(0.5f);
        PlayerHealth.singleton.DamagePlayer(DamageAmount);
        yield return new WaitForSeconds(attackSpeed);
        canAttack = true;

    }

}
