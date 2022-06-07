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

    public GameObject sparks;

    public AudioSource lightsOut;
    public AudioSource lightsOn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(eletricityCooldown > eletricityLimit)
        {
            if(lightsOut.isPlaying == false){
                lightsOut.Play();
            }
            elecLightOn.SetActive(false);
            elecLightOff.SetActive(true);
            spriteDown.SetActive(false);
            spriteUp.SetActive(true);
            elecLight.SetActive(true);
        }
    }

    public void ButtonDown()
    {
        if(lightsOut.isPlaying == true){
            lightsOut.Stop();
        }
        elecLightOn.SetActive(true);
        elecLightOff.SetActive(false);
        spriteDown.SetActive(true);
        spriteUp.SetActive(false);
        elecLight.SetActive(false);
        sparks.SetActive(true);
        StartCoroutine(Timer());
    }

    IEnumerator Timer(){
        yield return new WaitForSeconds(0.1f);
        sparks.SetActive(false);
    }
}
