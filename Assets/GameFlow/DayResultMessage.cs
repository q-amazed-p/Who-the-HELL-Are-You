using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayResultMessage : MonoBehaviour
{
    [SerializeField] TMP_Text right;
    [SerializeField] TMP_Text wrong;

    [SerializeField] Button dismissButton;
    [SerializeField] PageUnlocker pageUnlocker;
    int newDaySeen = 1;

    private void OnEnable()
    {
        SfxPlayer.PlaySfx(SFXType.victorySfx);
        int rightCount;
        int wrongCount;
        ScoreKeeper.ScoreDay(out rightCount, out wrongCount);
        right.text = rightCount.ToString();
        wrong.text = wrongCount.ToString();

        newDaySeen++;
        if (newDaySeen > GameState.totalDays) dismissButton.onClick.AddListener(GetComponent<PlayAgainButton>().PlayAgain);
        else pageUnlocker.UnlockNextPage();
    }
}
