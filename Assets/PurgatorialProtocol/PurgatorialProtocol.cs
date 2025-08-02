using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PurgatorialProtocol : MonoBehaviour
{
    public bool isFolded;

    private void Start()
    {
        isFolded = true;
    }

    public void OpenBook() 
    {
        isFolded = false;
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Button button;
            if ((button = transform.GetChild(i).GetComponent<Button>()) != null) button.interactable = true;
        }
    }

    Coroutine foldingProcess;

    public void FoldBook()
    {
        isFolded = true;
        if (foldingProcess == null) 
        {
            foldingProcess = StartCoroutine(Folder());
        }

    }

    IEnumerator Folder() 
    {  
        for(int i = transform.childCount -1; i >= 0; i--) 
        {
            if (i == 0 && !isFolded)  break;

            Transform nextPage = transform.GetChild(i);

            Button button;
            if ((button = nextPage.GetComponent<Button>()) != null) button.interactable = false;

            nextPage.GetComponent<TurnablePage>().Fold();

            yield return new WaitForSeconds(0.1f);

        }
    }

}
