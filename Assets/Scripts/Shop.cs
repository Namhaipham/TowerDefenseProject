using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint standardArcher;
    public TurretBluePrint standardBallista;
    public TurretBluePrint standardCannon;
    public TurretBluePrint standardPosion;
    public TurretBluePrint standardWizrad;
    BuildManager buildManager;


    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectArcherTower()
    {
        buildManager.SelectTurretToBuild(standardArcher);
    }
    public void SelectBallistaTower()
    {
        buildManager.SelectTurretToBuild(standardBallista);
    }
    public void SelecPosionTower()
    {
        buildManager.SelectTurretToBuild(standardPosion);
    }
    public void SelectWizradTower()
    {
        buildManager.SelectTurretToBuild(standardWizrad);
    }
    public void SelectCannonTower()
    {
        buildManager.SelectTurretToBuild(standardCannon);
    }
}
