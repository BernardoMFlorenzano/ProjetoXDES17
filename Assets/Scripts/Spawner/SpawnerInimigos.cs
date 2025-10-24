using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerInimigos : MonoBehaviour
{
    private Coroutine corSpawn;
    private List<Transform> spawnPoints;
    public List<GameObject> Inimigos;
    public float delaySpawn;
    public bool podeSpawnar;
    private int spawnPos;
    private int inimigoEscolha;

    public int contInimigos = 0;
    public int maxInimigos = 50;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPoints = new List<Transform>();
        foreach (Transform child in transform)
        {
            child.position = new Vector3(child.position.x, child.position.y, 0f);   // zera o z
            spawnPoints.Add(child);
        }

        podeSpawnar = true;

        corSpawn = StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public IEnumerator Spawn()
    {
        while (podeSpawnar)
        {
            spawnPos = Random.Range(0, spawnPoints.Count);
            inimigoEscolha = Random.Range(0, Inimigos.Count);

            if (contInimigos < maxInimigos)
            {
                Instantiate(Inimigos[inimigoEscolha], spawnPoints[spawnPos].position, quaternion.identity);
                contInimigos++;
            }
            
            yield return new WaitForSeconds(delaySpawn);
        }
    }
}
