using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecorderController : MonoBehaviour
{

    public AudioSource music;
    public AudioSource rewindSound;
    public double sanityCooldown;
    public double sanityLimit;
    private float cooldownTime;

    public bool songPlaying = false;

    public GameObject spriteRec;

    private bool songCheck = false;
    public bool charging = false;

    public GameObject[] tentacles;

    public double spawnCooldown; 
    private double timeStamp = 0;

    private Color defaultSpriteColor;

    void Start(){
        defaultSpriteColor = tentacles[0].GetComponent<SpriteRenderer>().color;
        cooldownTime = rewindSound.clip.length;
    }

    void Update()
    {
        if(sanityCooldown >= sanityLimit)
        {
            sanityCooldown = sanityLimit;
            
            if(timeStamp == 0){
                timeStamp = Time.time + spawnCooldown;
            }
            
            if(timeStamp <= Time.time)
            {
                foreach (GameObject tentacle in tentacles){
                 tentacle.GetComponent<SpriteRenderer>().color = defaultSpriteColor;
                }
                int selectedTentacle = Random.Range(0,5);
                tentacles[selectedTentacle].SetActive(true);
                timeStamp = 0;
            }

        } else if ( sanityCooldown <= 0){
            sanityCooldown = 0;
            timeStamp = 0;
            foreach (GameObject tentacle in tentacles){
                StartCoroutine(FadeOut(tentacle));
            }
        }
        if(music.isPlaying == true){
            sanityCooldown -= 0.3;
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

    IEnumerator Timer(float time){
        charging = true;
        rewindSound.Play();
        yield return new WaitForSeconds(time);
        charging = false;
        songPlaying = false;
    }

    private IEnumerator FadeOut(GameObject obj)
     {
        SpriteRenderer sprite = obj.GetComponent<SpriteRenderer>();
         float alphaVal = sprite.color.a;
         Color tmp = sprite.color;

         while (sprite.color.a > 0)
         {
             alphaVal -= 0.1f;
             tmp.a = alphaVal;
             sprite.color = tmp;
 
             yield return new WaitForSeconds(0.05f); // update interval
         }

         obj.SetActive(false);
     }
}
