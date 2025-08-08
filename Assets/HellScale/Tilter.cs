using UnityEngine;
using System.Collections;

public class Tilter : MonoBehaviour
{
    [SerializeField] Quaternion rightExtreme;
    [SerializeField] Quaternion leftExtreme;

    [SerializeField] RectTransform rightPanT;
    [SerializeField] RectTransform leftPanT;

    Coroutine tilterator;

    public void LoadRight() 
    {
        if (tilterator != null) StopCoroutine(tilterator);
        tilterator = StartCoroutine(Tilterator(TiltDirection.right));
    }

    public void LoadLeft() 
    {
        if (tilterator != null) StopCoroutine(tilterator);
        tilterator = StartCoroutine(Tilterator(TiltDirection.left));
    }

    public void Free()
    {
        if (tilterator != null) StopCoroutine(tilterator);
        tilterator = StartCoroutine(Tilterator(TiltDirection.balanced));
    }

    IEnumerator Tilterator(TiltDirection tiltDirection) 
    {
        Quaternion startingAngle = transform.rotation;

        Quaternion targetAngle = Quaternion.identity;
        switch (tiltDirection) 
        {
            case TiltDirection.balanced:
                break;
            case TiltDirection.right:
                targetAngle = rightExtreme;
                break;
            case TiltDirection.left:
                targetAngle = leftExtreme;
                break;
        } 

        for(float i = 0; i < 1;  i += Time.deltaTime) 
        {
            float dynamisedI = -0.5f*Mathf.Cos(10*i/Mathf.PI) + 0.5f;
            transform.rotation = Quaternion.Lerp(startingAngle, targetAngle, dynamisedI);

            rightPanT.rotation = Quaternion.identity;
            leftPanT.rotation = Quaternion.identity;

            yield return null;
        }
    }

}

public enum TiltDirection 
{ 
    balanced = 0,
    right = 1,
    left = 2
}

