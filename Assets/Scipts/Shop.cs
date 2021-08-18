using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;

    BuildManager buildmanager;
    void Start()
    {
        buildmanager = BuildManager.instance;    
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard turret selected!");
        buildmanager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileTurret()
    {
        Debug.Log("Missile turret selected!");
        buildmanager.SelectTurretToBuild(missileLauncher);
    }
    public void SelectLaserTurret()
    {
        Debug.Log("Laser turret selected!");
        buildmanager.SelectTurretToBuild(laserBeamer);
    }
}
