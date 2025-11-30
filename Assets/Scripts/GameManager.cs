using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool pausado = false;
    [SerializeField] GameObject menuPausa;
    public GameObject armaInicial;

    [Header("Atributos")]
    public float multDano = 1f;
    public float multKnockback = 1f;
    public float multMovimento = 1f;
    public float multVida = 1f;
    public float multRegen = 0f;

    // melee
    public float multTamanho = 1f;
    public float refleteBonus = 0f;

    // range
    public float multDelayTiro = 1f;
    public int penetracaoBonus = 0;

    private AtualizaTextoUpgrades textoUpgrades;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textoUpgrades = GetComponent<AtualizaTextoUpgrades>();
        menuPausa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AlteraDano(float val)
    {
        multDano *= val;
        textoUpgrades.AtualizaTextoAtributos();
    }

    public void AlteraKnock(float val)
    {
        multKnockback *= val;
        textoUpgrades.AtualizaTextoAtributos();
    }

    public void AlteraMovimento(float val)
    {
        multMovimento *= val;
        textoUpgrades.AtualizaTextoAtributos();
    }

    public void AlteraVida(float val)
    {
        multVida *= val;
        textoUpgrades.AtualizaTextoAtributos();
    }

    public void AlteraRegen(float val)
    {
        multRegen += val;
        textoUpgrades.AtualizaTextoAtributos();
    }

    public void AlteraTamanho(float val)
    {
        multTamanho *= val;
        textoUpgrades.AtualizaTextoAtributos();
    }

    public void AlteraReflecao(float val)
    {
        refleteBonus += val;
        textoUpgrades.AtualizaTextoAtributos();
    }

    public void AlteraDelayTiro(float val)
    {
        multDelayTiro *= val;
        textoUpgrades.AtualizaTextoAtributos();
    }

    public void AlteraPenetracao(int val)
    {
        penetracaoBonus += val;
        textoUpgrades.AtualizaTextoAtributos();
    }


    public void PausaJogo()
    {
        Debug.Log("Pausou/Despausou");
        if (pausado)
        {
            menuPausa.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            menuPausa.SetActive(true);
            Time.timeScale = 0f;
        }

        pausado = !pausado;
    }

    public void FechaJogo()
    {
        Application.Quit();
    }
}
