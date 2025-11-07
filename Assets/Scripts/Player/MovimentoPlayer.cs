using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentoPlayer : MonoBehaviour
{
    [SerializeField] private float velPlayer;
    [SerializeField] private Animator animatorPlayer;
    private Vector2 direcaoMov;
    private Rigidbody2D rb;
    [Header("Teste")]
    [SerializeField] private ArmaMovimento armaScript;
    [SerializeField] private GameObject arma1;
    [SerializeField] private GameObject arma2;
    private int armaAtual = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue direcao)
    {
        direcaoMov = direcao.Get<Vector2>().normalized;
    }

    void OnTrocaArma()
    {
        if (armaAtual == 1)
        {
            armaScript.TrocaArma(arma2);
            armaAtual = 2;
        }
        else
        {
            armaScript.TrocaArma(arma1);
            armaAtual = 1;
        }
            
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
