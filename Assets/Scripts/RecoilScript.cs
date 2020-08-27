using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilScript : MonoBehaviour
{

    public float rotationspeed = 6;
    public float returnspeed = 25;

    public Vector3 RecoilRotation = new Vector3(2f, 2f, 2f);

    private bool aiming;

    private Vector3 currentRotation;
    private Vector3 Rotate;

    private void FixedUpdate()
    {
        currentRotation = Vector3.Lerp(currentRotation, Vector3.zero, returnspeed * Time.deltaTime);
        Rotate = Vector3.Slerp(Rotate, currentRotation, rotationspeed * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(Rotate);
    }

    public void Fire()
    {
        if (aiming)
        {
            currentRotation += new Vector3(-RecoilRotation.x, Random.Range(-RecoilRotation.y, RecoilRotation.y), Random.Range(-RecoilRotation.z, RecoilRotation.z));
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Fire();
        }
    }
}
