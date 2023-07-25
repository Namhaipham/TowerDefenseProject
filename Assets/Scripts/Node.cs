using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hovercolor;
   
    public Vector3 positionOffset;
    private Renderer rend;
    private Color startColor;

    public Color notEnoughMoneyColor;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBluePrint turretBluePrint;
    [HideInInspector]
    public bool isUpgrade = false;

    BuildManager buildManager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
       
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    
    private void OnMouseDown()
    {
        
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if(turret != null)
        {
            buildManager.selectNode(this);
            return; 
        }
        if (!buildManager.CanBuild)
            return;
        BuildTurret(buildManager.GetTurretToBuild());
    }
    

    void BuildTurret(TurretBluePrint blueprint)
    {
        if (PlayerStates.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build");
            return;
        }
        PlayerStates.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBluePrint = blueprint;

        Debug.Log("Turret build! Money left: " + PlayerStates.Money);
    }

    public void UpgradeTurret()
    {
        if (PlayerStates.Money < turretBluePrint.UpgradeCost)
        {
            Debug.Log("Not enough money to build");
            return;
        }
        PlayerStates.Money -= turretBluePrint.UpgradeCost;
        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretBluePrint.UpgradePrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        isUpgrade = true;
        Debug.Log("Turret Upgraded!");
    }
    public void SellTurret()
    {
        PlayerStates.Money += turretBluePrint.GetSellAmount();

        Destroy(turret);
        turretBluePrint = null;
    }
    void OnMouseEnter()
    {
        
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;  

        if (buildManager.HasMoney)
        {
            rend.material.color = hovercolor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    } 


    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
