using System.Collections;
using UnityEngine;

public class TiroArma : MonoBehaviour
{
    public float dano;
    public float knockback;
    public int penetracao;
    public float delayTiro;
    public float velTiro;

    [SerializeField] private GameObject tiroPrefab;
    [SerializeField] private Transform pontaArma;
    public bool podeAtirar = true;
    private SistemaVidaInimigo sistemaVidaInimigo;
    private Transform player;
    private GameObject tiro;
    private MovTiro movTiro;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        StartCoroutine(Atira());
    }

    IEnumerator Atira()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayTiro);
            if (podeAtirar)
            {
                tiro = Instantiate(tiroPrefab, pontaArma.position, pontaArma.rotation);
                movTiro = tiro.GetComponent<MovTiro>();
                movTiro.dano = dano;
                movTiro.knockback = knockback;
                movTiro.penetracao = penetracao;
                movTiro.velTiro = velTiro;
                movTiro.player = player;
                // SE TIRO NÃO SE MEXER PODE SER POR CAUSA DAQUI
            }
        }
    }
}
