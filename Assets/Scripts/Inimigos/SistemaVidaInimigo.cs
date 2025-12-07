using System;
using Unity.Mathematics;
using UnityEngine;

public class SistemaVidaInimigo : MonoBehaviour
{
    [SerializeField] private float vidaMax;
    [SerializeField] private int qntMoedas = 1;
    private ControllerMoedas moedasController;
    private float vidaAtual;
    private Rigidbody2D rb;
    public SpawnerInimigos spawnerInimigos;
    [SerializeField] GameObject efeitoMorte;
    private GameObject efeitoSpawnado;

    [Header("Bosses")]
    public bool boss = false;
    public bool maquina = false;
    public int raridadeRecompensa;
    public GameObject recompensa;
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaAtual = vidaMax;
        rb = GetComponent<Rigidbody2D>();
        spawnerInimigos = GameObject.FindGameObjectWithTag("SpawnerController").GetComponent<SpawnerInimigos>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        moedasController = gameManager.gameObject.GetComponent<ControllerMoedas>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevaDano(float dano)
    {
        vidaAtual -= dano;
        Debug.Log(vidaAtual);

        if (vidaAtual <= 0)
        {
            spawnerInimigos.contInimigos--;
            moedasController.AdicionaMoedas(qntMoedas);
            efeitoSpawnado = Instantiate(efeitoMorte, transform.position, Quaternion.identity);

            if (boss)
            {
                RecompensaArma presente = Instantiate(recompensa, transform.position, quaternion.identity).GetComponent<RecompensaArma>();
                presente.raridade = raridadeRecompensa;
                if (!maquina)
                    gameManager.lutandoComBoss = false;
            }

            Destroy(efeitoSpawnado, 0.25f);
            Destroy(gameObject);
        }

        Debug.Log("Inimigo Levou dano"); 
    }
    
    public void LevaKnockBack(Transform atacante, float knockback, float mult = 1)
    {
        Vector2 direcao = transform.position - atacante.position;
        rb.AddForce(mult*direcao*knockback,ForceMode2D.Impulse);
    }
}
