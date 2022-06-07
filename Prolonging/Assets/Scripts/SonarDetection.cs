using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarDetection : MonoBehaviour
{
    private SpriteRenderer sprite;
    private AudioSource audio;

    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        audio = gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "RadarDetection"){
            StartCoroutine(FadeIn());
        }
    }

     private IEnumerator FadeIn()
     {
         float alphaVal = sprite.color.a;
         Color tmp = sprite.color;

         audio.Play();
 
         while (sprite.color.a < 1)
         {
             alphaVal += 0.3f;
             tmp.a = alphaVal;
             sprite.color = tmp;

             yield return new WaitForSeconds(0.05f); // update interval
         }
        yield return new WaitForSeconds(1f);
        StartCoroutine(Timer());
        StartCoroutine(FadeOut());
     }
 
     private IEnumerator FadeOut()
     {
         float alphaVal = sprite.color.a;
         Color tmp = sprite.color;

         while (sprite.color.a > 0)
         {
             alphaVal -= 0.1f;
             tmp.a = alphaVal;
             sprite.color = tmp;
 
             yield return new WaitForSeconds(0.05f); // update interval
         }
     }

     IEnumerator Timer(){
         yield return new WaitForSeconds(10f);
     }
}
