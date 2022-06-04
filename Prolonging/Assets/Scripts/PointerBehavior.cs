using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerBehavior : MonoBehaviour
{
    private PressureController pressure;
    private float rotation;
    private Quaternion target;

    // Start is called before the first frame update
    void Start()
    {
        pressure = GameObject.Find("Pressure").GetComponent<PressureController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pressure.Pressure >= 360){
            rotation = 360f;
        }
        else{
            rotation = pressure.Pressure;
        }
        target = Quaternion.Euler(0, 0, -rotation);
        transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime);

    }

    public void ReleasePointer(){
        gameObject.transform.Rotate(0.0f, 0.0f, -235f);
    }
}
