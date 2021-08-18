using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    BuildManager buildmanager;
    private Renderer rend;
    private Color startColor;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool IsUpdated = false;

    public Color colorEnoughMoney;
    public Vector3 positionOffest;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildmanager = BuildManager.instance;
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) 
            return;
        if (!buildmanager.CanBuild)
            return;
        if (buildmanager.HaveMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = colorEnoughMoney;
        }
           
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;    
    }
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null)
        {
            buildmanager.SelectNode(this);
            return;
        }
        if (!buildmanager.CanBuild)
            return;
        BuildTurret(buildmanager.GetTurretTobuild());
    }
    void BuildTurret(TurretBlueprint bluePrint)
    {
        if (PlayerStart.Money < bluePrint.cost)
        {
            Debug.Log("Not enough money");
            return;
        }
        PlayerStart.Money -= bluePrint.cost;

        // creat turret new
        GameObject _turret = (GameObject)Instantiate(bluePrint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        turretBlueprint = bluePrint;
        GameObject effect = (GameObject)Instantiate(buildmanager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);
        Debug.Log("Turert Build!");
    }
    public void UpgradeTurret()
    {
        if (PlayerStart.Money < turretBlueprint.Updatecost)
        {
            Debug.Log("Not enough money");
            return;
        }
        PlayerStart.Money -= turretBlueprint.Updatecost;
        Destroy(turret);
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.Upgrateprefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        GameObject effect = (GameObject)Instantiate(buildmanager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);
        IsUpdated = true;
        Debug.Log("Turert Upgraded");
    }
    public void SellTurret()
    {
        PlayerStart.Money += turretBlueprint.GetSellAmount();
        Destroy(turret);
        turretBlueprint = null;
        IsUpdated = false;
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffest;
    }
    
}
