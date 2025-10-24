using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentoPlayer : MonoBehaviour
{
    [SerializeField] private float velPlayer;
    [SerializeField] private Animator animatorPlayer;
    private Vector2 direcaoMov;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue direcao)
    {
        direcaoMov = direcao.Get<Vector2>().normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (animatorPlayer)
            animatorPlayer.SetFloat("Vel", Mathf.Abs(direcaoMov.magnitude));
        rb.linearVelocity = direcaoMov * velPlayer;
    }


    // Função temporaria pra fechar o jogo
    void OnSai()
    {
        Application.Quit();
    }
}
