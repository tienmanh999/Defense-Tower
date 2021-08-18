using UnityEngine;

public class BuildManager : MonoBehaviour
{ 
    public static BuildManager instance;


    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Cant' build");
            return;
        }
        instance = this;
    }
  
    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HaveMoney { get { return PlayerStart.Money >= turretToBuild.cost; } }

    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
        
    }
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();

    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }
    public TurretBlueprint GetTurretTobuild()
    {
        return turretToBuild;
    }
}
