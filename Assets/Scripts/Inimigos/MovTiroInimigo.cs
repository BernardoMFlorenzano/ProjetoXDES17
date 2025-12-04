using UnityEngine;

public class MovTiroInimigo : MonoBehaviour
{
    public float dano;
    public float knockback;
    public float velTiro;
    private Transform player;

    private Rigidbody2D rb;
    private Vector3 direcao;
    private SistemaVidaPlayer sistemaVidaPlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        direcao = (player.position - transform.position).normalized;
        rb.linearVelocity = velTiro * direcao;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg));

        Destroy(gameObject, 10f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Coracao"))
        {
            sistemaVidaPlayer = collision.transform.parent.GetComponent<SistemaVidaPlayer>();
            if (sistemaVidaPlayer)
            {
                sistemaVidaPlayer.LevaDano(dano);
                //sistemaVidaPlayer.LevaKnockBack(player, knockback);
            }

            Destroy(gameObject);
        }
    }

}
