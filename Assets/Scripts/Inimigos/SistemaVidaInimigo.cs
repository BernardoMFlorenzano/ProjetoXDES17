using System;
using UnityEngine;

public class SistemaVidaInimigo : MonoBehaviour
{
    [SerializeField] private float vidaMax;
    [SerializeField] private int qntMoedas = 1;
    private ControllerMoedas moedasController;
    private float vidaAtual;
    private Rigidbody2D rb;
    private SpawnerInimigos spawnerInimigos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaAtual = vidaMax;
        rb = GetComponent<Rigidbody2D>();
        spawnerInimigos = GameObject.FindGameObjectWithTag("SpawnerController").GetComponent<SpawnerInimigos>();
        moedasController = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ControllerMoedas>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevaDano(float dano)
    {
        vidaAtual -= dano;

        if (vidaAtual <= 0)
        {
            spawnerInimigos.contInimigos--;
            moedasController.AdicionaMoedas(qntMoedas);
            Destroy(gameObject);
        }

        Debug.Log("Inimigo Levou dano"); 
    }
    
    public void LevaKnockBack(Transform atacante, float knockback)
    {
        Vector2 direcao = transform.position - atacante.position;
        rb.AddForce(direcao*knockback,ForceMode2D.Impulse);
    }
}
