using UnityEngine;
using UnityEngine.SceneManagement;

public class SistemaVidaPlayer : MonoBehaviour
{
    [SerializeField] private float vidaMax;
    private float vidaAtual;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaAtual = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevaDano(float dano)
    {
        vidaAtual -= dano;

        if (vidaAtual <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        Debug.Log("Player Levou dano"); 
    }

}
