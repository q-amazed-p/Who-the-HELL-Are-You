using UnityEngine;

public class HellScale : MonoBehaviour
{
    [SerializeField] SoulPool soulPool;

    [SerializeField] SoulFile currentSoulFile;

    public void Condemn()
    {
        currentSoulFile.Dismiss(false);
    }

    public void Redeem()
    {
        currentSoulFile.Dismiss(true);
    }

    public void ReportNewFile(SoulFile newSoulFile)
    {
        currentSoulFile = newSoulFile;
    }
}