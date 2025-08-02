using System;
using UnityEngine;

[Serializable]
public struct SoulData
{
    public bool metaGuilty;

    [Header("Deth Certificate")]
    public string name;
    public int age;
    public string cause;
    public string location;

    [Header("Criminal Record")]
    public string crimesCommited;
    public string verdicts;
    public string prisonTime;

    [Header("Charity Ledger")]
    public int donations;
    public string volunteering;
    public string livesSaved;

    [Header("Virtue Report")]
    [Range(0, 9)] public int pride;
    [Range(0, 9)] public int regret;
    [Range(0, 9)] public int love;
    [Range(0, 9)] public int hate;
}
