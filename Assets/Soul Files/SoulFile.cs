using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SoulFile : MonoBehaviour
{
    Image mySprite;
    Coroutine fadeProcess;

    void Start()
    {
        mySprite = GetComponent<Image>();
        fadeProcess = null;

        FindAnyObjectByType<HellScale>().ReportNewFile(this);
    }

    void Update()
    {
        
    }

    public void Dismiss(bool spared) 
    {
        if (fadeProcess != null) return;
        fadeProcess = StartCoroutine(Fade(spared));
    }

    IEnumerator Fade(bool whiteOut) 
    {
        Color colorDelta = whiteOut ? new Color(0, 0, 0, -1) : new Color(-1, -1, -1, 0);
        for(float i = 1; i > 0; i -= Time.deltaTime) 
        {
            mySprite.color += colorDelta * Time.deltaTime;
            yield return null;
        }
        mySprite.enabled = false;
        yield return new WaitForSeconds(1);

        SoulSpawner.Instance.SpawnNextSoul();
        Destroy(this.gameObject);
    }
}
