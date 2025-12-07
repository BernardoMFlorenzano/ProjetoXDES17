using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class TiroEspecial : MonoBehaviour
{
    private TiroArma tiroArma;
    public int arma;    // 1==38,2==escopeta,3==ak,4==lancaBatata,5==lancaChamas,6==Bazuca,7==laserzin,8==minigun,9==katiaFlavia,10==laserOrbital,11==railgun,12=espadaHeroi
    private MovTiro movTiro;
    private GameObject tiro;
    [Header("Variacao precisao")]
    [SerializeField] private float rangeVarVel = 5f;
    [SerializeField] private float rangeVarRot = 15f;

    void Start()
    {
        tiroArma = GetComponent<TiroArma>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtiraEspecial(GameObject tiroPrefab)
    {
        // 38
        if (arma == 1)
        {
            tiro = Instantiate(tiroPrefab, tiroArma.pontaArma.position, tiroArma.pontaArma.rotation);
            movTiro = tiro.GetComponent<MovTiro>();
            movTiro.dano = tiroArma.dano;
            movTiro.knockback = tiroArma.knockback;
            movTiro.penetracao = tiroArma.penetracao;
            movTiro.velTiro = tiroArma.velTiro;
            movTiro.player = tiroArma.player;
        }

        // escopeta
        else if (arma == 2)
        {
            for(int i = 0; i < 6; i++)
            {
                float varVel = Random.Range(-rangeVarVel,rangeVarVel);
                float varRot = Random.Range(-rangeVarRot,rangeVarRot);
                tiro = Instantiate(tiroPrefab, tiroArma.pontaArma.position, Quaternion.Euler(tiroArma.pontaArma.rotation.eulerAngles.x, tiroArma.pontaArma.rotation.eulerAngles.y, tiroArma.pontaArma.rotation.eulerAngles.z+varRot));
                movTiro = tiro.GetComponent<MovTiro>();
                movTiro.dano = tiroArma.dano;
                movTiro.knockback = tiroArma.knockback;
                movTiro.penetracao = tiroArma.penetracao;
                movTiro.velTiro = tiroArma.velTiro+varVel;
                movTiro.player = tiroArma.player;
                movTiro.varPrecisao = varRot;
            }
        }

        // Ak
        else if (arma == 3)
        {
            float varRot = Random.Range(-rangeVarRot,rangeVarRot);
            tiro = Instantiate(tiroPrefab, tiroArma.pontaArma.position, Quaternion.Euler(tiroArma.pontaArma.rotation.eulerAngles.x, tiroArma.pontaArma.rotation.eulerAngles.y, tiroArma.pontaArma.rotation.eulerAngles.z+varRot));
            movTiro = tiro.GetComponent<MovTiro>();
            movTiro.dano = tiroArma.dano;
            movTiro.knockback = tiroArma.knockback;
            movTiro.penetracao = tiroArma.penetracao;
            movTiro.velTiro = tiroArma.velTiro;
            movTiro.player = tiroArma.player;
            movTiro.varPrecisao = varRot;
        }

        // Lanca Batata
        else if (arma == 4)
        {
            float varRot = Random.Range(-rangeVarRot,rangeVarRot);
            tiro = Instantiate(tiroPrefab, tiroArma.pontaArma.position, Quaternion.Euler(tiroArma.pontaArma.rotation.eulerAngles.x, tiroArma.pontaArma.rotation.eulerAngles.y, tiroArma.pontaArma.rotation.eulerAngles.z+varRot));
            movTiro = tiro.GetComponent<MovTiro>();
            movTiro.dano = tiroArma.dano;
            movTiro.knockback = tiroArma.knockback;
            movTiro.penetracao = tiroArma.penetracao;
            movTiro.velTiro = tiroArma.velTiro;
            movTiro.player = tiroArma.player;
            movTiro.varPrecisao = varRot;
        }

        // Lanca Chama
        else if (arma == 5)
        {
            float varVel = Random.Range(-rangeVarVel,rangeVarVel);
            float varRot = Random.Range(-rangeVarRot,rangeVarRot);
            tiro = Instantiate(tiroPrefab, tiroArma.pontaArma.position, quaternion.identity);
            movTiro = tiro.GetComponent<MovTiro>();
            movTiro.dano = tiroArma.dano;
            movTiro.knockback = tiroArma.knockback;
            movTiro.penetracao = tiroArma.penetracao;
            movTiro.velTiro = tiroArma.velTiro+varVel;
            movTiro.player = tiroArma.player;
            movTiro.varPrecisao = varRot;
        }

        // Bazuca
        else if (arma == 6)
        {
        
        }
        // Laserzin
        else if (arma == 7)
        {
        
        }

        // Minigun
        else if (arma == 8)
        {
            float varRot = Random.Range(-rangeVarRot,rangeVarRot);
            tiro = Instantiate(tiroPrefab, tiroArma.pontaArma.position, Quaternion.Euler(tiroArma.pontaArma.rotation.eulerAngles.x, tiroArma.pontaArma.rotation.eulerAngles.y, tiroArma.pontaArma.rotation.eulerAngles.z+varRot));
            movTiro = tiro.GetComponent<MovTiro>();
            movTiro.dano = tiroArma.dano;
            movTiro.knockback = tiroArma.knockback;
            movTiro.penetracao = tiroArma.penetracao;
            movTiro.velTiro = tiroArma.velTiro;
            movTiro.player = tiroArma.player;
            movTiro.varPrecisao = varRot;
        }

        // Katia Flavia
        else if (arma == 9)
        {
            float varVel = Random.Range(-rangeVarVel,rangeVarVel);
            float varRot = Random.Range(-rangeVarRot,rangeVarRot);
            tiro = Instantiate(tiroPrefab, tiroArma.pontaArma.position, quaternion.identity);
            movTiro = tiro.GetComponent<MovTiro>();
            movTiro.dano = tiroArma.dano;
            movTiro.knockback = tiroArma.knockback;
            movTiro.penetracao = tiroArma.penetracao;
            movTiro.velTiro = tiroArma.velTiro+varVel;
            movTiro.player = tiroArma.player;
            movTiro.varPrecisao = varRot;
        }

        // Laser Orbital
        else if (arma == 10)
        {
        
        }

        // Railgun
        else if (arma == 11)
        {
        
        }

        // Espada do heroi
        else if (arma == 12)
        {
            float varRot = Random.Range(-rangeVarRot,rangeVarRot);
            tiro = Instantiate(tiroPrefab, tiroArma.pontaArma.position, Quaternion.Euler(tiroArma.pontaArma.rotation.eulerAngles.x, tiroArma.pontaArma.rotation.eulerAngles.y, tiroArma.pontaArma.rotation.eulerAngles.z+varRot));
            movTiro = tiro.GetComponent<MovTiro>();
            movTiro.dano = tiroArma.dano;
            movTiro.knockback = tiroArma.knockback;
            movTiro.penetracao = tiroArma.penetracao;
            movTiro.velTiro = tiroArma.velTiro;
            movTiro.player = tiroArma.player;
            movTiro.varPrecisao = varRot;
        }
    }
}
