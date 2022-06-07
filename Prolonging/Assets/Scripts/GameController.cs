using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float Depth = 0;
    public GameObject depthLight;

    private float fallingSpeed = 0.01f;

    private PressureController pressure;
    private VentController vent;
    private ElectricController elec;
    private CodeController monitor;
    private RecorderController recorder;
    private TorchController torch;
    private SonarButton sonar;
    private SonarPointer detector;

    private float rotation;
    private Quaternion target;

    void Start()
    {
        pressure = GameObject.Find("Pressure").GetComponent<PressureController>();
        vent = GameObject.Find("Vent").GetComponent<VentController>();
        elec = GameObject.Find("Elec").GetComponent<ElectricController>();
        monitor = GameObject.Find("Monitor").GetComponent<CodeController>();
        recorder = GameObject.Find("Rec").GetComponent<RecorderController>();
        torch = GameObject.Find("Torch").GetComponent<TorchController>();
        sonar = GameObject.Find("Sonar").GetComponent<SonarButton>();
        detector = GameObject.Find("Detector").GetComponent<SonarPointer>();
    }

    void Update()
    {
        Depth += fallingSpeed;

        if(Depth > 180){
            sonar.botaoAberto.SetActive(true);
            sonar.botaoFechado.SetActive(false);
            sonar.botaoAtivo = true;
        }

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

        ProblemActivation();

        PressureCheck();
        VentCheck();
        EletricityCheck();
        SanityCheck();
        TorchCheck();
    }

    void ProblemActivation()
    {
        if(Depth > 36)
        {
            elec.eletricityCooldown += 0.03f;
        }
        if(Depth > 72)
        {
            if(vent.VentCooldown < vent.VentExtreme){
                vent.VentCooldown += 0.05;
            }

            if(vent.VentCooldown < 0){
                vent.VentCooldown = 0;
            }
        }
        if(Depth > 108)
        {
            torch.holeCooldown += 0.01;
        }
        if(Depth > 144)
        {
            recorder.sanityCooldown += 0.05;
        }
        if(Depth > 180)
        {
            detector.sonarCooldown += 0.01f;
        }
        if(Depth > 216)
        {
            monitor.codeCooldown += 0.05;
        }
        if(Depth > 360){
            Debug.Log("morte");
        }
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
