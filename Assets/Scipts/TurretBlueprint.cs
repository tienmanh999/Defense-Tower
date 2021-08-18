using System.Collections;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;

    public GameObject Upgrateprefab;
    public int Updatecost;

    public int GetSellAmount()
    {
        return cost / 2; 
    }
}
