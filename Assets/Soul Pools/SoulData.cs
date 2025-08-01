using System;
using UnityEngine;

[Serializable]
public class SoulData
{
    [Header("Deth Certificate")]
    [SerializeField] string name;
    [SerializeField] int age;
    [SerializeField] string cause;
    [SerializeField] string location;

    [Header("Criminal Record")]
    [SerializeField] string crimesCommited;
    [SerializeField] string verdicts;
    [SerializeField] string prisonTime;

    [Header("Charity Ledger")]
    [SerializeField] int donations;
    [SerializeField] string volunteering;
    [SerializeField] string livesSaved;

    [Header("Virtue Report")]
    [Range(0, 9)][SerializeField] int pride;
    [Range(0, 9)][SerializeField] int regret;
    [Range(0, 9)][SerializeField] int love;
    [Range(0, 9)][SerializeField] int hate;
}
