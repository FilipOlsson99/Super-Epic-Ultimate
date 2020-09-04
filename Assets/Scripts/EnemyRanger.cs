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
    public Transform lineWeapon;
    public Animator anim;
    private RaycastHit hitinfo;

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
        anim.SetBool("RangedAttack", false);
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
        
       
    }

    private void DisableEnemy()
    {
        canAttack = false;
       
    }


    IEnumerator AttackTime()
    {
        canAttack = false;
        yield return new WaitForSeconds(0.5f);
        canAttack = true;
        


        if (Physics.Raycast(weaponEnd.transform.position, weaponEnd.transform.forward, out hitinfo, CloseDistance))          
        {
            
            Debug.Log(hitinfo.transform.name);
            PlayerHealth target = hitinfo.transform.GetComponent<PlayerHealth>();
            if (target != null)
            {
                
                muzzleflash.Play();
                // FindObjectOfType<AudioManager>().Play("robot gun");
                AudioManagerDemo.instance.PlaySound(AudioClipss.robotgun);
                
                Debug.Log("Hit a collider");
                
                laserline.enabled = true;
                laserline.SetPosition(0, lineWeapon.position);
                laserline.SetPosition(1, hitinfo.transform.position);
                target.DamagePlayer(DamageAmount);
                yield return new WaitForSeconds(0.2f);
                laserline.enabled = false;
                yield return new WaitForSeconds(attackSpeed);
            }
        }
        else
        {
            Debug.Log("shooting into the void");
            laserline.enabled = true;
            laserline.SetPosition(0, lineWeapon.position);
            laserline.SetPosition(1, lineWeapon.forward * 20);
            
            yield return new WaitForSeconds(0.2f);
            laserline.enabled = false;
            yield return new WaitForSeconds(attackSpeed);



            Debug.Log("Can't find player");
            //Attacking();
        }
    
    }

}
