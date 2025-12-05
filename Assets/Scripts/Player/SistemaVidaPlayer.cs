using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SistemaVidaPlayer : MonoBehaviour
{
    [Header("Atributos padrão")]
    public float vidaMaxPadrao = 100f;
    public float vidaRegenPadrao = 0f;
    [Header("Atributos com modificadores")]
    public float vidaMax;
    public float vidaRegen;

    public bool podeLevarDano;
    [SerializeField] private Slider sliderVida;
    private float vidaAtual;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaAtual = vidaMax;
        sliderVida.value = 1f;
        podeLevarDano = true;
        StartCoroutine(RegenVida());
    }

    IEnumerator RegenVida()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            vidaAtual += vidaRegen;
            AtualizaSlider();
        }
    }

    public void LevaDano(float dano)
    {
        if (!podeLevarDano)
            return;

        vidaAtual -= dano;
        AtualizaSlider();

        if (vidaAtual <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        Debug.Log("Player Levou dano"); 
    }

    public void AtualizaSlider()
    {
        sliderVida.value = vidaAtual/vidaMax;
    }

}
