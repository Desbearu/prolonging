using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public Image sprite;
    public Image backgroundImage;
    public GameObject canvas;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

     private IEnumerator FadeIn()
     {
         float alphaVal = sprite.color.a;
         Color tmp = sprite.color;
 
         while (sprite.color.a < 1)
         {
             alphaVal += 0.1f;
             tmp.a = alphaVal;
             sprite.color = tmp;

             yield return new WaitForSeconds(0.05f); // update interval
         }
        yield return new WaitForSeconds(10f);
        StartCoroutine(Timer());
        StartCoroutine(FadeOut(sprite));
        StartCoroutine(FadeOut(backgroundImage));
     }
 
     private IEnumerator FadeOut(Image sprite)
     {
         float alphaVal = sprite.color.a;
         Color tmp = sprite.color;

         while (sprite.color.a > 0)
         {
             alphaVal -= 0.01f;
             tmp.a = alphaVal;
             sprite.color = tmp;
 
             yield return new WaitForSeconds(0.05f); // update interval
         }
         canvas.SetActive(false);
     }

     IEnumerator Timer(){
         yield return new WaitForSeconds(60f);
     }
}
