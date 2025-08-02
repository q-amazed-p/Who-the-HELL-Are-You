using UnityEngine;

public class SoulSpawner : MonoBehaviour
{
    static SoulSpawner _instance;
    public static SoulSpawner Instance => _instance;

    public GameObject soulFilePref;

    public void SpawnNextSoul() 
    {
        Instantiate(soulFilePref, transform);
    }

    void Start() 
    {
        _instance = this;
    }
}
