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

    public AudioSource shot;
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
        shot.Play();
        foreach (GameObject detection in detections){
            detection.SetActive(false);
        }
        warningLight.SetActive(false);
        currentlyDetected = 0;
    }
}
