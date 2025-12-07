using UnityEngine;

public class RecompensaArma : MonoBehaviour
{
    public int raridade;
    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.geraEscolhaArma.gameObject.SetActive(true);
            gameManager.geraEscolhaArma.GeraEscolhas(raridade);
            gameManager.escolhendoArma = true;
            gameManager.PausaJogo();
            Destroy(gameObject);
        }
    }
}
