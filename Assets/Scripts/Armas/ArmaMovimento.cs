using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class ArmaMovimento : MonoBehaviour
{
    //private Camera mainCamera;
    private Vector3 mousePos;
    private Vector3 rotacao;
    private float rotacaoArma;
    private Transform comecoBraco;
    private float distancia;
    private bool playerVirado = false;
    private GameObject armaAtual;
    [SerializeField] private Transform transformPlayer;
    [SerializeField] private float distanciaMax;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        comecoBraco = transform.parent;
        armaAtual = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
        mousePos.z = 0f;
        distancia = Vector2.Distance(comecoBraco.position, mousePos);

        rotacao = mousePos - comecoBraco.position;

        rotacaoArma = Mathf.Atan2(rotacao.y, rotacao.x) * Mathf.Rad2Deg;

        if (mousePos.x < comecoBraco.position.x)
        {
            if (!playerVirado)
                Flip();
        }
        else
        {
            if (playerVirado)
                Flip();
        }
        transform.rotation = Quaternion.Euler(0, 0, rotacaoArma);

        if (distancia < distanciaMax)
        {
            transform.position = mousePos;
        }
        else
        {
            transform.position = comecoBraco.position + rotacao.normalized * distanciaMax;
        }



    }

    void Flip()
    {
        playerVirado = !playerVirado;
        transformPlayer.Rotate(0, 180, 0); // roda em 180 para objeto flipar
    }

    public void TrocaArma(GameObject novaArma)
    {
        Destroy(armaAtual);
        armaAtual = Instantiate(novaArma, this.transform);
    }

}
