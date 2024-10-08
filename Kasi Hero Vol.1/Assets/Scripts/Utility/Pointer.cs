using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Pointer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject statusText;

    // When highlighted with mouse
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Show status
        statusText.SetActive(true);
    }

    // When not highlighted
    public void OnPointerExit(PointerEventData eventData) 
    {
        // Hide status
        statusText.SetActive(false);
    }
}
