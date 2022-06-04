using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeController : MonoBehaviour
{
    public double codeCooldown = 0;
    public int codeEvent;

    public string[] correctPw;
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
            selectedCode = Random.Range(0,5);
            Debug.Log(selectedCode);
            //botar pra mostrar o icone aqui;
        }
        
        if(selectedCode >= 0){
            if(buttonClicked == numOfGuesses)
            {
                if(input == correctPw[selectedCode])
                {
                    Debug.Log("funcionou");
                    buttonClicked = 0;
                    codeCooldown = 0;
                    selectedCode = -1;
                    input = "";
                    //tirar o icone
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
        buttonClicked += 1;
    }
}
