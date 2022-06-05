using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarButton : MonoBehaviour
{   
    public bool botaoAtivo = false;

    public GameObject botaoFechado;
    public GameObject botaoAberto;
    public GameObject botaoApertado;

    private BoxCollider2D col;

    public bool activeCooldown;

    void Start()
    {
        botaoFechado = GameObject.Find("botao-fechado");
        botaoAberto = GameObject.Find("botao-aberto");
        botaoAberto.SetActive(false);
        botaoApertado = GameObject.Find("botao-apertado");
        botaoApertado.SetActive(false);
        col = gameObject.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if(activeCooldown == true)
        {
            col.enabled = false;
            StartCoroutine(ShootingCooldown());

        }
    }

    public void OpenButton(){
        botaoFechado.SetActive(false);
        botaoAberto.SetActive(true);
        botaoAtivo = true;
    }

    IEnumerator ShootingCooldown(){
        yield return new WaitForSeconds(5);
        col.enabled = true;
        activeCooldown = false;
    }
}
