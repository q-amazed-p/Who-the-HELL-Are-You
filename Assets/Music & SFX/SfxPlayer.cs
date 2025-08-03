using UnityEditorInternal;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class SfxPlayer : MonoBehaviour
{
    static private SfxPlayer _instance;

    [SerializeField] AudioSource[] sfxList;

    [SerializeField] AudioSource music;

    float initialMusicVolume;
    int sfxPlaying;                      

    private void Start()
    {
        _instance = this;
        sfxPlaying = 9;                  //nine means none
        gameObject.SetActive(false);
    }

    static public void PlaySfx(SFXType sfxType) 
    {
        _instance.gameObject.SetActive(true);
        _instance.PlaySfx((int)sfxType);
    }

    public void PlaySfx(int sfxType)
    {
        if (sfxPlaying == 9) initialMusicVolume = music.volume;
        else sfxList[sfxPlaying].Stop();
        sfxPlaying = sfxType;
       
        
        music.volume = initialMusicVolume * 0.25f;

        sfxList[sfxType].Play();
    }


    private void Update()
    {
        if (sfxList[sfxPlaying].isPlaying) return;
        else 
        { 
            if(music.volume < initialMusicVolume) 
            {
                music.volume += 0.01f;
                return;
            }
            sfxPlaying = 9;
            gameObject.SetActive(false);
        }
    }
}

public enum SFXType 
{
    hellSfx = 0,
    heavenSfx = 1,
    defeatSfx= 2,
    victorySfx= 3
}