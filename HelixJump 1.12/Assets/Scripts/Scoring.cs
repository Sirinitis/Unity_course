using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Scoring 
{
    public static int Multiplicator { get; set; }
    public static int Bonuspoints { get; set; }
    public static int AllPointsLevel { get; private set; }
    public static bool HaveChanges { get; private set; }
    public static int BestPoints { get => PlayerPrefs.GetInt(BestPointsKey, 0); private set => PlayerPrefs.SetInt(BestPointsKey, value); }

    private const string BestPointsKey = "BestPoints";

    public static void ScoringPoints()
    {
        AllPointsLevel += (Bonuspoints * Multiplicator);
    }
    public static void DestroyPoints()
    {
        AllPointsLevel = 0;
        HaveChanges = false;
    }
    public static void BestPointsInfo()
    {
        if (BestPoints >= AllPointsLevel) return;
        BestPoints = AllPointsLevel;
        HaveChanges = true;
    }
}
