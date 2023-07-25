using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    public Text UpgradeCost;
    public Text UpgradeCostLV_2;
    public Text UpgradeCostLV_3;
    public Text UpgradeCostLV_4;
    public Button UpgradeButton;
    private int UpgradeTime = 0;
    private Node target;
    public Text Sell_amount;
    
    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();


        if (!target.isUpgrade)
        {   
                UpgradeCost.text = "$" + target.turretBluePrint.UpgradeCost;
                //UpgradeTime++;
                UpgradeButton.interactable = true;
        }
        else
        {
            UpgradeCost.text = "Done";
            UpgradeButton.interactable = false;
        }

        Sell_amount.text = "$" + target.turretBluePrint.GetSellAmount();
        ui.SetActive(true);


    }

    public void Hide()
    {
        ui.SetActive(false);
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
