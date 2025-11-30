using TMPro;
using UnityEngine;

public class AtualizaTextoUpgrades : MonoBehaviour
{
    public TMP_Text dano;
    public TMP_Text knockBack;
    public TMP_Text movimento;
    public TMP_Text vida;
    public TMP_Text regen;
    public TMP_Text tamanho;
    public TMP_Text reflete;
    public TMP_Text delayTiro;
    public TMP_Text penetracao;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    public void AtualizaTextoAtributos()
    {
        dano.text = gameManager.multDano.ToString("F2") + "x";
        knockBack.text = gameManager.multKnockback.ToString("F2") + "x";
        movimento.text = gameManager.multMovimento.ToString("F2") + "x";
        vida.text = (gameManager.multVida * 100).ToString("F0");
        regen.text = gameManager.multRegen.ToString("F1");
        tamanho.text = gameManager.multTamanho.ToString("F2") + "x";
        reflete.text = "+" + (gameManager.refleteBonus * 100).ToString("F0") + "%";
        delayTiro.text = gameManager.multDelayTiro.ToString("F2") + "x";
        penetracao.text = "+" + gameManager.penetracaoBonus.ToString();
    }
}
