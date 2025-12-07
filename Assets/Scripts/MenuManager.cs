using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Jogar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void Configurar()
    {
        // Vai ativar o menu configuração
    }

    public void VoltarAoMenu()
    {
        PlayerPrefs.SetInt("Moedas", 0);
        SceneManager.LoadScene(0);  // adicionar uma janela de "Voce tem certeza"
    }

    public void Sair()
    {
        PlayerPrefs.SetInt("Moedas", 0);
        Application.Quit();
    }
}
