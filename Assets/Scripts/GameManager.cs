using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool pausado = false;
    [SerializeField] GameObject menuInventario;
    [SerializeField] GameObject menuUpgrade;
    public GameObject armaInicial;
    public GameObject armaInicialInv;
    [SerializeField] Transform SlotsParent;
    public List<GameObject> listaSlotInv;

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

    [Header("Custo Atributos")]

    public int danoCusto = 3;
    public int knockbackCusto = 3;
    public int movimentoCusto = 3;
    public int vidaCusto = 3;
    public int regenCusto = 3;

    // melee
    public int tamanhoCusto = 3;
    public int refleteCusto = 3;

    // range
    public int delayTiroCusto = 3;
    public int penetracaoCusto = 30;

    private AtualizaTextoUpgrades textoUpgrades;
    private ControllerMoedas controllerMoedas;
    private GameObject player;
    private SistemaVidaPlayer sistemaVidaPlayer;
    private MovimentoPlayer movimentoPlayer;
    private ArmaMovimento armaScript;
    [SerializeField] private SpawnerInimigos spawnerInimigos;

    [Header("Progressao Jogo")] 
    public bool lutandoComBoss = false;
    public List<GameObject> listaBosses;
    public List<int> inimigosSpawnadosFases;
    public GameObject doutorPorqueFinal;
    public GameObject maquinaFeia;

    [Header("Fases de waves")]
    public List<GameObject> inimigosFase1;
    public List<GameObject> inimigosBoss1;
    public List<GameObject> inimigosFase2;
    public List<GameObject> inimigosBoss2;
    public List<GameObject> inimigosFase3;
    public List<GameObject> inimigosBoss3;
    public List<GameObject> inimigosFase4;
    public List<GameObject> inimigosBoss4;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textoUpgrades = GetComponent<AtualizaTextoUpgrades>();
        controllerMoedas = GetComponent<ControllerMoedas>();

        player = GameObject.FindGameObjectWithTag("Player");
        sistemaVidaPlayer = player.GetComponent<SistemaVidaPlayer>();
        movimentoPlayer = player.GetComponent<MovimentoPlayer>();
        armaScript = GameObject.FindGameObjectWithTag("ArmaPlayer").GetComponent<ArmaMovimento>();


        for(int i = 7; i < 15; i++)
        {
            listaSlotInv.Add(SlotsParent.GetChild(i).gameObject);
        }

        menuInventario.SetActive(false);
        menuUpgrade.SetActive(false);

        spawnerInimigos.inimigos = inimigosFase1;

        StartCoroutine(ProgressaoJogo());
    }

    IEnumerator ProgressaoJogo()
    {
        int contBoss = 0;
        spawnerInimigos.delaySpawn = 4;

        // Fase 1
        yield return new WaitUntil(() => spawnerInimigos.inimigosSpawnados >= inimigosSpawnadosFases[contBoss]/4);
        spawnerInimigos.delaySpawn = 2;

        yield return new WaitUntil(() => spawnerInimigos.inimigosSpawnados >= inimigosSpawnadosFases[contBoss]/2);
        spawnerInimigos.delaySpawn = 1;

        // Boss 1
        yield return new WaitUntil(() => spawnerInimigos.inimigosSpawnados >= inimigosSpawnadosFases[contBoss]);
        spawnerInimigos.inimigos = inimigosBoss1;
        spawnerInimigos.SpawnInimigo(listaBosses[contBoss]);
        spawnerInimigos.maxInimigos = 100;
        spawnerInimigos.delaySpawn = 3;
        lutandoComBoss = true;
        contBoss += 1;

        // Fase 2
        yield return new WaitUntil(() => lutandoComBoss == false);
        spawnerInimigos.inimigos = inimigosFase2;
        spawnerInimigos.maxInimigos = 200;
        spawnerInimigos.delaySpawn = 3;

        yield return new WaitUntil(() => spawnerInimigos.inimigosSpawnados >= inimigosSpawnadosFases[contBoss]/4);
        spawnerInimigos.delaySpawn = 2;

        yield return new WaitUntil(() => spawnerInimigos.inimigosSpawnados >= inimigosSpawnadosFases[contBoss]/2);
        spawnerInimigos.delaySpawn = 1;

        // Boss 2
        yield return new WaitUntil(() => spawnerInimigos.inimigosSpawnados >= inimigosSpawnadosFases[contBoss]);
        spawnerInimigos.inimigos = inimigosBoss2;
        spawnerInimigos.SpawnInimigo(listaBosses[contBoss]);
        spawnerInimigos.maxInimigos = 400;
        spawnerInimigos.delaySpawn = 2;
        lutandoComBoss = true;
        contBoss += 1;

        // Fase 3
        yield return new WaitUntil(() => lutandoComBoss == false);
        spawnerInimigos.inimigos = inimigosFase3;
        spawnerInimigos.maxInimigos = 800;
        spawnerInimigos.delaySpawn = 2;

        yield return new WaitUntil(() => spawnerInimigos.inimigosSpawnados >= inimigosSpawnadosFases[contBoss]/4);
        spawnerInimigos.delaySpawn = 1;

        yield return new WaitUntil(() => spawnerInimigos.inimigosSpawnados >= inimigosSpawnadosFases[contBoss]/2);
        spawnerInimigos.delaySpawn = 0.5f;

        // Boss 3
        yield return new WaitUntil(() => spawnerInimigos.inimigosSpawnados >= inimigosSpawnadosFases[contBoss]);
        spawnerInimigos.inimigos = inimigosBoss3;
        spawnerInimigos.SpawnInimigo(listaBosses[contBoss]);
        spawnerInimigos.maxInimigos = 1600;
        spawnerInimigos.delaySpawn = 0.5f;
        lutandoComBoss = true;
        contBoss += 1;

        // Fase Final
        yield return new WaitUntil(() => lutandoComBoss == false);
        spawnerInimigos.inimigos = inimigosFase4;
        spawnerInimigos.maxInimigos = 3200;
        spawnerInimigos.delaySpawn = 0.5f;

        yield return new WaitUntil(() => spawnerInimigos.inimigosSpawnados >= inimigosSpawnadosFases[contBoss]/4);
        spawnerInimigos.delaySpawn = 0.25f;

        yield return new WaitUntil(() => spawnerInimigos.inimigosSpawnados >= inimigosSpawnadosFases[contBoss]/2);
        spawnerInimigos.delaySpawn = 0.1f;

        // Boss Final
        yield return new WaitUntil(() => spawnerInimigos.inimigosSpawnados >= inimigosSpawnadosFases[contBoss]);
        spawnerInimigos.inimigos = inimigosBoss4;
        spawnerInimigos.SpawnInimigo(doutorPorqueFinal);
        spawnerInimigos.SpawnInimigo(maquinaFeia);
        spawnerInimigos.maxInimigos = 6400;
        spawnerInimigos.delaySpawn = 2;

        lutandoComBoss = true;

        yield return new WaitUntil(() => lutandoComBoss == false);

        // Acaba jogo
    }

    public void AdicionaArmaInventario(GameObject armaInv)
    {
        foreach(GameObject slot in listaSlotInv)
        {
            if (slot.GetComponent<SlotArma>().armaAtual == null)
            {
                GameObject novaArmaInv = Instantiate(armaInv, slot.transform);
                slot.GetComponent<SlotArma>().armaAtual = novaArmaInv;
                break;
            }
        }
    }

    // TESTE
    public void AdicionaItem(GameObject itemInv)
    {
        AdicionaArmaInventario(itemInv);
    }

    public void AtualizaAtributosPlayer()
    {
        movimentoPlayer.velPlayer = movimentoPlayer.velPlayerPadrao * multMovimento;
        sistemaVidaPlayer.vidaMax = sistemaVidaPlayer.vidaMaxPadrao * multVida;
        sistemaVidaPlayer.vidaRegen = sistemaVidaPlayer.vidaRegenPadrao + multRegen;
    }

    public void AlteraDano(float val)
    {
        if (controllerMoedas.GastaMoedas(danoCusto))
        {
            multDano *= val;
            danoCusto = Mathf.CeilToInt(danoCusto * 1.333f);
        }

        armaScript.AtualizaArma(armaScript.armaAtual);
        AtualizaAtributosPlayer();
        textoUpgrades.AtualizaTextoAtributos();
    }

    public void AlteraKnock(float val)
    {
        if (controllerMoedas.GastaMoedas(knockbackCusto))
        {
            multKnockback *= val;
            knockbackCusto = Mathf.CeilToInt(knockbackCusto * 1.333f);
        }

        armaScript.AtualizaArma(armaScript.armaAtual);
        AtualizaAtributosPlayer();
        textoUpgrades.AtualizaTextoAtributos();
    }

    public void AlteraMovimento(float val)
    {
        if (controllerMoedas.GastaMoedas(movimentoCusto))
        {
            multMovimento *= val;
            movimentoCusto = Mathf.CeilToInt(movimentoCusto * 1.333f);
        }

        armaScript.AtualizaArma(armaScript.armaAtual);
        AtualizaAtributosPlayer();
        textoUpgrades.AtualizaTextoAtributos();
    }

    public void AlteraVida(float val)
    {
        if (controllerMoedas.GastaMoedas(vidaCusto))
        {
            multVida *= val;
            vidaCusto = Mathf.CeilToInt(vidaCusto * 1.333f);
        }

        armaScript.AtualizaArma(armaScript.armaAtual);
        AtualizaAtributosPlayer();
        textoUpgrades.AtualizaTextoAtributos();
    }

    public void AlteraRegen(float val)
    {
        if (controllerMoedas.GastaMoedas(regenCusto))
        {
            multRegen += val;
            regenCusto = Mathf.CeilToInt(regenCusto * 1.333f);
        }
                
        armaScript.AtualizaArma(armaScript.armaAtual);
        AtualizaAtributosPlayer();
        textoUpgrades.AtualizaTextoAtributos();
    }

    public void AlteraTamanho(float val)
    {
        if (controllerMoedas.GastaMoedas(tamanhoCusto))
        {
            multTamanho *= val;
            tamanhoCusto = Mathf.CeilToInt(tamanhoCusto * 1.333f);
        }
                
        armaScript.AtualizaArma(armaScript.armaAtual);
        AtualizaAtributosPlayer();
        textoUpgrades.AtualizaTextoAtributos();
    }

    public void AlteraReflecao(float val)
    {
        if (controllerMoedas.GastaMoedas(refleteCusto))
        {
            refleteBonus += val;
            refleteCusto = Mathf.CeilToInt(refleteCusto * 1.333f);
        }
                
        armaScript.AtualizaArma(armaScript.armaAtual);
        AtualizaAtributosPlayer();
        textoUpgrades.AtualizaTextoAtributos();
    }

    public void AlteraDelayTiro(float val)
    {
        if (controllerMoedas.GastaMoedas(delayTiroCusto))
        {
            multDelayTiro *= val;
            delayTiroCusto = Mathf.CeilToInt(delayTiroCusto * 1.333f);
        }
                
        armaScript.AtualizaArma(armaScript.armaAtual);
        AtualizaAtributosPlayer();
        textoUpgrades.AtualizaTextoAtributos();
    }

    public void AlteraPenetracao(int val)
    {
        if (controllerMoedas.GastaMoedas(penetracaoCusto))
        {
            penetracaoBonus += val;
            penetracaoCusto = Mathf.CeilToInt(penetracaoCusto * 1.333f);
        }
                
        armaScript.AtualizaArma(armaScript.armaAtual);
        AtualizaAtributosPlayer();
        textoUpgrades.AtualizaTextoAtributos();
    }


    public void PausaJogo()
    {
        Debug.Log("Pausou/Despausou");
        if (pausado)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }

        pausado = !pausado;
    }

    public void AbreInventario()
    {
        PausaJogo();
        if (pausado)
        {
            menuInventario.SetActive(true);
        }
        else
        {
            menuInventario.SetActive(false);
            menuUpgrade.SetActive(false);
        }
    }

    public void AbreUpgrades()
    {
        PausaJogo();
        if (pausado)
        {
            menuUpgrade.SetActive(true);
        }
        else
        {
            menuInventario.SetActive(false);
            menuUpgrade.SetActive(false);
        }
    }

    public void FechaJogo()
    {
        Application.Quit();
    }
}
