using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Jogar()
    {
        SceneManager.LoadScene(1);
    }

    public void Configurar()
    {
        // Vai ativar o menu configuração
    }

    public void VoltarAoMenu()
    {
        SceneManager.LoadScene(0);  // adicionar uma janela de "Voce tem certeza"
    }

    public void Sair()
    {
        Application.Quit();
    }
}
