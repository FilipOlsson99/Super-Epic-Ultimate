using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public float impactforce = 30f;
    public Camera FpsCam;
    public ParticleSystem Muzzleflash;
    public GameObject impactEffect;
    public float fireRate = 15f;
    public float x;
    
    private float nextTimeToFire = 0f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Animator animater;


   void Start()
    {
        if(currentAmmo == -1)
        currentAmmo = maxAmmo;
    }


    private void OnEnable()
    {
        isReloading = false;
        animater.SetBool("Reloading", false);
    }


    void Update()
    {

        if (isReloading)
        {
            return;
        }
            
        
        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading");

        animater.SetBool("Reloading", true);
       
        yield return new WaitForSeconds(reloadTime - .25f);
        animater.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;

        isReloading = false;
    }


    void Shoot()
    {
        Muzzleflash.Play();

        currentAmmo--;
        
        RaycastHit hitinfo;
        if (Physics.Raycast(FpsCam.transform.position, FpsCam.transform.forward, out hitinfo, range))
        {
            Debug.Log(hitinfo.transform.name);
            EnemyHealth target = hitinfo.transform.GetComponent<EnemyHealth>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hitinfo.rigidbody != null)
            {
                hitinfo.rigidbody.AddForce(-hitinfo.normal * impactforce);
            }

            Instantiate(impactEffect, hitinfo.point, Quaternion.LookRotation(hitinfo.normal));    
        }
    }

}
