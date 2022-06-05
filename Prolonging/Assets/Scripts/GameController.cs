using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float Depth = 0;
    public GameObject depthLight;
    public bool Radar =  false; 

    private float fallingSpeed = 0.0001f;

    private PressureController pressure;
    private VentController vent;
    private ElectricController elec;
    private CodeController monitor;
    private RecorderController recorder;
    private TorchController torch;

    private float rotation;
    private Quaternion target;
    // Start is called before the first frame update
    void Start()
    {
        pressure = GameObject.Find("Pressure").GetComponent<PressureController>();
        vent = GameObject.Find("Vent").GetComponent<VentController>();
        elec = GameObject.Find("Elec").GetComponent<ElectricController>();
        monitor = GameObject.Find("Monitor").GetComponent<CodeController>();
        recorder = GameObject.Find("Rec").GetComponent<RecorderController>();
        torch = GameObject.Find("Torch").GetComponent<TorchController>();
    }

    // Update is called once per frame
    void Update()
    {
        Depth += fallingSpeed;

        if(Depth > 270)
        {
            depthLight.SetActive(true);
        }
        if(Depth >= 360){
            rotation = 360f;
        }
        else{
            rotation = Depth;
        }
        target = Quaternion.Euler(0, 0, -rotation);
        transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime);


        PressureCheck();
        VentCheck();
        EletricityCheck();
        SanityCheck();
        TorchCheck();
    }

    void PressureCheck(){
        if(pressure.Pressure > pressure.PressureLimit){
            Depth += fallingSpeed;
        }
    }

    void VentCheck(){
        if(vent.VentCooldown > vent.VentMinimun && vent.VentCooldown == vent.VentExtreme){
            Depth += fallingSpeed;
        }
    }

    void EletricityCheck(){
        if(elec.eletricityCooldown > elec.eletricityLimit)
        {
            Depth += fallingSpeed;
        }
    }

    void MonitorCheck(){
        if(monitor.codeCooldown > monitor.codeEvent)
        {
            Depth += fallingSpeed;
        }
    }

    void SanityCheck()
    {
        if(recorder.sanityCooldown > recorder.sanityLimit)
        {
            Depth += fallingSpeed;
        }
    }

    void TorchCheck()
    {
        if(torch.holeCooldown > torch.showHole)
        {
            Depth += fallingSpeed;
        }
        if(torch.holeCooldown > torch.holeGrow)
        {
            Depth += fallingSpeed;
        }
    }
}
