using UnityEngine;

public class DanoArma : MonoBehaviour
{
    [Header("Atributos padrão")]
    public float danoPadrao;
    public float knockbackPadrao;
    public float tamanhoMultPadrao;
    public float reflecaoPadrao;
    [Header("Atributos com modificadores")]
    public float dano;
    public float knockback;
    public float tamanhoMult;
    public float reflecao;
    private SistemaVidaInimigo sistemaVidaInimigo;
    private Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AtualizaAtributos()
    {
        transform.localScale = new Vector3(1 * tamanhoMult, 1 * tamanhoMult, 1);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Inimigo"))
        {
            sistemaVidaInimigo = collision.GetComponent<SistemaVidaInimigo>();
            if (sistemaVidaInimigo)
            {
                sistemaVidaInimigo.LevaDano(dano);
                sistemaVidaInimigo.LevaKnockBack(player, knockback);
            }
        }
    }
}
