using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpeakerButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] AudioSource music;
    
    public void ToggleMusic() 
    {
        music.mute ^= true;
    }

    public void OnPointerDown(PointerEventData eventData) 
    {
        transform.position += 0.1f * Vector3.down;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.position += 0.1f * Vector3.up;
    }
}
