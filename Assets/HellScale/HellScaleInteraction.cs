using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HellScaleInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] UnityEvent onPointerEnter;
    [SerializeField] UnityEvent onPointerExit;

    public void OnPointerEnter(PointerEventData eventData) 
    {
        onPointerEnter.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onPointerExit.Invoke();
    }

}
