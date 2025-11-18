using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jogar()
    {
        SceneManager.LoadScene(1);
    }

    public void Configurar()
    {
        // Vai ativar o menu configuração
    }

    public void Sair()
    {
        Application.Quit();
    }
}
