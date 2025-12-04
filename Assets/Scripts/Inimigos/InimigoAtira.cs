using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoAtira : MonoBehaviour
{
    /*
    public float dano;
    public float knockback;
    public float velTiro;
    */

    public float delayTiro;

    [SerializeField] private List<GameObject> tiroPrefabs;
    [SerializeField] private Transform pontaArma;
    public bool podeAtirar = true;
    //private SistemaVidaInimigo sistemaVidaInimigo;
    private Transform player;
    //private GameObject tiro;
    private MovTiroInimigo movTiroInimigo;
    
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
                int escolha = 0;
                if (tiroPrefabs.Count > 1)
                {
                    escolha = Random.Range(0, tiroPrefabs.Count);
                }
                Instantiate(tiroPrefabs[escolha], pontaArma.position, pontaArma.rotation);
                //movTiroInimigo = tiro.GetComponent<MovTiroInimigo>();
            }
        }
    }
}
