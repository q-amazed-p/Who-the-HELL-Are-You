using TMPro;
using UnityEngine;

public class DayResultMessage : MonoBehaviour
{
    [SerializeField] TMP_Text right;
    [SerializeField] TMP_Text wrong;

    private void OnEnable()
    {
        int rightCount;
        int wrongCount;
        ScoreKeeper.ScoreDay(out rightCount, out wrongCount);
        right.text = rightCount.ToString();
        wrong.text = wrongCount.ToString();
    }
}
