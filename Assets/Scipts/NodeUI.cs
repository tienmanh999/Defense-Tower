using UnityEngine.UI;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject UI;
    public Text UpgradeCost;
    public Button upgradeButton;
    public Text sellcost;

    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();
        if (!target.IsUpdated)
        {
            UpgradeCost.text = "$" + target.turretBlueprint.Updatecost.ToString();
            upgradeButton.interactable = true;
        }
        else
        {
            UpgradeCost.text = "Done!";
            upgradeButton.interactable = false;
        }
        sellcost.text = "$" + target.turretBlueprint.GetSellAmount();
        UI.SetActive(true);
    }
    public void Hide()
    {
        UI.SetActive(false);
    }
    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
