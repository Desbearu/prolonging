using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentController : MonoBehaviour
{
    public double VentCooldown = 0;
    public double VentExtreme =  200;
    public double VentMinimun = 100;

    private GameObject VentLight;

    private GameObject warningLight;

    void Start()
    {
        warningLight = GameObject.Find("ventilacao-aviso-deu-merda");
        VentLight =  GameObject.Find("luz-ventilacao");
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
            warningLight.SetActive(true);
        }
        else if(VentCooldown < VentMinimun){
            VentLight.SetActive(false);
            warningLight.SetActive(false);
        }
    }
}
