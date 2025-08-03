using System;
using UnityEngine;

[Serializable]
public struct SoulData
{
    public int metaAnomalyCode;

    [Header("Deth Certificate")]
    public string name;
    public string date;
    public string cause;
    public string location;

}
