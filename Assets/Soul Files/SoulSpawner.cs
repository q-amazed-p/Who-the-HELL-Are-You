using UnityEngine;

public class SoulSpawner : MonoBehaviour
{
    static SoulSpawner _instance;
    public static SoulSpawner Instance => _instance;

    public GameObject tempSoulFile;

    SoulPool soulPool;

    public GameObject SpawnNextSoul() 
    {
        return Instantiate(tempSoulFile, transform);
    }

    void Start() 
    {
        _instance = this;
    }
}
