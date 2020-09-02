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
    private LineRenderer laserline;
    public Transform toTranform;
    public Transform lineWeapon;

    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        laserline = GetComponent<LineRenderer>();
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

            laserline.SetPosition(0, lineWeapon.position);
            laserline.SetPosition(1, toTranform.position);
        }
        
       
    }

    private void DisableEnemy()
    {
        canAttack = false;
       
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
                // FindObjectOfType<AudioManager>().Play("robot gun");
                AudioManagerDemo.instance.PlaySound(AudioClipss.robotgun);
                target.DamagePlayer(DamageAmount);
                laserline.enabled = true;
                yield return new WaitForSeconds(0.2f);
                laserline.enabled = false;
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
