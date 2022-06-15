using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{   
    public TextMeshProUGUI topText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bottomText;

    public TextMeshProUGUI button;

    void Start()
    {
        scoreText.text =(Mathf.Round(Time.time/60)) + " minutes";
        StartCoroutine(FadeInText(2f, topText));
        StartCoroutine(FadeInText(2f, scoreText));
        StartCoroutine(FadeInText(2f, bottomText));
        StartCoroutine(Timer());
        StartCoroutine(FadeInText(2f, button));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FadeInText(float time, TextMeshProUGUI text)
    {
        yield return new WaitForSeconds(10f);
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / time));
            yield return null;
        }
    }

    IEnumerator Timer(){
         yield return new WaitForSeconds(5f);
     }

    public void BackToMenu(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
