using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarPointer : MonoBehaviour
{
    public GameObject[] detections;
    public float sonarCooldown;
    public float sonarLimit = 100f;

    private int detected;
    private int currentlyDetected;
    private GameObject warningLight;

    // Start is called before the first frame update
    void Start()
    {
        warningLight = GameObject.Find("sonar-light");
        warningLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         gameObject.transform.Rotate(0.0f, 0.0f, -0.5f);

        sonarCooldown += 0.00001f;
         if(sonarCooldown >= sonarLimit && currentlyDetected <= 8)
         {
             detected = Random.Range(0, detections.Length);
             if(detections[detected]){
                detected = Random.Range(0, detections.Length);
             }
             detections[detected].SetActive(true);
             currentlyDetected += 1;
             sonarCooldown = 0;
         }

         if(currentlyDetected == 8){
            warningLight.SetActive(true);
         }
    }

    public void Shoot()
    {
        foreach (GameObject detection in detections){
            detection.SetActive(false);
        }
        currentlyDetected = 0;
    }
}
