using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentController : MonoBehaviour
{
    public double VentCooldown = 0;
    public double VentExtreme =  200;
    public double VentMinimun = 100;
    public AudioSource ventAlarm;

    private GameObject VentLight;

    private GameObject warningLight;

    public AudioSource leverDown;
    public AudioSource leverStuck;

    public AudioSource ventStart;
    public AudioSource ventLoop;
    public AudioSource ventEnd;

    void Start()
    {
        warningLight = GameObject.Find("ventilacao-aviso-deu-merda");
        VentLight =  GameObject.Find("luz-ventilacao");
    }

    void Update()
    { 
        if(VentCooldown >= VentExtreme){
            if(ventAlarm.isPlaying == false){
                ventAlarm.Play();
            }
            VentLight.SetActive(true);
            warningLight.SetActive(true);
        }
        else if(VentCooldown < VentMinimun){
            ventAlarm.Stop();
            VentLight.SetActive(false);
            warningLight.SetActive(false);
        }
    }
}
