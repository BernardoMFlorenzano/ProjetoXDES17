using UnityEngine;

public class InimigoColisor : MonoBehaviour
{
    [SerializeField] private float dano;
    private SistemaVidaPlayer sistemaVidaPlayer;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Coracao"))
        {
            sistemaVidaPlayer = collision.transform.parent.GetComponent<SistemaVidaPlayer>();
            if (sistemaVidaPlayer)
            {
                sistemaVidaPlayer.LevaDano(dano);
            }
        }
    }

}
