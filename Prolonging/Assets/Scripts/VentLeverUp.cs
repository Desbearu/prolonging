using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentLeverUp : MonoBehaviour
{
    public VentController vent;
    public GameObject LeverPos;

    private bool leverPosCheck = false;
    private bool endCheck;
    
    void Start()
    {
        vent = GameObject.Find("Vent").GetComponent<VentController>();
    }

    void Update(){
        if(gameObject.transform.position.y >= (LeverPos.transform.position.y - 0.2)){
            if(leverPosCheck == false){
                vent.ventStart.Play();
                vent.leverStuck.Play();
                leverPosCheck = true;
            }
            if(vent.VentCooldown > 0)
            {
                if(vent.ventStart.isPlaying == false && vent.ventLoop.isPlaying == false){
                    vent.ventLoop.Play();
                }
                vent.VentCooldown -= 4;
            }
            else if(vent.VentCooldown == 0)
            {
                if(endCheck == false){
                    vent.ventEnd.Play(); 
                }
                endCheck = true;
            }
        }
        else{
            endCheck = false;
            leverPosCheck = false;
        }
    }
}
