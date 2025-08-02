using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.Events;

public class DeskableObject : MonoBehaviour, IPointerMoveHandler
{
    Coroutine rotationProcess;

    public bool isDesked;

    [SerializeField] float rotationSpeed;
    [SerializeField] int targetAngle;

    [SerializeField] UnityEvent onDesked;
    [SerializeField] UnityEvent onPicked;

    private void Start()
    {
        rotationProcess = null;
        isDesked = true;
    }

    IEnumerator Rotate(bool toBeDesked)
    {
        if (toBeDesked) 
        {
            Debug.Log("invoked desked");
            onDesked.Invoke();
            while (transform.rotation.eulerAngles.x < targetAngle) 
            {
                transform.Rotate(Vector3.right*rotationSpeed);
                yield return null;
            }
        }
        else 
        {
            while (transform.rotation.eulerAngles.x < 350)
            {
                transform.Rotate(Vector3.left*rotationSpeed);
                yield return null;
            }
            transform.localRotation = Quaternion.identity;
            Debug.Log("invoked picked");
            onPicked.Invoke();
        }

    }

    public void OnPointerMove(PointerEventData pointerData)
    {
            if (transform.position.y < -2)
            {
                if (!isDesked)
                {
                    if (rotationProcess != null) StopCoroutine(rotationProcess);
                    rotationProcess = StartCoroutine(Rotate(true));
                    isDesked = true;
                }

            }
            else
            {
                if (isDesked)
                {
                    if (rotationProcess != null) StopCoroutine(rotationProcess);
                    rotationProcess = StartCoroutine(Rotate(false));
                    isDesked = false;
                }
            }
        
    }

}