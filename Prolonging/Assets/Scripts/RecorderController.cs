using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecorderController : MonoBehaviour
{

    public AudioSource music;
    public double sanityCooldown;
    public double sanityLimit;
    public int cooldownTime;

    public bool songPlaying = false;

    public GameObject spriteRec;

    private bool songCheck = false;
    public bool charging = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(sanityCooldown >= sanityLimit)
        {
            sanityCooldown = sanityLimit;
            
            //ele fica doido
        }
        if(music.isPlaying == true){
            sanityCooldown -= 0.8;
        }
        if(music.time == music.clip.length){
            spriteRec.SetActive(true);
            songPlaying = false;
            songCheck = false;
            StartCoroutine(Timer(cooldownTime));
        }
    }

    public void SongOn()
    {
        if(songPlaying && !charging){
            spriteRec.SetActive(false);
            if(songCheck)
            {
                music.UnPause();
            }
            else{
                music.Play();
                songCheck = true;
            }
        }
        else{
            spriteRec.SetActive(true);
            music.Pause();
        }
    }

    IEnumerator Timer(int time){
        charging = true;
        yield return new WaitForSeconds(3);
        charging = false;
        songPlaying = false;
    }
}
