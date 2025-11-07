using UnityEngine;
using UnityEngine.InputSystem;

public class MovTiro : MonoBehaviour
{
    public float dano;
    public float knockback;
    public int penetracao = 0;
    public float velTiro;
    public Transform player;

    private Rigidbody2D rb;
    private SistemaVidaInimigo sistemaVidaInimigo;
    private Vector3 mousePos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
        mousePos.z = 0f;
        rb.linearVelocity = velTiro * (mousePos - player.position).normalized;
        Destroy(gameObject, 10f);
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

            penetracao -= 1;

            if (penetracao <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
