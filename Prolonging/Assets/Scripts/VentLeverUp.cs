using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentLeverUp : MonoBehaviour
{
    public VentController vent;
    public GameObject LeverPos;
    
    void Update(){
        if(gameObject.transform.position.y >= (LeverPos.transform.position.y - 0.2)){
            if(vent.GetComponent<VentController>().VentCooldown > 0)
            {
                Debug.Log("a");
                vent.GetComponent<VentController>().VentCooldown -= 1;
            }
            else if(vent.GetComponent<VentController>().VentCooldown == 0)
            {
                //colocar som de ter zerado aqui. 
            }
        }
    }
}
