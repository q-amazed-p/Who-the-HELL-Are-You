using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoulFile : MonoBehaviour
{
    Image mySprite;
    TMP_Text[] allText;
    Coroutine fadeProcess;

    bool anomaly;
    int anomalyCode;

    [SerializeField] TMP_Text nameEntry;
    [SerializeField] TMP_Text dateEntry;
    [SerializeField] TMP_Text locationEntry;
    [SerializeField] TMP_Text causeEntry;


    void Start()
    {
        mySprite = GetComponent<Image>();
        allText = GetComponentsInChildren<TMP_Text>();
        fadeProcess = null;

        FindAnyObjectByType<HellScale>().ReportNewFile(this);

        SoulData nextSoulDetails = FindAnyObjectByType<SoulPool>().ReadNextSoul();
        anomalyCode = nextSoulDetails.metaAnomalyCode;
        anomaly = anomalyCode != 0;

        nameEntry.text = nextSoulDetails.name;
        dateEntry.text = nextSoulDetails.date;
        locationEntry.text = nextSoulDetails.location;
        causeEntry.text = nextSoulDetails.cause;
    }

    public void Dismiss(bool spared) 
    {
        ScoreKeeper.AddScore(spared ^ anomaly);

        ScoreKeeper.CheckForGameOver();

        fadeProcess = StartCoroutine(Fade(spared));
    }

    IEnumerator Fade(bool whiteOut) 
    {
        Color colorDelta = whiteOut ? new Color(0, 0, 0, -1) : new Color(-1, -1, -1, 0);
        for(float i = 1; i > 0; i -= Time.deltaTime) 
        {
            mySprite.color += colorDelta * Time.deltaTime;
            foreach (TMP_Text tmpt in allText) tmpt.color += colorDelta * Time.deltaTime;

            yield return null;
        }
        mySprite.enabled = false;
        foreach (TMP_Text tmpt in allText) tmpt.enabled = false;
        yield return new WaitForSeconds(1);

        if (GameState.endOfDay)
        {
            GameState.endOfDay = false;
            ScoreKeeper.EndTheDay();
        }
        else SoulSpawner.Instance.SpawnNextSoul();
        Destroy(this.gameObject);
    }
}
