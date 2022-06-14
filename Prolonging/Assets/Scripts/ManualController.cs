using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualController : MonoBehaviour
{
    public GameObject wholeManual;

    public GameObject[] correctPages;
    public GameObject[] highSanityPages;
    private int pageNum;

    private RecorderController sanity;

    public AudioSource pageFlip;
    public AudioSource bookDown;

    void Start()
    {
        sanity = GameObject.Find("Rec").GetComponent<RecorderController>();
        pageNum = 0;
    }

    void Update()
    {
        
    }

    public void OpenManual()
    {
        wholeManual.SetActive(true);
        pageFlip.Play();
        SanityCheck();
    }

    public void CloseManual()
    {
        wholeManual.SetActive(false);
        bookDown.Play();
    }

    public void NextPage()
    {   
        highSanityPages[pageNum].SetActive(false);
        correctPages[pageNum].SetActive(false);
        pageNum += 1;
        correctPages[pageNum].SetActive(true);
        SanityCheck();
        pageFlip.Play();
    }

    public void PreviousPage()
    {   
        highSanityPages[pageNum].SetActive(false);
        correctPages[pageNum].SetActive(false);
        pageNum -= 1;
        correctPages[pageNum].SetActive(true);
        SanityCheck();
        pageFlip.Play();
    }

    void SanityCheck(){
        if(sanity.sanityCooldown > (sanity.sanityLimit/2) && sanity.sanityCooldown < sanity.sanityLimit){
            int num = Random.Range(0,100);
            if(num > 50){
                correctPages[pageNum].SetActive(false);
                highSanityPages[pageNum].SetActive(true);
            }
        } else if (sanity.sanityCooldown >= sanity.sanityLimit){
            correctPages[pageNum].SetActive(false);
            highSanityPages[pageNum].SetActive(true);
        }
    }
}
