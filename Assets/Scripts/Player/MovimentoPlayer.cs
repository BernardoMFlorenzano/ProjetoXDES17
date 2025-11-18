using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentoPlayer : MonoBehaviour
{
    [SerializeField] private float velPlayer;
    [SerializeField] private Animator animatorPlayer;
    private Vector2 direcaoMov;
    private Rigidbody2D rb;

    [Header("Atributos")]
    public float multDano = 1f;
    public float multKnockback = 1f;
    public float multMovimento = 1f;
    public float multVida = 1f;
    public float multRegen = 1f;

    // melee
    public float multTamanho = 1f;
    public float multReflete = 1f;

    // range
    public float multDelayTiro = 1f;
    public int penetracaoBonus = 0;

    [Header("Arma")]
    public ArmaMovimento armaScript;
    public GameObject armaInicial;

    private GameManager gameManager;

    void Awake()
    {
        TrocaArmaPlayer(armaInicial);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
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

    public void TrocaArmaPlayer(GameObject armaNova)
    {
        armaScript.TrocaArma(armaNova, multDano, multKnockback, multTamanho, multReflete, multDelayTiro, penetracaoBonus);
    }


    // Função pra pausar o jogo
    void OnPausa()
    {
        gameManager.PausaJogo();
    }
}
