using TMPro;
using UnityEngine;

public class DayResultMessage : MonoBehaviour
{
    [SerializeField] TMP_Text right;
    [SerializeField] TMP_Text wrong;

    [SerializeField] PageUnlocker pageUnlocker;

    private void OnEnable()
    {
        SfxPlayer.PlaySfx(SFXType.victorySfx);
        int rightCount;
        int wrongCount;
        ScoreKeeper.ScoreDay(out rightCount, out wrongCount);
        right.text = rightCount.ToString();
        wrong.text = wrongCount.ToString();

        pageUnlocker.UnlockNextPage();
    }
}
