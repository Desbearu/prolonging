using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
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
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        
        if(hit.collider != null)
        {
            VentLeverMover(mousePos,hit);
        }
        if(Input.GetMouseButtonDown(0)) 
        {
            if (hit.collider != null)
             {
                Debug.Log(hit.collider.gameObject.name);
                if(hit.collider.gameObject.tag == "Pressure" && !torch.torchActive)
                {
                    if(pressure.Pressure > pressure.PressureLimit)
                    {
                        pressure.Pressure -= 235;
                        pointer.GetComponent<PointerBehavior>().ReleasePointer();
                    }
                }
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
                }
                if(hit.collider.gameObject.tag == "Button" && !torch.torchActive)
                {
                    monitor.GetButtonPressedName(hit.collider.gameObject.name);
                }
                if(hit.collider.gameObject.tag == "Recorder" && !torch.torchActive)
                {
                    recorder.songPlaying = !(recorder.songPlaying);
                    recorder.SongOn();
                }
                if(hit.collider.gameObject.tag == "Buraco" && torch.torchActive)
                {
                    torch.CloseHole(torch.holes[torch.selectedHole]);
                }
                if(hit.collider.gameObject.tag == "Torch")
                {
                    Debug.Log("macarico");
                    torch.torchActive = !torch.torchActive;
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
}
