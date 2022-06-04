using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentController : MonoBehaviour
{
    public double VentCooldown = 0;
    public double VentExtreme =  200;
    public double VentMinimun = 100;

    public GameObject VentLight;

    void Start()
    {
        
    }

    void Update()
    {   
        if(VentCooldown < VentExtreme){
            VentCooldown += 0.05;
        }

        if(VentCooldown < 0){
            VentCooldown = 0;
        }

        if(VentCooldown >= VentExtreme){
            VentLight.SetActive(true);
        }
        else if(VentCooldown < VentMinimun){
            VentLight.SetActive(false);
        }
    }
}
