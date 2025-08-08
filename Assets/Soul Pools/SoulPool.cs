using UnityEngine;

public class SoulPool : MonoBehaviour
{
    [SerializeField] GameObject NextSoulPool;

    [SerializeField] SoulData[] soulsForTheDay;

    [SerializeField] GameObject todayPage;

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
            if (NextSoulPool != null) Instantiate(NextSoulPool);
            Destroy(this.gameObject);
        }

        return soulsForTheDay[next];
    }
}
