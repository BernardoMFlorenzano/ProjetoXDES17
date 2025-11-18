using UnityEngine;

public class SlotArma : MonoBehaviour
{
    public GameObject armaAtual; 
    private GameObject player;
    private MovimentoPlayer atributosPlayer;
    private ArmaMovimento armaScript;
    public int tipo; // 0 == Arma principal player, 1 == Arma companion 1, 2 == Arma companion 2, 3 == Arma companion 3

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        atributosPlayer = player.GetComponent<MovimentoPlayer>();
        armaScript = atributosPlayer.armaScript;

        //TrocaArma();
    }

    public void TrocaArma()
    {
        if (tipo == 0)
        {
            TrocaArmaPlayer();
        }
        else if (tipo == 1)
        {
            // Troca arma do companion 1
        }
        else if (tipo == 2)
        {
            // Troca arma do companion 2
        }
        else if (tipo == 3)
        {
            // Troca arma do companion 3
        }
    }

    void TrocaArmaPlayer()
    {
        if (armaAtual != null)
        {
            armaScript.TrocaArma(armaAtual.GetComponent<ItemDrag>().itemReal,atributosPlayer.multDano,atributosPlayer.multKnockback,atributosPlayer.multTamanho,atributosPlayer.multReflete,atributosPlayer.multDelayTiro,atributosPlayer.penetracaoBonus);
        }
        else
        {
            armaScript.TrocaArma(null, atributosPlayer.multDano,atributosPlayer.multKnockback,atributosPlayer.multTamanho,atributosPlayer.multReflete,atributosPlayer.multDelayTiro, atributosPlayer.penetracaoBonus);
        }
    }
}
