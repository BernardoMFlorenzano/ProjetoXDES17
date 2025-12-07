using Unity.Burst.Intrinsics;
using UnityEngine;

public class EscolheArma : MonoBehaviour
{
    [SerializeField] private GameObject armaInv;
    private GameManager gameManager;
    private GameObject menuEscolha;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        menuEscolha = transform.parent.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdicionaEscolha()
    {
        gameManager.AdicionaArmaInventario(armaInv);
        gameManager.escolhendoArma = false;
        menuEscolha.SetActive(false);
        gameManager.PausaJogo();

        foreach (Transform child in transform.parent)
        {
            Destroy(child.gameObject);
        }
    }


}
