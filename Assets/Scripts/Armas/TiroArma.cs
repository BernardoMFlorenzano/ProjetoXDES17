using System.Collections;
using UnityEngine;

public class TiroArma : MonoBehaviour
{
    [Header("Atributos padrão")]
    public float danoPadrao;
    public float knockbackPadrao;
    public int penetracaoPadrao;
    public float delayTiroPadrao;
    [Header("Atributos com modificadores")]
    public float dano;
    public float knockback;
    public int penetracao;
    public float delayTiro;
    public float velTiro;

    [SerializeField] private GameObject tiroPrefab;
    public Transform pontaArma;
    public bool podeAtirar = true;
    private SistemaVidaInimigo sistemaVidaInimigo;
    public Transform player;
    private GameObject tiro;
    private MovTiro movTiro;
    private TiroEspecial tiroEspecial;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        tiroEspecial = GetComponent<TiroEspecial>();
        StartCoroutine(Atira());
    }

    IEnumerator Atira()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayTiro);
            if (podeAtirar)
            {
                tiroEspecial.AtiraEspecial(tiroPrefab);
            }
        }
    }
}
