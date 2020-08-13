
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

    private float nextTimeToFire = 0f;
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        Muzzleflash.Play();
        RaycastHit hitinfo;
        if (Physics.Raycast(FpsCam.transform.position, FpsCam.transform.forward, out hitinfo, range))
        {
            Debug.Log(hitinfo.transform.name);
           Enemy target = hitinfo.transform.GetComponent<Enemy>();
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
