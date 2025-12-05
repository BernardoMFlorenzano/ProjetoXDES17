using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentoPlayer : MonoBehaviour
{
    public float velPlayerPadrao = 5f;
    public float velPlayer;
    [SerializeField] private Animator animatorPlayer;
    private Vector2 direcaoMov;
    private Rigidbody2D rb;

    [Header("Arma")]
    public ArmaMovimento armaScript;

    private GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        TrocaArmaPlayer(gameManager.armaInicial);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velPlayer = velPlayerPadrao;
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
        armaScript.TrocaArma(armaNova);
    }


    // Função pra abrir inventario
    void OnInventario()
    {
        gameManager.AbreInventario();
    }

    // Função pra abrir menu upgrade
    void OnUpgrade()
    {
        gameManager.AbreUpgrades();
    }
}
