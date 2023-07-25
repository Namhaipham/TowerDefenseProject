using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBluePrint
{
    public GameObject prefab;
    public int cost;


    public GameObject UpgradePrefab;
    public int UpgradeCost;
    //public GameObject UpgradePrefab_2;
    public int UpgradeCostLV_2;
   // public GameObject UpgradePrefab_3;
    public int UpgradeCostLV_3;
   // public GameObject UpgradePrefab_4;
    public int UpgradeCostLV_4;

    public int GetSellAmount()
    {
        return cost / 3;
    }
}
