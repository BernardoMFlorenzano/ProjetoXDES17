using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnInimigoFilho : MonoBehaviour
{
    [SerializeField] private float forcaImpulsoSpawn;
    [SerializeField] private int tipoSpawn; // Conglomerado == 1, vai jogar inimigo no player
    private Coroutine corSpawnFilhos;
    public List<Transform> spawnPoints;
    public List<GameObject> inimigos;
    public float delaySpawn;
    public bool podeSpawnar;
    private int spawnPos;
    private int inimigoEscolha;
    private SistemaVidaInimigo sistemaVidaInimigo;
    private GameObject inimigoSpawnado;
    
    private SpawnerInimigos spawnerPrincipal;
    private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spawnerPrincipal = GameObject.FindGameObjectWithTag("SpawnerController").GetComponent<SpawnerInimigos>();

        podeSpawnar = true;

        corSpawnFilhos = StartCoroutine(SpawnFilhos());
    }

    public IEnumerator SpawnFilhos()
    {
        while (podeSpawnar)
        {
            yield return new WaitForSeconds(delaySpawn);
            spawnPos = Random.Range(0, spawnPoints.Count);
            inimigoEscolha = Random.Range(0, inimigos.Count);

            if (spawnerPrincipal.contInimigos < spawnerPrincipal.maxInimigos)
            {
                inimigoSpawnado = Instantiate(inimigos[inimigoEscolha], spawnPoints[spawnPos].position, quaternion.identity);
                spawnerPrincipal.contInimigos++;
                sistemaVidaInimigo = inimigoSpawnado.GetComponent<SistemaVidaInimigo>();

                yield return new WaitForFixedUpdate();

                if (tipoSpawn == 1)
                {
                    sistemaVidaInimigo.LevaKnockBack(player, forcaImpulsoSpawn, -1);
                }
                else 
                    sistemaVidaInimigo.LevaKnockBack(this.transform, forcaImpulsoSpawn);
            }
        }
    }
}