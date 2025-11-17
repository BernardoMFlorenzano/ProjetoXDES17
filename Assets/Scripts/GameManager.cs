using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool pausado = false;
    [SerializeField] GameObject menuPausa;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuPausa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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
