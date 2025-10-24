using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class BracoMovimento : MonoBehaviour
{
    [SerializeField] private Transform armaTransform;
    private Transform comecoBraco;
    private Vector3 rotacao;
    private float angulo;
    private float distancia;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        comecoBraco = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        rotacao = armaTransform.position - comecoBraco.position;
        angulo = Mathf.Atan2(rotacao.y, rotacao.x) * Mathf.Rad2Deg;
        distancia = Vector2.Distance(armaTransform.position, comecoBraco.position);

        transform.localScale = new Vector2(distancia*1.5f, transform.localScale.y);
        transform.rotation = Quaternion.Euler(0, 0, angulo);

    
    }
}
