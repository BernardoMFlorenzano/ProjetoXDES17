using UnityEngine;

public class DanoArma : MonoBehaviour
{
    [SerializeField] private float dano;
    [SerializeField] private float knockback;
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
