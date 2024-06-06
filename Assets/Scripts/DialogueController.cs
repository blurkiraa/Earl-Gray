using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using Unity.VisualScripting;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI componenteTexto;
    [SerializeField] private TextMeshProUGUI componenteNome;
    [SerializeField] private string[] falas;
    [SerializeField] private float velocidadeTexto;
    private int index;

    void Start()
    {
        componenteTexto.text = string.Empty;
        ComecarDialogo();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (componenteTexto.text == falas[index])
            {
                ProximaFala();
            }
            else
            {
                StopAllCoroutines();
                componenteTexto.text = falas[index];
            }
        }
    }
    void ComecarDialogo()
    {
        index = 0;
        StartCoroutine(EscreverFala());
    }
    // Efeito máquina de escrever
    IEnumerator EscreverFala()
    {
        foreach (char c in falas[index].ToCharArray())
        {
            componenteTexto.text += c;
            yield return new WaitForSeconds(velocidadeTexto);
        }
    }
    void ProximaFala()
    {
        if (index < falas.Length - 1)
        {
            index++;
            componenteTexto.text = string.Empty;
            StartCoroutine(EscreverFala());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
