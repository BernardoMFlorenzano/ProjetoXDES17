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
    public GameObject armaAtual;
    private GameManager gameManager;
    [SerializeField] private Transform transformPlayer;
    [SerializeField] private float distanciaMax;

    [SerializeField] GameObject slotArmaEquip;

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        comecoBraco = transform.parent;
        TrocaArma(gameManager.armaInicial);
        GameObject armaInv = Instantiate(gameManager.armaInicialInv, slotArmaEquip.transform);
        slotArmaEquip.GetComponent<SlotArma>().armaAtual = armaInv;

        //armaAtual = transform.GetChild(0).gameObject;
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
        if (armaAtual != null)
            Destroy(armaAtual);
        
        if (novaArma != null)
        {
            armaAtual = Instantiate(novaArma, this.transform);

            AtualizaArma(armaAtual);
        }
    }

    public void AtualizaArma(GameObject arma)
    {
        Debug.Log("Atualizou arma");
        TiroArma armaRange = arma.GetComponent<TiroArma>();
        DanoArma armaMelee = arma.GetComponent<DanoArma>();

        if (armaRange != null)
        {
            Debug.Log("Atualizou arma range");
            armaRange.dano = armaRange.danoPadrao * gameManager.multDano;
            armaRange.knockback = armaRange.knockbackPadrao * gameManager.multKnockback;
            armaRange.penetracao = armaRange.penetracaoPadrao + gameManager.penetracaoBonus;
            armaRange.delayTiro = armaRange.delayTiroPadrao / gameManager.multDelayTiro;
        }

        if (armaMelee != null)
        {
            Debug.Log("Atualizou arma melee");
            armaMelee.dano = armaMelee.danoPadrao * gameManager.multDano;
            armaMelee.knockback = armaMelee.knockbackPadrao * gameManager.multKnockback;
            armaMelee.tamanhoMult = armaMelee.tamanhoMultPadrao * gameManager.multTamanho;
            armaMelee.reflecao = armaMelee.reflecaoPadrao + gameManager.refleteBonus;
            armaMelee.AtualizaAtributos();
        }
    }
}
