using UnityEngine;

public class PageUnlocker : MonoBehaviour
{
    [SerializeField] GameObject[] lockedPages;

    int unlockNextIndex;

    private void Start()
    {
        unlockNextIndex = 0;
    }

    public void UnlockNextPage() 
    {
        lockedPages[unlockNextIndex].SetActive(true);
        unlockNextIndex++;
    }

}
