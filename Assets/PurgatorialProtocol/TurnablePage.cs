using System.Collections;
using UnityEngine;

public class TurnablePage : MonoBehaviour
{
    Coroutine pageTurningProcess;
    [SerializeField] int pageNumber;
    bool isTurned;

    private void Start()
    {
        pageTurningProcess = null;
        isTurned = false;
    }

    public void FlipPage() 
    {
        if (!isTurned) 
        {
            TurnOpen();
        }
        else 
        {
            TurnClosed();
            
        }
    }

    public void Fold() 
    {
        if (isTurned) 
        {
            TurnClosed();
        }
    }

    public void TurnOpen() 
    {
        if (pageTurningProcess != null) StopCoroutine(pageTurningProcess);

        pageTurningProcess = StartCoroutine(PageTurner(true));
        isTurned = true;
    }

    public void TurnClosed() 
    {
        if (pageTurningProcess != null) StopCoroutine(pageTurningProcess);

        pageTurningProcess = StartCoroutine(PageTurner(false));
        isTurned = false;
    }


    IEnumerator PageTurner(bool toOpen) 
    {
        Vector3 angleDelta = Vector3.up;
        
        if (toOpen) 
        {
            while (transform.rotation.eulerAngles.y < 180)
            {
                transform.Rotate(angleDelta);
                yield return null;
            }
            transform.SetSiblingIndex(pageNumber);
        }

        else 
        {
            transform.SetSiblingIndex(transform.childCount - 1 - pageNumber);

            angleDelta *= -1;
            while (transform.rotation.eulerAngles.y > 0 && transform.rotation.eulerAngles.y < 350)
            {
                transform.Rotate(angleDelta);
                yield return null;
            }
            transform.localRotation = Quaternion.identity;
            
        }
    }

}
