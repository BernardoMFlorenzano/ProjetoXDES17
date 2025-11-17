using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject itemReal; // item dentro do jogo que representa
    private Transform posOriginal; // transform que estava linkado originalmente
    CanvasGroup canvasGroup;
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        posOriginal = transform.parent; 
        transform.SetParent(transform.root);
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;   // Deixa meio transparente durante drag
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 localPos;
        
        // Converte o ponto da tela para um ponto no "mundo" do RectTransform pai (o Canvas)
        RectTransformUtility.ScreenPointToWorldPointInRectangle(
            transform.parent as RectTransform, // O Canvas (pai atual do item)
            eventData.position,
            eventData.pressEventCamera,
            out localPos);

        transform.position = localPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

        SlotArma slotNovo = eventData.pointerEnter?.GetComponent<SlotArma>(); // Slot que dropou

        if (slotNovo == null)
        {
            GameObject dropItem = eventData.pointerEnter;
            if (dropItem != null)
            {
                slotNovo = dropItem.GetComponentInParent<SlotArma>();
            }
        }

        SlotArma slotOriginal = posOriginal.GetComponent<SlotArma>();

        if (slotNovo != null)
        {
            if (slotNovo.armaAtual != null)
            {
                // troca itens
                slotNovo.armaAtual.transform.SetParent(slotOriginal.transform);
                slotOriginal.armaAtual = slotNovo.armaAtual;
                slotNovo.armaAtual.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            }
            else
            {
                slotOriginal.armaAtual = null;
            }

            transform.SetParent(slotNovo.transform);
            slotNovo.armaAtual = gameObject;
        }
        else
        {
            transform.SetParent(posOriginal);
        }

        GetComponent<RectTransform>().anchoredPosition = Vector2.zero;


        // Atualiza armas dentro do jogo
        if (slotNovo != null)
            slotNovo.TrocaArma();

        if (slotOriginal != null)
            slotOriginal.TrocaArma();
    }


}
