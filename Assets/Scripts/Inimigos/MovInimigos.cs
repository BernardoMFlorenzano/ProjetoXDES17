using UnityEngine;

public class MovInimigos : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb;
    private Vector2 direcaoPlayer;
    private bool virado = false;
    [SerializeField] private float velInimigo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        direcaoPlayer = player.position - transform.position;
        direcaoPlayer.Normalize();

        rb.AddForce(direcaoPlayer * velInimigo);

        if (player.position.x < transform.position.x)
        {
            if (!virado)
                Flip();
        }
        else
        {
            if (virado)
                Flip();
        }
    }

    void Flip()
    {
        virado = !virado;
        transform.Rotate(0, 180, 0); // roda em 180 para objeto flipar
    }
}
