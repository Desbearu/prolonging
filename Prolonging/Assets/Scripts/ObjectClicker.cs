using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    public AudioSource wrongInput;
    private PressureController pressure;
    public PointerBehavior pointer;
    
    public GameObject ventLever;
    public GameObject LeverPos;
    public GameObject LeverLimit;
    private VentController vent;

    private ElectricController elec;

    private CodeController monitor;

    private RecorderController recorder;

    private TorchController torch;

    private SonarButton sonar;
    private SonarPointer detector;

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

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        
        //Vent just like in the hit game Among Us
        if(hit.collider != null)
        {
            VentLeverMover(mousePos,hit);
        }
        if(Input.GetMouseButtonDown(0)) 
        {
            if (hit.collider != null)
             {
                Debug.Log(hit.collider.gameObject.name);

                //Pressure
                if(hit.collider.gameObject.tag == "Pressure" && !torch.torchActive)
                {
                    pressure.pressureButton.SetActive(true);
                    StartCoroutine(ButtonPressed(pressure.pressureButton));
                    if(pressure.Pressure > pressure.PressureLimit)
                    {
                        pressure.Pressure -= 235;
                        pointer.GetComponent<PointerBehavior>().ReleasePointer();    
                    }
                }

                //Electricity
                if(hit.collider.gameObject.tag == "Electricity" && !torch.torchActive)
                {
                    if(elec.eletricityCooldown > elec.eletricityLimit)
                    {
                        int elecCheck = Random.Range(0, 100);
                        Debug.Log(elecCheck);
                        if(elecCheck > 75)
                        {
                            elec.eletricityCooldown = 0;
                            elec.ButtonDown();
                        }
                        else {
                            //som que deu errado
                        }
                    }
                    else{
                        if(wrongInput.isPlaying == false){
                            wrongInput.Play();
                        }
                    }
                }

                //Code
                if(hit.collider.gameObject.tag == "Button" && !torch.torchActive)
                {
                    if(monitor.codeCooldown > monitor.codeEvent)
                    {
                    monitor.GetButtonPressedName(hit.collider.gameObject.name);
                    } else {
                        if(wrongInput.isPlaying == false){
                            wrongInput.Play();
                        }
                    }
                }

                //Recorder
                if(hit.collider.gameObject.tag == "Recorder" && !torch.torchActive)
                {
                    if(!recorder.charging){
                        recorder.songPlaying = !(recorder.songPlaying);
                        recorder.SongOn();
                    }
                    else{
                        if(wrongInput.isPlaying == false){
                            wrongInput.Play();
                        }
                    }
                }

                //Torch
                if(hit.collider.gameObject.tag == "Buraco" && torch.torchActive)
                {
                    if(torch.torchSound.isPlaying == false){
                        torch.torchSound.Play();
                    }
                    torch.CloseHole(torch.holes[torch.selectedHole]);
                }
                else if (hit.collider.gameObject.tag != "Buraco" && hit.collider.gameObject.tag != "Torch" && torch.torchActive){
                    if(wrongInput.isPlaying == false){
                        wrongInput.Play();
                    }
                }
                else if(hit.collider.gameObject.tag == "Buraco" && !torch.torchActive){
                    if(wrongInput.isPlaying == false){
                        wrongInput.Play();
                    }
                }
                if(hit.collider.gameObject.tag == "Torch")
                {
                    Debug.Log("macarico");
                    torch.torchActive = !torch.torchActive;
                }

                //Radar
                if(hit.collider.gameObject.tag == "Sonar" && !torch.torchActive && sonar.activeCooldown == false && detector.sonarCooldown > 0){
                    detector.Shoot();
                    sonar.botaoApertado.SetActive(true);
                    sonar.activeCooldown = true;
                    StartCoroutine(ButtonPressed(sonar.botaoApertado));
                }
                else if(hit.collider.gameObject.tag == "Sonar" && !torch.torchActive && detector.sonarCooldown <= 0){
                    if(wrongInput.isPlaying == false){
                        wrongInput.Play();
                    }
                }
                else if(hit.collider.gameObject.tag == "OutOfBounds"){
                    if(wrongInput.isPlaying == false){
                        wrongInput.Play();
                    }
                }
            }
        }
    }

    void VentLeverMover(Vector3 mousePos, RaycastHit2D hit){
        if(Input.GetMouseButton(0)){
            if(hit.collider.gameObject.tag == "Vent" && !torch.torchActive)
            {
                Vector2 leverPos = mousePos;
                if(mousePos.y < LeverPos.transform.position.y){
                    leverPos.y = LeverPos.transform.position.y;
                }
                if(mousePos.y > LeverLimit.transform.position.y){
                    leverPos.y = LeverLimit.transform.position.y;
                }
                ventLever.transform.position = new Vector2(ventLever.transform.position.x, leverPos.y);
            }
        }
        else{
            ventLever.transform.position = LeverPos.transform.position;
        }
    }

    IEnumerator ButtonPressed(GameObject button){
        yield return new WaitForSeconds(0.3f);
        button.SetActive(false);
    }
}
