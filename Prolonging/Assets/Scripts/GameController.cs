using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public double Depth = 0;
    public bool Radar =  false; 

    private PressureController pressure;
    private VentController vent;
    private ElectricController elec;
    private CodeController monitor;
    private RecorderController recorder;
    private TorchController torch;

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
        Depth += 0.000001;
        PressureCheck();
        VentCheck();
        EletricityCheck();
        SanityCheck();
        TorchCheck();
    }

    void PressureCheck(){
        if(pressure.Pressure > pressure.PressureLimit){
            Depth += 0.000001;
        }
    }

    void VentCheck(){
        if(vent.VentCooldown > vent.VentMinimun && vent.VentCooldown == vent.VentExtreme){
            Depth += 0.000001;
        }
    }

    void EletricityCheck(){
        if(elec.eletricityCooldown > elec.eletricityLimit)
        {
            Depth += 0.000001;
        }
    }

    void MonitorCheck(){
        if(monitor.codeCooldown > monitor.codeEvent)
        {
            Depth += 0.000001;
        }
    }

    void SanityCheck()
    {
        if(recorder.sanityCooldown > recorder.sanityLimit)
        {
            Depth += 0.000001;
        }
    }

    void TorchCheck()
    {
        if(torch.holeCooldown > torch.showHole)
        {
            Depth += 0.000001;
        }
        if(torch.holeCooldown > torch.holeGrow)
        {
            Depth += 0.000001;
        }
    }
}
