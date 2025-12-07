using System.Collections.Generic;
using UnityEngine;

public class GeraEscolhaArma : MonoBehaviour
{
    //public List<GameObject> armasInventario;    // Guarda as armas que o player tem atualmente
    public List<GameObject> escolhasNormal;
    public List<GameObject> escolhasIncomum;
    public List<GameObject> escolhasRaro;
    public List<GameObject> escolhasLendário;

    public List<GameObject> escolhasNormalBeta;
    public List<GameObject> escolhasIncomumBeta;
    public List<GameObject> escolhasRaroBeta;
    public List<GameObject> escolhasLendárioBeta;
    private List<GameObject> listaAux;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GeraEscolhas(int raridade)
    {
        if (raridade == 0)
            listaAux = escolhasNormal;
        else if (raridade == 1)
            listaAux = escolhasIncomumBeta;
        else if (raridade == 2)
            listaAux = escolhasRaroBeta;
        else if (raridade == 3)
            listaAux = escolhasLendárioBeta;

        for(int i = 0; i < 3; i++)
        {
            if (listaAux.Count > 0)
            {
                int resultado = Random.Range(0, listaAux.Count);
                Instantiate(listaAux[resultado], transform.GetChild(0));
                listaAux.Remove(listaAux[resultado]);
            }
        }
    }
}
