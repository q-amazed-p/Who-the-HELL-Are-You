using UnityEditor;
using UnityEngine;

public class SoulPool : MonoBehaviour
{
    [SerializeField] GameObject NextSoulPool;

    [SerializeField] SoulData[] soulsForTheDay;

    int judgementProgress;

    private void Start()
    {
        judgementProgress = 0;
    }

    public SoulData ReadNextSoul() 
    {
        int next = judgementProgress;
        judgementProgress++;

        Debug.Log("progress " + judgementProgress + " vs total " + soulsForTheDay.Length);

        if(judgementProgress == soulsForTheDay.Length)
        {
            GameState.endOfDay = true;
            Instantiate(NextSoulPool);
            Destroy(this.gameObject);
        }

        return soulsForTheDay[next];
    }
}
