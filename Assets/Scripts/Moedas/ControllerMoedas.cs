using UnityEngine;
using TMPro;

public class ControllerMoedas : MonoBehaviour
{
    [SerializeField] private TMP_Text numMoedas;
    private int moedas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moedas = PlayerPrefs.GetInt("Moedas", 0);
        numMoedas.text = moedas.ToString();
    }

    public void AdicionaMoedas(int qnt)
    {
        moedas = PlayerPrefs.GetInt("Moedas", 0);
        PlayerPrefs.SetInt("Moedas", moedas + qnt);
        numMoedas.text = (moedas + qnt).ToString();
    }
    
    public bool GastaMoedas(int qnt)
    {
        moedas = PlayerPrefs.GetInt("Moedas", 0);
        if (moedas - qnt < 0)
            return false;
        PlayerPrefs.SetInt("Moedas", moedas - qnt);
        numMoedas.text = (moedas - qnt).ToString();
        return true;
    }
}
