using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    public GameObject gameController;
    public GameObject startingText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startingText.active == false){
            gameController.SetActive(true);
        }
    }
}
