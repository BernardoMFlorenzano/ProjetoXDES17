using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerInimigos : MonoBehaviour
{
    private Coroutine corSpawn;
    private GameManager gameManager;
    private List<Transform> spawnPoints;
    public List<GameObject> inimigos;
    public float delaySpawn;
    public bool podeSpawnar;
    private int spawnPos;
    private int inimigoEscolha;

    public int contInimigos = 0;
    public int maxInimigos = 50;
    public int inimigosSpawnados = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        spawnPoints = new List<Transform>();
        foreach (Transform child in transform)
        {
            child.position = new Vector3(child.position.x, child.position.y, 0f);   // zera o z
            spawnPoints.Add(child);
        }

        podeSpawnar = true;

        corSpawn = StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        while (true)
        {
            if (podeSpawnar)
            {
                spawnPos = Random.Range(0, spawnPoints.Count);
                inimigoEscolha = Random.Range(0, inimigos.Count);

                if (contInimigos < maxInimigos)
                {
                    Instantiate(inimigos[inimigoEscolha], spawnPoints[spawnPos].position, quaternion.identity);
                    contInimigos++;
                    if(!gameManager.lutandoComBoss)
                        inimigosSpawnados++;
                }
            }
            yield return new WaitForSeconds(delaySpawn);
        }
    }

    public void SpawnInimigo(GameObject inimigo)
    {
        spawnPos = Random.Range(0, spawnPoints.Count);
        Instantiate(inimigo, spawnPoints[spawnPos].position, quaternion.identity);
    }

    public void Respawn(Transform inimigoRespawnado)
    {
        spawnPos = Random.Range(0, spawnPoints.Count);
        inimigoRespawnado.position = spawnPoints[spawnPos].position;
    }
}
