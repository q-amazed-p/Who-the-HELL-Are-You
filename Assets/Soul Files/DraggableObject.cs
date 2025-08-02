using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    Vector3 holderOffset;

    bool isHeld;

    public void OnPointerEnter(PointerEventData pointerData) 
    {
        GetComponent<Image>().color += new Color(0.05f, 0.05f, 0.05f, 0);
    }

    public void OnPointerExit(PointerEventData pointerData) 
    {
        GetComponent<Image>().color -= new  Color(0.05f, 0.05f, 0.05f, 0);
        isHeld = false;

    }

    public void OnPointerDown(PointerEventData pointerData) 
    {
        holderOffset = transform.position - pointerData.pointerCurrentRaycast.worldPosition;
        isHeld = true;
        
    }

    public void OnPointerUp(PointerEventData pointerData)
    {
        isHeld = false;
    }

    public void OnPointerMove(PointerEventData pointerData) 
    {
        if (isHeld && pointerData.pointerCurrentRaycast.worldPosition != Vector3.zero)
        {
            Vector3 followedPosition = pointerData.pointerCurrentRaycast.worldPosition + holderOffset;
            transform.position = new Vector3(followedPosition.x, followedPosition.y, 0);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        holderOffset = Vector3.zero;
        isHeld = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
