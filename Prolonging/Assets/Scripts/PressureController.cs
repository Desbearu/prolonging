using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureController : MonoBehaviour
{
    public float Pressure = 0;
    public double PressureLimit = 235;
    public double PressureExtreme = 360;

    public AudioSource pressureWarningSound;

    public GameObject pressureLight;
    public GameObject pressureButton;
    private GameObject lightAsset;

    private ElectricController elec;

    void Start()
    {
        lightAsset = GameObject.Find("pressao-luz-acesa");
        elec = GameObject.Find("Elec").GetComponent<ElectricController>();
    }


    void Update()
    {
        if(Pressure > PressureLimit){
            if(pressureWarningSound.isPlaying == false && elec.eletricityCooldown < elec.eletricityLimit){
                pressureWarningSound.Play();
            }

            lightAsset.SetActive(true);
            pressureLight.SetActive(true);
        }
        else{
            pressureWarningSound.Stop();
            lightAsset.SetActive(false);
            pressureLight.SetActive(false);
        }
    }
}
