using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Weapontxt : MonoBehaviour
{
    public GameObject Weapon;

    Text ammotext;
    
    // Start is called before the first frame update
    void Start()
    {
        ammotext = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ammotext.text = Weapon.GetComponent<Weapon>().currentAmmo.ToString();
    }
}
