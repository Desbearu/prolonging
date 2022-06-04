using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricController : MonoBehaviour
{
    public GameObject elecLight;
    public GameObject elecLightOn;
    public GameObject elecLightOff;
    public double eletricityCooldown;
    public double eletricityLimit;

    public GameObject spriteUp;
    public GameObject spriteDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        eletricityCooldown += 0.03;

        if(eletricityCooldown > eletricityLimit)
        {
            elecLightOn.SetActive(false);
            elecLightOff.SetActive(true);
            spriteDown.SetActive(false);
            spriteUp.SetActive(true);
            elecLight.SetActive(true);
        }
    }

    public void ButtonDown()
    {
        elecLightOn.SetActive(true);
        elecLightOff.SetActive(false);
        spriteDown.SetActive(true);
        spriteUp.SetActive(false);
        elecLight.SetActive(false);
    }
}
