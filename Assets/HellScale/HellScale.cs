using UnityEngine;
using UnityEngine.UI;

public class HellScale : MonoBehaviour
{

    [SerializeField] SoulFile currentSoulFile;

    [SerializeField] Image condemnPan;
    [SerializeField] Image redeemPan;

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
        condemnPan.enabled = true;
        redeemPan.enabled = true;
    }
}