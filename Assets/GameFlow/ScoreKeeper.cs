using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    static ScoreKeeper _instance;

    int currentGottenRight;
    int currentGottenWrong;

    [SerializeField] GameObject endOfDayMessage;


    void Start()
    {
        _instance = this;
        currentGottenRight = 0;
        currentGottenWrong = 0;
    }

    static public void AddScore(bool correct) 
    {
        if (correct) _instance.currentGottenRight++;
        else _instance.currentGottenWrong++;
    }

    static public void EndTheDay() 
    {
        _instance.endOfDayMessage.SetActive(true);
    }

    static public void ScoreDay(out int gottenRight, out int gottenWorng) 
    {
        gottenRight = _instance.currentGottenRight;
        totalGottenRight = _instance.currentGottenRight;
        _instance.currentGottenRight = 0;

        gottenWorng = _instance.currentGottenWrong;
        totalGottenWrong += _instance.currentGottenWrong;
        _instance.currentGottenWrong = 0;
    }


    static int totalGottenRight;
    static int totalGottenWrong;
}
