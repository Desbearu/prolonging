using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeController : MonoBehaviour
{
    public double codeCooldown = 0;
    public int codeEvent;
    public GameObject light;

    public string[] correctPw;
    public GameObject[] codes;
    public GameObject[] pressedButtons;
    private string input;
    private int selectedCode = -1;
    
    private float buttonClicked = 0;
    private float numOfGuesses;
    // Start is called before the first frame update
    void Start()
    {
        buttonClicked = 0;
        numOfGuesses = correctPw[0].Length;
    }

    // Update is called once per frame
    void Update()
    {
        codeCooldown += 0.05;
        if(codeCooldown >= codeEvent && selectedCode < 0)
        {
            selectedCode = Random.Range(0,4);
            Debug.Log(selectedCode);
            codes[selectedCode].SetActive(true);
            light.SetActive(true);
        }
        
        if(selectedCode >= 0){
            if(buttonClicked == numOfGuesses)
            {
                if(input == correctPw[selectedCode])
                {
                    buttonClicked = 0;
                    codeCooldown = 0;
                    input = "";
                    codes[selectedCode].SetActive(false);
                    selectedCode = -1;
                    light.SetActive(false);
                }
                else
                {
                    Debug.Log("n funcionou");
                    Debug.Log(input);
                    buttonClicked = 0;
                    input = "";
                }
            }
        }
    }

    public void GetButtonPressedName(string name)
    {
        input += name;
        int num = int.Parse(name);
        num = num - 1;
        pressedButtons[num].SetActive(true);
        buttonClicked += 1;
        StartCoroutine(Timer(num));
    }

    IEnumerator Timer(int num){
        yield return new WaitForSeconds(0.3f);
        pressedButtons[num].SetActive(false); 
    }
}
