using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour
{
    public double holeCooldown;
    public double showHole;
    public double holeGrow;

    public GameObject[] holes;
    private bool activeHole = false;
    private bool bigHole = false;
    public int selectedHole;
    public bool torchActive = false;
    public GameObject selectedLight;

    private Vector3 originalScale;

    public AudioSource torchSound;
    // Start is called before the first frame update
    void Start()
    {
        originalScale = holes[0].gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(torchActive == true)
        {
            selectedLight.SetActive(true);
        }else{
            selectedLight.SetActive(false);
        }

        if(holeCooldown > showHole && !activeHole)
        {
            selectedHole = Random.Range(0, holes.Length);
            holes[selectedHole].SetActive(true);
            activeHole = true;
        }
        else if(holeCooldown > holeGrow && activeHole && !bigHole)
        {
            holes[selectedHole].gameObject.transform.localScale = new Vector3(1,1,1);
            bigHole = true;
        }
    }

    public void CloseHole(GameObject hole)
    {
        hole.SetActive(false);
        activeHole = false;
        hole.transform.localScale = originalScale;
        holeCooldown = 0;
    }
}
